using Photon.Pun;
using Photon.Realtime;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviourPun
{
    [Header("Players")]
    public string playerPrefabLocation;
    public PlayerController[] players;
    public Transform[] spawnPoints;
    public int alivePlayers;
    
    private static bool[] letterPlaced = {false,false,false,false,false};
    private static bool wordMade = false;

    public bool WordMade
    {
        get => wordMade;
        set => wordMade = value;
    }

    public bool[] LetterPlaced
    {
        get => letterPlaced;
        set => letterPlaced = value;
    }
    
    private int playersInGame;

// instance
    public static GameManager instance;

    void Awake ()
    {
        instance = this;
    }
    
    void Start ()
    {
        players = new PlayerController[PhotonNetwork.PlayerList.Length];
        alivePlayers = players.Length;

        photonView.RPC("ImInGame", RpcTarget.AllBuffered);
    }
    
    [PunRPC]
    void ImInGame ()
    {
        playersInGame++;

        if(PhotonNetwork.IsMasterClient && playersInGame == PhotonNetwork.PlayerList.Length)
            photonView.RPC("SpawnPlayer", RpcTarget.All);
    }
    
    [PunRPC]
    void SpawnPlayer ()
    {
        GameObject playerObj = PhotonNetwork.Instantiate(playerPrefabLocation, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
        if (playerObj.GetComponent<PlayerController>().id == 0)
        {
            playerObj.transform.position = spawnPoints[0].transform.position;
        }
        else if (playerObj.GetComponent<PlayerController>().id == 1)
        {
            playerObj.transform.position = spawnPoints[1].transform.position;
        }

        // initialize the player for all other players
        playerObj.GetComponent<PlayerController>().photonView.RPC("Initialize", RpcTarget.All, PhotonNetwork.LocalPlayer);
    
    }
    
    public PlayerController GetPlayer (int playerId)
    {
        return players.First(x => x.id == playerId);
    }

    public PlayerController GetPlayer (GameObject playerObject)
    {
        return players.First(x => x.gameObject == playerObject);
    }
}
