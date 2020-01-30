using UnityEngine;

internal class HighlightSelectionResponse : MonoBehaviour, ISelectionResponse
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
        if (Input.GetMouseButton(0))
        {
            selection.position = GameObject.Find("Destination").transform.position;
            selection.parent = GameObject.Find("Destination").transform;
        }
    }

    public void OnDeselect(Transform selection)
    {
        var selectionRenderer = selection.GetComponent<Renderer>();
        selectionRenderer.material = this.defaultMaterial;
    }
}