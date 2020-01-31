
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

        theSelection = selection;
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
                
                photonView.RPC("PickupObject", RpcTarget.All, selection.GetComponent<PhotonView>().ViewID);

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
        if (holdingObject && Input.GetMouseButton(1))
        {
            objectHolding.GetComponent<Rigidbody>().useGravity = true;
            objectHolding.parent = null;
            objectHolding.GetComponent<MeshCollider>().enabled = true;
            holdingObject = false;
        }
    }

    [PunRPC]
    public void PickupObject(int viewId)
    {
        Transform tempHold = PhotonView.Find(viewId).transform;
        GameObject childGameObject = gameObject.transform.GetChild(0).gameObject;
        
        tempHold.GetComponent<Rigidbody>().useGravity = false;
        tempHold.GetComponent<MeshCollider>().enabled = false;
        tempHold.position = childGameObject.transform.position;
        tempHold.rotation = childGameObject.transform.rotation;
        tempHold.parent = childGameObject.transform;
    }
    
    
    public Transform sender;
    public Transform target;



    [PunRPC]
    void SomeFunction(int senderView, int targetView){
        sender = PhotonView.Find (senderView).transform;
        target = PhotonView.Find(targetView).transform;
//do stuff with the transforms(works with GOs, rigidbodies or any other component of the GO)
    }
}