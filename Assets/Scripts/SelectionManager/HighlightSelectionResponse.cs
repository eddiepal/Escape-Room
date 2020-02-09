using System;
using System.Collections;
using Photon.Pun;
using TMPro;
using UnityEngine;

internal class HighlightSelectionResponse : MonoBehaviourPun, ISelectionResponse
{
    [Tooltip("Text to notify other players what interaction this player has done")]
    [SerializeField] private TextMeshProUGUI playerInteractionText;
    
    [Header("Object Details")]
    [SerializeField] Transform objectHolding;
    [SerializeField] bool holdingObject = false;
    [SerializeField] Transform theSelection;

    [Header("Materials")]
    [SerializeField] private Material defaultMaterial;
    [SerializeField] private Material highlightMaterial;
    [SerializeField] private Material pickedupMaterial;

    private void Awake()
    {
        playerInteractionText = GameObject.FindWithTag("playerInteractionText").GetComponent<TextMeshProUGUI>();
    }


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

            photonView.RPC("UpdateHeldObject", RpcTarget.All, selection.GetComponent<PhotonView>().ViewID);

            if (PlayerInput.playerInput.controls.PlayerControls.PickupObject.triggered)
            {
                holdingObject = true;
                selectionRenderer.material = defaultMaterial;

                photonView.RPC("PickedupObjectMessage", RpcTarget.Others, selection.GetComponent<PhotonView>().ViewID, PhotonNetwork.LocalPlayer.NickName);
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
    
    [PunRPC]
    public void PickedupObjectMessage(int viewId, String playerName)
    {
        Transform objectPickedUp = PhotonView.Find(viewId).transform;
        playerInteractionText.text = playerName + " picked up " + objectPickedUp.name + ".";
        playerInteractionText.enabled = true;
        StartCoroutine(RemovePlayerInteractionText());

        IEnumerator RemovePlayerInteractionText()
        {
            yield return new WaitForSeconds(4f);

            playerInteractionText.enabled = false;
        }
    }

    [PunRPC]
    public void UpdateHeldObject(int viewId)
    {
        Transform tempHold = PhotonView.Find(viewId).transform;
        objectHolding = tempHold;
    }
    
    public void OnDropObject()
    {
        if (holdingObject && PlayerInput.playerInput.controls.PlayerControls.DropObject.triggered)
        {
            holdingObject = false;
            photonView.RPC("DropObject", RpcTarget.All, objectHolding.GetComponent<PhotonView>().ViewID,
                objectHolding.transform.position, objectHolding.transform.rotation);
        }
    }

    [PunRPC]
    public void DropObject(int viewId, Vector3 position, Quaternion rotation)
    {
        Transform tempHold = PhotonView.Find(viewId).transform;
        
        tempHold.GetComponent<MeshRenderer>().material = defaultMaterial;
        Color currentColor = tempHold.GetChild(0).GetComponent<TextMeshPro>().color;
        tempHold.GetChild(0).GetComponent<TextMeshPro>().color = new Color(currentColor.r, currentColor.g, currentColor.b, a: 1.0f);
        
        tempHold.parent = null;
        tempHold.GetComponent<Rigidbody>().useGravity = true;
        tempHold.GetComponent<MeshCollider>().isTrigger = false;
        tempHold.transform.position = position;
        tempHold.transform.rotation = rotation;
    }

    [PunRPC]
    public void PickupObject(int viewId)
    {
        Transform tempHold = PhotonView.Find(viewId).transform;
        GameObject childGameObject = gameObject.transform.GetChild(0).gameObject;
        Color currentColor = tempHold.GetChild(0).GetComponent<TextMeshPro>().color;
        tempHold.GetChild(0).GetComponent<TextMeshPro>().color = new Color(currentColor.r, currentColor.g, currentColor.b, a: 150/255f);


        tempHold.GetComponent<MeshRenderer>().material = pickedupMaterial;
        tempHold.position = childGameObject.transform.position;
        tempHold.rotation = childGameObject.transform.rotation;
        tempHold.parent = childGameObject.transform;
        tempHold.GetComponent<Rigidbody>().useGravity = false;
        tempHold.GetComponent<MeshCollider>().isTrigger = true;
    }
}