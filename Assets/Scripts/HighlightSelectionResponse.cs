
using Photon.Pun;
using UnityEngine;

internal class HighlightSelectionResponse : MonoBehaviourPun, ISelectionResponse
{
    [SerializeField] private Material defaultMaterial;
    [SerializeField] private Material highlightMaterial;

    public Transform objectHolding;
    [SerializeField] private bool holdingObject = false;

    public Transform theSelection;
    
    [PunRPC]
    public void OnSelect(Transform selection)
    {
        if (!photonView.IsMine)
            return;
        theSelection = selection;
        if (holdingObject == false)
        {
            Debug.Log(selection.name);
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

                //selection.GetComponent<photon>()
                
                selection.GetComponent<Rigidbody>().useGravity = false;
                selection.position = GameObject.Find("Destination").transform.position;
                selection.rotation = GameObject.Find("Destination").transform.rotation;
                selection.parent = GameObject.Find("Destination").transform;
                selection.GetComponent<MeshCollider>().enabled = false;
    
                //photonView.RPC("DoThings", RpcTarget.All);
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

    [PunRPC]
    public void DoThings()
    {
        theSelection.GetComponent<Rigidbody>().useGravity = false;
        theSelection.position = GameObject.Find("Destination").transform.position;
        theSelection.rotation = GameObject.Find("Destination").transform.rotation;
        theSelection.parent = GameObject.Find("Destination").transform;
        theSelection.GetComponent<MeshCollider>().enabled = false;
    }
}