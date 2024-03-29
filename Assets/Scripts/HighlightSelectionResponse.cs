
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

            photonView.RPC("updateHeldObject", RpcTarget.All, selection.GetComponent<PhotonView>().ViewID);
            
            if (Input.GetMouseButton(0))
            {
                holdingObject = true;
                selectionRenderer.material = defaultMaterial;
                
                photonView.RPC("PickupObject", RpcTarget.All, selection.GetComponent<PhotonView>().ViewID);

            }
        }
    }

    [PunRPC]
    public void updateHeldObject(int viewId)
    {
        Transform tempHold = PhotonView.Find(viewId).transform;
        objectHolding = tempHold;
    }

    public void OnDeselect(Transform selection)
    {
        if (!holdingObject)
        {
            var selectionRenderer = selection.GetComponent<Renderer>();
            selectionRenderer.material = defaultMaterial;
        }
    }

    public void DropObject(Transform selection)
    {
        if (holdingObject && Input.GetMouseButton(1))
        {
            holdingObject = false;
            photonView.RPC("UpdateObjectComponents", RpcTarget.All, objectHolding.GetComponent<PhotonView>().ViewID);
        }
    }

    [PunRPC]
    public void UpdateObjectComponents(int viewId)
    {
        Transform tempHold = PhotonView.Find(viewId).transform;

        tempHold.GetComponent<Rigidbody>().useGravity = true;
        tempHold.parent = null;
        tempHold.GetComponent<MeshCollider>().enabled = true;
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
    
    

}