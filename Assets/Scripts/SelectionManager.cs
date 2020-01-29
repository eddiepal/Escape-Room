using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

//following tutorial from: https://www.youtube.com/watch?v=QDldZWvNK_E

public class SelectionManager : MonoBehaviour
{
    [SerializeField] private string selectableTag = "DoorButton";

    private ISelectionResponse _selectionResponse;

    private Transform _selection;

    private void Awake()
    {
        _selectionResponse = GetComponent<ISelectionResponse>();
    }

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
        if (Camera.main != null)
        {
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
        }

        #endregion

        // Deselection/Selection Response
        if (_selection != null)
        {
            _selectionResponse.OnSelect(_selection);
        }
    }
}