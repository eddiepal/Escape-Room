using System;
using System.Collections;
using Photon.Pun;
using TMPro;
using UnityEngine;

internal class HighlightSelectionResponse : MonoBehaviourPun, ISelectionResponse
{
    [SerializeField] private Material defaultMaterial;
    [SerializeField] private Material highlightMaterial;

    public Transform objectHolding;
    private bool holdingObject = false;

    public Transform theSelection;
    [Range(0, 255)]
    [SerializeField] private float pickupTransparency = 100f;

    [SerializeField] private TextMeshProUGUI playerInteractionText;

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
        if (holdingObject && PlayerInput.playerInput.controls.PlayerControls.DropObject.triggered)
        {
            holdingObject = false;
            photonView.RPC("UpdateObjectComponents", RpcTarget.All, objectHolding.GetComponent<PhotonView>().ViewID,
                objectHolding.transform.position, objectHolding.transform.rotation);
        }
    }

    [PunRPC]
    public void UpdateObjectComponents(int viewId, Vector3 position, Quaternion rotation)
    {
        Transform tempHold = PhotonView.Find(viewId).transform;
        
        ChangePickupMaterial(tempHold, 255f);
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

        ChangePickupMaterial(tempHold, pickupTransparency);
        tempHold.position = childGameObject.transform.position;
        tempHold.rotation = childGameObject.transform.rotation;
        tempHold.parent = childGameObject.transform;
        tempHold.GetComponent<Rigidbody>().useGravity = false;
        tempHold.GetComponent<MeshCollider>().isTrigger = true;
    }

    public void ChangePickupMaterial(Transform tempHold, float aValue)
    {
        Color pickupColor = tempHold.GetComponent<MeshRenderer>().material.color;
        Color letterColor = tempHold.GetChild(0).GetComponent<TextMeshPro>().color;
        tempHold.GetComponent<MeshRenderer>().material.color = new Color(pickupColor.r, pickupColor.g, pickupColor.b, aValue/255f);
        tempHold.GetChild(0).GetComponent<TextMeshPro>().color = new Color(letterColor.r, letterColor.g, letterColor.b, aValue/255f);
    }
}