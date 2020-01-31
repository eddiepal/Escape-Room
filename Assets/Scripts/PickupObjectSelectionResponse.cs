using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObjectSelectionResponse : MonoBehaviour, ISelectionResponse
{
    [SerializeField] public Material defaultMaterial;
    [SerializeField] public Material highlightMaterial;

    public Transform theDest;

    public void OnSelect(Transform selection)
    {
        Debug.Log("In OnSelect method of PickupObjectSelectionResponse");
        if (Input.GetMouseButton(0))
        {
            Debug.Log("In getmousebutton statement");
            selection.position = GameObject.Find("Destination").transform.position;
            transform.parent = GameObject.Find("Destination").transform;
        }
    }

    public void OnDeselect(Transform selection)
    {
        var selectionRenderer = selection.GetComponent<Renderer>();
        selectionRenderer.material = this.defaultMaterial;
    }

    public void DropObject(Transform selection)
    {
        throw new System.NotImplementedException();
    }

    public void DropObject()
    {
        throw new System.NotImplementedException();
    }

    public void dropObject(Transform selection)
    {
        throw new System.NotImplementedException();
    }
}
