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
    public GameObject mainMenu;

    public static NetworkManager instance;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        BeginConnecting();
    }

    public void BeginConnecting()
    {
        if (Input.anyKeyDown && !PhotonNetwork.IsConnected)
        {
            print("Key pressed");
            connectionStatusText.SetText("Connecting to server...");
            ConnectToMasterServer();
        }
    }

    private void Start()
    {
    }

    public void ConnectToMasterServer()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        print("Connected to master server.");
        serverConnectScreen.SetActive(false);
        mainMenu.SetActive(true);
        connectionStatusText.SetText("Connected!");
    }
}
