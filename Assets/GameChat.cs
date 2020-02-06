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

    private void Awake()
    {
       
    }

    [PunRPC]
    public void OpenChat()
    {
        panel.SetActive(true);
    }

    public void CloseChat()
    {
        panel.SetActive(false);
    }

    public void AmendChat()
    {
        photonView.RPC("SendMessage", RpcTarget.Others, messageToSend.text);
        photonView.RPC("OpenChat", RpcTarget.Others);
    }

    [PunRPC]
    public void SendChatMessage(String message)
    {
        chatText.text += "\n";
        chatText.text += message;

    }
}
