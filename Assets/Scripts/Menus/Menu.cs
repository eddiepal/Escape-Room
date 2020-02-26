using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Menu : MonoBehaviourPunCallbacks, ILobbyCallbacks
{
    #region GlobalVariables

    public GameObject firstSelection;
    [SerializeField] private GameObject onScreenKeyboard;

    [Header("Screens")] 
    public GameObject createRoomScreen;
    public GameObject lobbyScreen;
    public GameObject lobbyBrowserScreen;
    public GameObject serverConnectScreen;
    public GameObject mainMenuScreen;
    public GameObject secondMenuScreen;
    public GameObject currentScreen;

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
    
    private static TMP_InputField _selectedInputField;
    private bool _testBool = false;
    private bool _keyboardKeyPressed = false;

    public static Menu instance;

    #endregion

    #region Properties

    public TMP_InputField SelectedInputField
    {
        get => _selectedInputField;
        set => _selectedInputField = value;
    }

    #endregion

    #region Awake_Start_Update

    void Start()
    {
        PlayerInput.playerInput.controls.PauseMenu.OpenKeyboard.performed += ctx => OpenOnScreenKeyboard();
        PlayerInput.playerInput.DisablePlayerControls();
        
        instance = this;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        PauseMenu.gamePaused = false;

        if (PhotonNetwork.InRoom)
        {
            PhotonNetwork.CurrentRoom.IsVisible = true;
            PhotonNetwork.CurrentRoom.IsOpen = true;
        }
    }

    private void Update()
    {
        if (PlayerInput.playerInput.controls.PauseMenu.ConnectToServer.triggered && !PhotonNetwork.IsConnected)
        {
            EventSystem.current.SetSelectedGameObject(null);
            ConnectToMasterServer();
        }
        
        {
            if (EventSystem.current.currentSelectedGameObject != null && _testBool == true)
            {
                StartCoroutine(WaitAFrame());

                if (EventSystem.current.currentSelectedGameObject.GetComponent<TMP_InputField>() != null &&
                    _keyboardKeyPressed)
                {
                    onScreenKeyboard.SetActive(true);
                    onScreenKeyboard.transform.GetChild(0).GetChild(0).GetComponent<Button>().Select();
                }
            }

            if (PlayerInput.playerInput.controls.PauseMenu.CloseKeyboard.triggered)
            {
                //onScreenKeyboard.SetActive(false);
                _testBool = false;
                _keyboardKeyPressed = false;
                SetScreen(currentScreen);
            }
        }
    }

    #endregion

    #region OnScreenKeyboard

    public void OpenOnScreenKeyboard()
    {
        var allGamepads = Gamepad.all;
        var gamepad = Gamepad.current;
        Debug.Log(allGamepads);
        if (gamepad != null && EventSystem.current.currentSelectedGameObject != null)
        {
            Debug.Log("Current gamepad name: " + gamepad.name);
            if (EventSystem.current.currentSelectedGameObject.GetComponent<TMP_InputField>() != null)
            {
                _keyboardKeyPressed = true;
            }
        }
    }
    
    IEnumerator MoveTextEnd_NextFrame(TMP_InputField inputField)
    {
        yield return 0; // Skip the first frame in which this is called.
        inputField.DeactivateInputField();
        _testBool = true;
        //inputField.MoveTextEnd(false); // Do this during the next frame.
    }
    IEnumerator WaitAFrame()
    {
        yield return 0;
    }

    #endregion
    
    #region MenuButtonCallbacks

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
    
    public void OnStartGameButton()
    {
        PhotonNetwork.CurrentRoom.IsOpen = false;
        PhotonNetwork.CurrentRoom.IsVisible = false;

        //change the scene for everyone using rpc
        NetworkManager.instance.photonView.RPC("ChangeScene", RpcTarget.All, "Level1");
        PlayerInput.playerInput.EnablePlayerControls();
        Debug.Log("passed test");
    }

    public void OnLeaveLobbyButton()
    {
        PhotonNetwork.LeaveRoom();
        SetScreen(mainMenuScreen);
        mainMenuScreen.transform.GetChild(0).GetChild(0).GetComponent<Button>().Select();
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
        UpdateLobbyBrowserUserInterface();
    }

    #endregion

    #region PunCallbacks

    public override void OnConnectedToMaster()
    {
        print("Connected to master server.");
        PhotonNetwork.JoinLobby();
        serverConnectScreen.SetActive(false);
        mainMenuScreen.SetActive(true);
        mainMenuScreen.transform.GetChild(0).GetChild(0).GetComponent<Button>().Select();
    }
    
    public override void OnJoinedRoom()
    {
        Debug.Log("In OnJoinedRoom method");
        SetScreen(lobbyScreen);
        photonView.RPC("UpdateLobbyUserInterface", RpcTarget.All);
    }
    
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        UpdateLobbyUserInterface();
    }

    #endregion
    
    public void SetScreen(GameObject screen)
    {
        if(mainMenuScreen == null)
            return;
        mainMenuScreen.SetActive(false);
        createRoomScreen.SetActive(false);
        lobbyScreen.SetActive(false);
        lobbyBrowserScreen.SetActive(false);
        secondMenuScreen.SetActive(false);
        onScreenKeyboard.SetActive(false);
        screen.SetActive(true);
        currentScreen = screen;
        if (screen == lobbyBrowserScreen)
        {
            UpdateLobbyBrowserUserInterface();    
        }
        
        if(screen.transform.GetChild(0).GetChild(0).GetComponent<Button>())
            screen.transform.GetChild(0).GetChild(0).GetComponent<Button>().Select();

        if (screen.transform.GetChild(0).GetChild(0).GetComponent<TMP_InputField>())
        {
            screen.transform.GetChild(0).GetChild(0).GetComponent<TMP_InputField>().Select();
            SelectedInputField = screen.transform.GetChild(0).GetChild(0).GetComponent<TMP_InputField>();
        }
    }
    
    public void OnSelect(TMP_InputField inputField)
    {
        StartCoroutine(MoveTextEnd_NextFrame(inputField));
    }
    
    public void OnPlayerNameValueChanged(TMP_InputField playerNameInput)
    {
        PhotonNetwork.NickName = playerNameInput.text;
    }
    
    public void ConnectToMasterServer()
    {
        print("Key pressed");
        connectionStatusText.SetText("Connecting to server...");
        PhotonNetwork.ConnectUsingSettings();
    }
    
    [PunRPC]
    void UpdateLobbyUserInterface()
    {
        //if this player is the host of the game then they can start the game
        startGameButton.interactable = PhotonNetwork.IsMasterClient;

        playerListText.text = "";
        foreach (Player player in PhotonNetwork.PlayerList)
            playerListText.text += player.NickName + "\n";

        roomInfoText.text = "\n<b>Room Name</b>\n" + PhotonNetwork.CurrentRoom.Name;
    }

    void UpdateLobbyBrowserUserInterface()
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


}