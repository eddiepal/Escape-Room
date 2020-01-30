using UnityEngine;

internal class HighlightSelectionResponse : MonoBehaviour, ISelectionResponse
{
    [SerializeField] private Material defaultMaterial;
    [SerializeField] private Material highlightMaterial;

    public Transform objectHolding;

    public void OnSelect(Transform selection)
    {
        var selectionRenderer = selection.GetComponent<Renderer>();
        if (selectionRenderer != null)
        {
            selection.GetComponent<Rigidbody>().useGravity = false;
            defaultMaterial = selectionRenderer.material;
            selectionRenderer.material = this.highlightMaterial;
        }
        if (Input.GetMouseButton(0))
        {
            selection.position = GameObject.Find("Destination").transform.position;
            selection.parent = GameObject.Find("Destination").transform;
        }
    }

    public void OnDeselect(Transform selection)
    {
        var selectionRenderer = selection.GetComponent<Renderer>();
        selectionRenderer.material = defaultMaterial;
        
        if (Input.GetMouseButton(1))
        {
            selection.parent = null;
            selection.GetComponent<Rigidbody>().useGravity = true;
        }
    }
}