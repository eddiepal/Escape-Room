using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEditor.Experimental.AssetImporters;
using UnityEngine;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    public int maxPlayers = 10;
    public TextMeshProUGUI connectionStatusText;
    public GameObject serverConnectScreen;
    public GameObject mainMenuScreen;
    public GameObject secondMenuScreen;

    public static NetworkManager instance;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void CreateRoom (string roomName)
    {
        RoomOptions options = new RoomOptions();
        options.MaxPlayers = (byte)maxPlayers;
        PhotonNetwork.CreateRoom(roomName, options);
    }

    public void JoinRoom (string roomName)
    {
        PhotonNetwork.JoinRoom(roomName);
    }
    
    public void goToSecondMenuScreen()
    {
        
    }
    
    public void ChangeScene (string sceneName)
    {
        PhotonNetwork.LoadLevel(sceneName);
    }

}
