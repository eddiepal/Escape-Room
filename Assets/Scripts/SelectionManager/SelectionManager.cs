using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEditor;
using UnityEngine;

//following tutorial from: https://www.youtube.com/watch?v=QDldZWvNK_E

public class SelectionManager : MonoBehaviourPun
{
    [SerializeField] private string selectableTag;

    private ISelectionResponse _selectionResponse;
    private Transform _selection;

    private bool alreadyExecuted = false;
    [SerializeField] float maxSelectionDistance = 3.0f;

    private void Awake()
    {
        _selectionResponse = GetComponent<ISelectionResponse>();
    }

    public Transform Selection
    {
        set => _selection = value;
        get => _selection;
    }
    
    private void Update()
    {
        if (!photonView.IsMine)  
            return;

        if (GameManager.instance.WordMade && alreadyExecuted == false)
        {
            alreadyExecuted = true;
            selectableTag = "Test";
        }

        // Deselection/Selection Response
        if (_selection != null)
        {
            _selectionResponse.OnDeselect(_selection);
        }

        #region Selection Determination

        CreateRay();

        #endregion

        // Deselection/Selection Response
        if (_selection != null)
        {
            _selectionResponse.OnSelect(_selection);
        }

        _selectionResponse.OnDropObject();
    }
 
    public void CreateRay()
    {
        // Creating a Ray
        //Camera playerCamera = GameManager.instance.players[1].GetComponentInChildren<Camera>();
        if (Camera.main != null && Camera.main == enabled)
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
            // Determining what was selected / Selection Determination
            _selection = null;
            if (Physics.Raycast(ray, out var hit))  
            {
                var selection = hit.transform;
                if (selection.CompareTag(selectableTag) && hit.distance < maxSelectionDistance)
                {
                    _selection = selection;
                }
            }
        }
    }
}