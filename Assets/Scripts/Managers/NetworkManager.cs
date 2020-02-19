using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    public int maxPlayers = 4;
    public TextMeshProUGUI connectionStatusText;
    public GameObject serverConnectScreen;
    public GameObject mainMenuScreen;
    public GameObject secondMenuScreen;

    public static NetworkManager instance;

    private void Awake()
    {
        //DontDestroyOnLoad(gameObject);
/*        GameObject oldGameObject = GameObject.Find(gameObject.name);

        if (oldGameObject && oldGameObject != gameObject)
        {
            Destroy(oldGameObject);
        }*/
        instance = this;
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

    [PunRPC]
    public void ChangeScene (string sceneName)
    {
        PhotonNetwork.LoadLevel(sceneName);
    }

}
