
using UnityEngine;

internal class HighlightSelectionResponse : MonoBehaviour, ISelectionResponse
{
    [SerializeField] private Material defaultMaterial;
    [SerializeField] private Material highlightMaterial;

    public Transform objectHolding;
    [SerializeField] private bool holdingObject = false;

    public void OnSelect(Transform selection)
    {
        if (holdingObject == false)
        {
            var selectionRenderer = selection.GetComponent<Renderer>();
            if (selectionRenderer != null)
            {
                defaultMaterial = selectionRenderer.material;
                selectionRenderer.material = this.highlightMaterial;
            }

            objectHolding = selection;
            if (Input.GetMouseButton(0))
            {
                holdingObject = true;
                selectionRenderer.material = defaultMaterial;
                selection.GetComponent<Rigidbody>().useGravity = false;
                selection.position = GameObject.Find("Destination").transform.position;
                selection.rotation = GameObject.Find("Destination").transform.rotation;
                selection.parent = GameObject.Find("Destination").transform;
                selection.GetComponent<MeshCollider>().enabled = false;
            }
        }
    }

    public void OnDeselect(Transform selection)
    {
        if (!holdingObject)
        {
            var selectionRenderer = selection.GetComponent<Renderer>();
            selectionRenderer.material = defaultMaterial;
        }
    }

    public void DropObject()
    {
        Debug.Log("In DropObject method");
        
        if (holdingObject && Input.GetMouseButton(1))
        {
            objectHolding.GetComponent<Rigidbody>().useGravity = true;
            objectHolding.parent = null;
            objectHolding.GetComponent<MeshCollider>().enabled = true;
            holdingObject = false;
        }
    }
}