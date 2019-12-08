using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{

    [SerializeField] private Material defaultMaterial;
    [SerializeField] private Material highlightMaterial;
    [SerializeField] private string selectableTag = "DoorButton";

    private Transform _selection;
    
    private void Update()
    {
        // Deselection/Selection Response
        if (_selection != null)
        {
            var selectionRenderer = _selection.GetComponent<Renderer>();
            selectionRenderer.material = defaultMaterial;
            _selection = null;
        }



        // Creating a Ray
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        // Determining what was selected / Selection Determination

        _selection = null;
        if (Physics.Raycast(ray, out var hit))  
        {
            var selection = hit.transform;
            // Deselection/Selection Response
            if (selection.CompareTag(selectableTag))
            {
                _selection = selection;
            }
        }

        if (_selection != null)
        {
            var selectionRenderer = _selection.GetComponent<Renderer>();
            if (selectionRenderer != null)
            {
                selectionRenderer.material = highlightMaterial;
            }
        }
    }
}
