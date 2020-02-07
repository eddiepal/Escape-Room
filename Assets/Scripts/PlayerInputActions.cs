// GENERATED AUTOMATICALLY FROM 'Assets/PlayerInputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""Player Controls"",
            ""id"": ""48c694a8-785a-4b7c-b9a0-be9830fa3598"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""1d56842a-16ed-4e75-827f-4692bd2f58f0"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveCamera"",
                    ""type"": ""PassThrough"",
                    ""id"": ""246cfc00-a13f-4c19-b9ea-de293d3ef450"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""be98a29c-8633-4802-a97f-ed2267ef9233"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pickup Object"",
                    ""type"": ""Button"",
                    ""id"": ""846cf032-16b8-441a-acb6-ae2145ad00cd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Drop Object"",
                    ""type"": ""Button"",
                    ""id"": ""844cc8eb-9d0f-4ec7-891d-18b53de486b0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ConnectToServer"",
                    ""type"": ""Button"",
                    ""id"": ""6af9a8a4-41e9-4f05-9bd1-132e539eacb8"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""a4bad381-d53c-4247-9b1b-a342f57ecd70"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""78bea708-e1b2-489d-85f1-e8c97606eb36"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""125d7835-ab28-4e76-964d-25e4cc707272"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""a48bdbad-1c10-440a-a1fc-bcde66849a2e"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""e48eedfb-df69-47ae-9d23-4a3f1f69eae8"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""8a404a34-1653-4f02-94ce-e08095346371"",
                    ""path"": ""<XInputController>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox Controller"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""36a51dfc-1ab4-4e14-a848-734a154a13a8"",
                    ""path"": ""<XInputController>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox Controller"",
                    ""action"": ""MoveCamera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6deef23d-0e98-47c2-bd3f-0625b0ca0bae"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3b6dddfb-51c3-46c2-8f3c-c5eb7baa3a1b"",
                    ""path"": ""<XInputController>/buttonSouth"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Xbox Controller"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""77df5eb8-a0ed-4294-9624-3918739ec3ae"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pickup Object"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f61907f9-4210-4cc6-9d4b-a84a55a02ecf"",
                    ""path"": ""<XInputController>/leftTrigger"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Xbox Controller"",
                    ""action"": ""Pickup Object"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""64960857-ff98-4448-8603-f563d70d3381"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Drop Object"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""388582fc-9a86-46cf-8317-51f0414a66b3"",
                    ""path"": ""<XInputController>/rightTrigger"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Xbox Controller"",
                    ""action"": ""Drop Object"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""472a2c1f-078e-40bf-873c-e6decaf43699"",
                    ""path"": ""<Keyboard>/anyKey"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ConnectToServer"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""77769907-4d29-4aa3-a4f8-56ca28d9133f"",
                    ""path"": ""<XInputController>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox Controller"",
                    ""action"": ""ConnectToServer"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c18611fe-84b1-4ef2-ae6d-cd2ca699991c"",
                    ""path"": ""<XInputController>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ConnectToServer"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1f02fdfc-c04a-428c-9926-5cf92d4ab941"",
                    ""path"": ""<Mouse>/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ConnectToServer"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Pause Menu"",
            ""id"": ""df24df8b-8934-4773-8250-622a615b955e"",
            ""actions"": [
                {
                    ""name"": ""Pause Game"",
                    ""type"": ""Button"",
                    ""id"": ""30fe71db-e3b0-4120-bf1b-350403c927ea"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""OpenChatPanel"",
                    ""type"": ""Button"",
                    ""id"": ""4db20601-e943-4606-a84c-a3bb2ef71b26"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SendChatMessage"",
                    ""type"": ""Button"",
                    ""id"": ""7771d4d7-003c-4b27-acfd-cb53ce3f582a"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ccc1ea3b-89af-4d70-ad06-b7db4e273eed"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause Game"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b0699ffc-eec0-4003-9dde-43db68974f86"",
                    ""path"": ""<XInputController>/start"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Xbox Controller"",
                    ""action"": ""Pause Game"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""26458f4c-ca38-4846-be0c-67fe446f62cc"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Xbox Controller"",
                    ""action"": ""Pause Game"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0de21925-6a17-424a-b787-1167178d2bfe"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OpenChatPanel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7657704a-9b5a-4801-bbb3-55fff4bfbade"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SendChatMessage"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Xbox Controller"",
            ""bindingGroup"": ""Xbox Controller"",
            ""devices"": [
                {
                    ""devicePath"": ""<XInputController>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player Controls
        m_PlayerControls = asset.FindActionMap("Player Controls", throwIfNotFound: true);
        m_PlayerControls_Move = m_PlayerControls.FindAction("Move", throwIfNotFound: true);
        m_PlayerControls_MoveCamera = m_PlayerControls.FindAction("MoveCamera", throwIfNotFound: true);
        m_PlayerControls_Jump = m_PlayerControls.FindAction("Jump", throwIfNotFound: true);
        m_PlayerControls_PickupObject = m_PlayerControls.FindAction("Pickup Object", throwIfNotFound: true);
        m_PlayerControls_DropObject = m_PlayerControls.FindAction("Drop Object", throwIfNotFound: true);
        m_PlayerControls_ConnectToServer = m_PlayerControls.FindAction("ConnectToServer", throwIfNotFound: true);
        // Pause Menu
        m_PauseMenu = asset.FindActionMap("Pause Menu", throwIfNotFound: true);
        m_PauseMenu_PauseGame = m_PauseMenu.FindAction("Pause Game", throwIfNotFound: true);
        m_PauseMenu_OpenChatPanel = m_PauseMenu.FindAction("OpenChatPanel", throwIfNotFound: true);
        m_PauseMenu_SendChatMessage = m_PauseMenu.FindAction("SendChatMessage", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Player Controls
    private readonly InputActionMap m_PlayerControls;
    private IPlayerControlsActions m_PlayerControlsActionsCallbackInterface;
    private readonly InputAction m_PlayerControls_Move;
    private readonly InputAction m_PlayerControls_MoveCamera;
    private readonly InputAction m_PlayerControls_Jump;
    private readonly InputAction m_PlayerControls_PickupObject;
    private readonly InputAction m_PlayerControls_DropObject;
    private readonly InputAction m_PlayerControls_ConnectToServer;
    public struct PlayerControlsActions
    {
        private @PlayerInputActions m_Wrapper;
        public PlayerControlsActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_PlayerControls_Move;
        public InputAction @MoveCamera => m_Wrapper.m_PlayerControls_MoveCamera;
        public InputAction @Jump => m_Wrapper.m_PlayerControls_Jump;
        public InputAction @PickupObject => m_Wrapper.m_PlayerControls_PickupObject;
        public InputAction @DropObject => m_Wrapper.m_PlayerControls_DropObject;
        public InputAction @ConnectToServer => m_Wrapper.m_PlayerControls_ConnectToServer;
        public InputActionMap Get() { return m_Wrapper.m_PlayerControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerControlsActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerControlsActions instance)
        {
            if (m_Wrapper.m_PlayerControlsActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMove;
                @MoveCamera.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMoveCamera;
                @MoveCamera.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMoveCamera;
                @MoveCamera.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMoveCamera;
                @Jump.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnJump;
                @PickupObject.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnPickupObject;
                @PickupObject.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnPickupObject;
                @PickupObject.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnPickupObject;
                @DropObject.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnDropObject;
                @DropObject.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnDropObject;
                @DropObject.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnDropObject;
                @ConnectToServer.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnConnectToServer;
                @ConnectToServer.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnConnectToServer;
                @ConnectToServer.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnConnectToServer;
            }
            m_Wrapper.m_PlayerControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @MoveCamera.started += instance.OnMoveCamera;
                @MoveCamera.performed += instance.OnMoveCamera;
                @MoveCamera.canceled += instance.OnMoveCamera;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @PickupObject.started += instance.OnPickupObject;
                @PickupObject.performed += instance.OnPickupObject;
                @PickupObject.canceled += instance.OnPickupObject;
                @DropObject.started += instance.OnDropObject;
                @DropObject.performed += instance.OnDropObject;
                @DropObject.canceled += instance.OnDropObject;
                @ConnectToServer.started += instance.OnConnectToServer;
                @ConnectToServer.performed += instance.OnConnectToServer;
                @ConnectToServer.canceled += instance.OnConnectToServer;
            }
        }
    }
    public PlayerControlsActions @PlayerControls => new PlayerControlsActions(this);

    // Pause Menu
    private readonly InputActionMap m_PauseMenu;
    private IPauseMenuActions m_PauseMenuActionsCallbackInterface;
    private readonly InputAction m_PauseMenu_PauseGame;
    private readonly InputAction m_PauseMenu_OpenChatPanel;
    private readonly InputAction m_PauseMenu_SendChatMessage;
    public struct PauseMenuActions
    {
        private @PlayerInputActions m_Wrapper;
        public PauseMenuActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @PauseGame => m_Wrapper.m_PauseMenu_PauseGame;
        public InputAction @OpenChatPanel => m_Wrapper.m_PauseMenu_OpenChatPanel;
        public InputAction @SendChatMessage => m_Wrapper.m_PauseMenu_SendChatMessage;
        public InputActionMap Get() { return m_Wrapper.m_PauseMenu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PauseMenuActions set) { return set.Get(); }
        public void SetCallbacks(IPauseMenuActions instance)
        {
            if (m_Wrapper.m_PauseMenuActionsCallbackInterface != null)
            {
                @PauseGame.started -= m_Wrapper.m_PauseMenuActionsCallbackInterface.OnPauseGame;
                @PauseGame.performed -= m_Wrapper.m_PauseMenuActionsCallbackInterface.OnPauseGame;
                @PauseGame.canceled -= m_Wrapper.m_PauseMenuActionsCallbackInterface.OnPauseGame;
                @OpenChatPanel.started -= m_Wrapper.m_PauseMenuActionsCallbackInterface.OnOpenChatPanel;
                @OpenChatPanel.performed -= m_Wrapper.m_PauseMenuActionsCallbackInterface.OnOpenChatPanel;
                @OpenChatPanel.canceled -= m_Wrapper.m_PauseMenuActionsCallbackInterface.OnOpenChatPanel;
                @SendChatMessage.started -= m_Wrapper.m_PauseMenuActionsCallbackInterface.OnSendChatMessage;
                @SendChatMessage.performed -= m_Wrapper.m_PauseMenuActionsCallbackInterface.OnSendChatMessage;
                @SendChatMessage.canceled -= m_Wrapper.m_PauseMenuActionsCallbackInterface.OnSendChatMessage;
            }
            m_Wrapper.m_PauseMenuActionsCallbackInterface = instance;
            if (instance != null)
            {
                @PauseGame.started += instance.OnPauseGame;
                @PauseGame.performed += instance.OnPauseGame;
                @PauseGame.canceled += instance.OnPauseGame;
                @OpenChatPanel.started += instance.OnOpenChatPanel;
                @OpenChatPanel.performed += instance.OnOpenChatPanel;
                @OpenChatPanel.canceled += instance.OnOpenChatPanel;
                @SendChatMessage.started += instance.OnSendChatMessage;
                @SendChatMessage.performed += instance.OnSendChatMessage;
                @SendChatMessage.canceled += instance.OnSendChatMessage;
            }
        }
    }
    public PauseMenuActions @PauseMenu => new PauseMenuActions(this);
    private int m_XboxControllerSchemeIndex = -1;
    public InputControlScheme XboxControllerScheme
    {
        get
        {
            if (m_XboxControllerSchemeIndex == -1) m_XboxControllerSchemeIndex = asset.FindControlSchemeIndex("Xbox Controller");
            return asset.controlSchemes[m_XboxControllerSchemeIndex];
        }
    }
    public interface IPlayerControlsActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnMoveCamera(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnPickupObject(InputAction.CallbackContext context);
        void OnDropObject(InputAction.CallbackContext context);
        void OnConnectToServer(InputAction.CallbackContext context);
    }
    public interface IPauseMenuActions
    {
        void OnPauseGame(InputAction.CallbackContext context);
        void OnOpenChatPanel(InputAction.CallbackContext context);
        void OnSendChatMessage(InputAction.CallbackContext context);
    }
}
