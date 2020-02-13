using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Menu : MonoBehaviourPunCallbacks, ILobbyCallbacks
{
    public GameObject firstSelection;

    [Header("Screens")] 
    public GameObject createRoomScreen;
    public GameObject lobbyScreen;
    public GameObject lobbyBrowserScreen;
    public GameObject serverConnectScreen;
    public GameObject mainMenuScreen;
    public GameObject secondMenuScreen;

    [Header("Main Menu")] 
    public Button secondScreenButton;

    [Header("Main Screen")] 
    public Button createRoomButton;
    public Button findRoomButton;

    [Tooltip("Status of the connection to the master server")] [Header("Connection Screen")]
    public TextMeshProUGUI connectionStatusText;

    [Header("Lobby")] 
    public TextMeshProUGUI playerListText;
    public TextMeshProUGUI roomInfoText;
    public Button startGameButton;

    [Header("Lobby Browser")] 
    public RectTransform roomListContainer;
    public GameObject roomButtonPrefab;
    private List<GameObject> roomButtons = new List<GameObject>();
    private List<RoomInfo> roomList = new List<RoomInfo>();

    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;

        if (PhotonNetwork.InRoom)
        {
            PhotonNetwork.CurrentRoom.IsVisible = true;
            PhotonNetwork.CurrentRoom.IsOpen = true;
        }
    }

    private void Update()
    {
        if (PlayerInput.playerInput.controls.PlayerControls.ConnectToServer.triggered && !PhotonNetwork.IsConnected)
        {
            EventSystem.current.SetSelectedGameObject(null);
            ConnectToMasterServer();
        }
    }

    public void SetScreen(GameObject screen)
    {
        mainMenuScreen.SetActive(false);
        createRoomScreen.SetActive(false);
        lobbyScreen.SetActive(false);
        lobbyBrowserScreen.SetActive(false);
        secondMenuScreen.SetActive(false);
        screen.SetActive(true);
        if (screen == lobbyBrowserScreen)
        {
            UpdateLobbyBrowserUI();
            Debug.Log("in if statement");
        }
        
        if(screen.transform.GetChild(0).GetChild(0).GetComponent<Button>() != null)
            screen.transform.GetChild(0).GetChild(0).GetComponent<Button>().Select();

        if (screen.transform.GetChild(0).GetChild(0).GetComponent<TMP_InputField>() != null)
            screen.transform.GetChild(0).GetChild(0).GetComponent<TMP_InputField>().Select();
    }
    
    IEnumerator MoveTextEnd_NextFrame(TMP_InputField inputField)
    {
        yield return 0; // Skip the first frame in which this is called.
        inputField.DeactivateInputField();
        //inputField.MoveTextEnd(false); // Do this during the next frame.
    }

    
    public void OnSelect(TMP_InputField inputField)
    {
        StartCoroutine(MoveTextEnd_NextFrame(inputField));
    }
    
    public void OnPlayerNameValueChanged(TMP_InputField playerNameInput)
    {
        PhotonNetwork.NickName = playerNameInput.text;
    }

    public override void OnConnectedToMaster()
    {
        print("Connected to master server.");
        PhotonNetwork.JoinLobby();
        serverConnectScreen.SetActive(false);
        mainMenuScreen.SetActive(true);
        mainMenuScreen.transform.GetChild(0).GetChild(0).GetComponent<Button>().Select();
    }

    public void ConnectToMasterServer()
    {
        print("Key pressed");
        connectionStatusText.SetText("Connecting to server...");
        PhotonNetwork.ConnectUsingSettings();
    }


    public void OnCreateRoomButton()
    {
        SetScreen(createRoomScreen);
    }

    public void OnFindRoomButton()
    {
        SetScreen(lobbyBrowserScreen);
    }

    public void OnBackButton()
    {
        SetScreen(mainMenuScreen);
    }

    public void OnCreateButton(TMP_InputField roomNameInput)
    {
        Debug.Log("In OnCreateButton method");
        NetworkManager.instance.CreateRoom(roomNameInput.text);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("In OnJoinedRoom method");
        SetScreen(lobbyScreen);
        photonView.RPC("UpdateLobbyUI", RpcTarget.All);
    }

    [PunRPC]
    void UpdateLobbyUI()
    {
        //if this player is the host of the game then they can start the game
        startGameButton.interactable = PhotonNetwork.IsMasterClient;

        playerListText.text = "";
        foreach (Player player in PhotonNetwork.PlayerList)
            playerListText.text += player.NickName + "\n";

        roomInfoText.text = "\n<b>Room Name</b>\n" + PhotonNetwork.CurrentRoom.Name;
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        UpdateLobbyUI();
    }

    public void OnStartGameButton()
    {
        PhotonNetwork.CurrentRoom.IsOpen = false;
        PhotonNetwork.CurrentRoom.IsVisible = false;

        //change the scene for everyone using rpc
        NetworkManager.instance.photonView.RPC("ChangeScene", RpcTarget.All, "Level1");
    }

    public void OnLeaveLobbyButton()
    {
        PhotonNetwork.LeaveRoom();
        SetScreen(mainMenuScreen);
        mainMenuScreen.transform.GetChild(0).GetChild(0).GetComponent<Button>().Select();
    }

    void UpdateLobbyBrowserUI()
    {
        foreach (GameObject button in roomButtons)
            button.SetActive(false);
        
        Debug.Log("Room list count: " + roomList.Count);
        for (int x = 0; x < roomList.Count; ++x)
        {
            Debug.Log("In the for loop for updatelobbybrwoserui: " + roomButtons.Count);
            GameObject button = x >= roomButtons.Count
                ? CreateRoomButton()
                : roomButtons
                    [x];
            button.SetActive(true);


            button.transform.Find("RoomNameText").GetComponent<TextMeshProUGUI>().text =
                roomList[x].Name;
            button.transform.Find("PlayerCountText").GetComponent<TextMeshProUGUI>().text
                = roomList[x].PlayerCount + " / " + roomList[x].MaxPlayers;


            Button buttonComp = button.GetComponent<Button>();
            string roomName = roomList[x].Name;
            buttonComp.onClick.RemoveAllListeners();
            buttonComp.onClick.AddListener(() => { OnJoinRoomButton(roomName); });
        }
    }

    GameObject CreateRoomButton()
    {
        Debug.Log("in createroombutton method");
        GameObject buttonObj = Instantiate(roomButtonPrefab, roomListContainer.transform)
            ;
        roomButtons.Add(buttonObj);
        return buttonObj;
    }

    public void OnJoinRoomButton(string roomName)
    {
        NetworkManager.instance.JoinRoom(roomName);
    }

    public void OnRefreshButton()
    {
        UpdateLobbyBrowserUI();
    }

    public override void OnRoomListUpdate(List<RoomInfo> allRooms)
    {
        Debug.Log("In the OnRoomListUpdate override method");
        roomList = allRooms;
    }
}