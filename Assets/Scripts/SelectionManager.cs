using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    [SerializeField] private string selectableTag = "DoorButton";

    private HighlightSelectionResponse _selectionResponse;

    private Transform _selection;

    public Transform Selection
    {
        set { _selection = value; }
        get { return _selection; }
    }

    private void Update()
    {
        // Deselection/Selection Response
        if (_selection != null)
        {
            _selectionResponse.OnDeselect(_selection);
        }

        #region Selection Determination

        // Creating a Ray
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        // Determining what was selected / Selection Determination
        _selection = null;
        if (Physics.Raycast(ray, out var hit))  
        {
            var selection = hit.transform;
            
            if (selection.CompareTag(selectableTag))
            {
                _selection = selection;
            }
        }

        #endregion

        // Deselection/Selection Response
        if (_selection != null)
        {
            _selectionResponse.OnSelect(_selection);
        }
    }
}

internal class HighlightSelectionResponse : MonoBehaviour
{
    [SerializeField] public Material defaultMaterial;
    [SerializeField] public Material highlightMaterial;

    public void OnSelect(Transform selection)
    {
        var selectionRenderer = selection.GetComponent<Renderer>();
        if (selectionRenderer != null)
        {
            selectionRenderer.material = this.highlightMaterial;
        }
    }

    public void OnDeselect(Transform selection)
    {
        var selectionRenderer = selection.GetComponent<Renderer>();
        selectionRenderer.material = this.defaultMaterial;
    }
}
