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
    
    [Header("GameChat Panel Children Components")]
    [SerializeField] private GameObject inputField;
    [SerializeField] GameObject sendMessageButton;
    
    public static bool chatIsOpen = false;
    private bool isTyping = false;

    private void Awake()
    {
        Debug.Log("In awake method of game chat class");

        PlayerInput.playerInput.controls.PauseMenu.OpenChatPanel.performed += ctx => OpenChat();
        PlayerInput.playerInput.controls.PauseMenu.SendChatMessage.performed += ctx => AmendChat();

    }

    [PunRPC]
    public void OpenChat()
    {
        if (!chatIsOpen)
        {
            Cursor.lockState = CursorLockMode.None;
            PlayerInput.playerInput.DisablePlayerControls();
            panel.SetActive(true);
            inputField.SetActive(true);
            sendMessageButton.SetActive(true);
            chatIsOpen = true;
        }
        else if (chatIsOpen && !isTyping)
        {
            Cursor.lockState = CursorLockMode.Locked;
            PlayerInput.playerInput.EnablePlayerControls();
            panel.SetActive(false);
            chatIsOpen = false;
        }
    }

    [PunRPC]
    public void OpenOtherPlayersChat()
    {
        if(!chatIsOpen)
        {
            panel.SetActive(true);
            inputField.SetActive(false);
            sendMessageButton.SetActive(false);
        }
    }

    public void AmendChat()
    {
        if(messageToSend.text == "")
            return;
        
        String localPlayerNickName = PhotonNetwork.LocalPlayer.NickName;

        photonView.RPC("SendChatMessage", RpcTarget.All, messageToSend.text, localPlayerNickName);
        photonView.RPC("OpenOtherPlayersChat", RpcTarget.Others);
        messageToSend.text = "";
    }

    [PunRPC]
    public void SendChatMessage(String message, String localPlayerNickName, PhotonMessageInfo info)
    {
        if (PhotonNetwork.LocalPlayer.ActorNumber == info.Sender.ActorNumber)
        {
            localPlayerNickName += " (Me)";
        }
        
        chatText.text += "\n";
        chatText.text += localPlayerNickName + ": " + message;
        
       if(chatText.GetComponent<TextMeshProUGUI>().isTextOverflowing)
       {
           RectTransform rt = chatText.rectTransform;
           rt.sizeDelta += new Vector2(0, 25);
       }
    }

    public void TypingStatus(bool typing)
    {
        isTyping = typing;
    }
}
