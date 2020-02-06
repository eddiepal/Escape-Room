using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using TMPro;
using UnityEngine;

public class GameChat : MonoBehaviourPun
{
    [SerializeField] private GameObject panel;
    [SerializeField] private TextMeshProUGUI chatText;
    [SerializeField] private TMP_InputField messageToSend;
    
    public static bool chatIsOpen = false;

    private void Awake()
    {
        Debug.Log("In awake method of game chat class");

        PlayerInput.playerInput.controls.PauseMenu.OpenChatPanel.performed += ctx => OpenChat();
    }

    [PunRPC]
    public void OpenChat()
    {
        if (!chatIsOpen)
        {
            Cursor.lockState = CursorLockMode.None;
            PlayerInput.playerInput.DisablePlayerControls();
            panel.SetActive(true);
            chatIsOpen = true;
        }
        else if (chatIsOpen)
        {
            Cursor.lockState = CursorLockMode.Locked;
            PlayerInput.playerInput.EnablePlayerControls();
            panel.SetActive(false);
            chatIsOpen = false;
        }
    }

    public void AmendChat()
    {
        photonView.RPC("SendChatMessage", RpcTarget.All, messageToSend.text);
        photonView.RPC("OpenChat", RpcTarget.Others);
    }

    [PunRPC]
    public void SendChatMessage(String message)
    {
        chatText.text += "\n";
        chatText.text += PhotonNetwork.LocalPlayer.NickName + ": " + message;

    }
}
