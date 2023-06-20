//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/Scripts/Runtime/Gameplay/Shop/User/Input/UserInput.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @UserInput : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @UserInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""UserInput"",
    ""maps"": [
        {
            ""name"": ""Shop"",
            ""id"": ""42ae7b92-8a95-4627-b4f9-25e1c075b085"",
            ""actions"": [
                {
                    ""name"": ""Scroll"",
                    ""type"": ""PassThrough"",
                    ""id"": ""1fe2a04c-73a0-4cd9-9b3c-a597b4ae253b"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Buy"",
                    ""type"": ""Button"",
                    ""id"": ""afd8c0c2-2306-4e4d-b885-e63643836442"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""52796b67-2c9e-4399-a10d-84ef888ee0dd"",
                    ""path"": ""<Mouse>/scroll/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Scroll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ea4ee66b-9737-4eb3-8035-e4fb3a32d896"",
                    ""path"": ""<Gamepad>/leftStick/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Scroll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""16de83f8-e8f0-4d19-b3b3-57d698aaceb5"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Buy"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c98d911e-eb25-40a2-8c2b-41d6cb26d4c2"",
                    ""path"": ""<DualShockGamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Buy"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Game"",
            ""id"": ""ceb0f915-3b50-46a4-a320-56ed17df75f8"",
            ""actions"": [
                {
                    ""name"": ""Exit"",
                    ""type"": ""Button"",
                    ""id"": ""698308c4-e3bb-4a46-be13-d33fb3c833d5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""5a1ea97e-3057-4409-be82-d420c1d86025"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Exit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""12e04302-47c0-4668-af50-8cb5d0c88a35"",
                    ""path"": ""<XInputController>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Exit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4d75d7b5-4802-4c06-a712-a68eca0f75e9"",
                    ""path"": ""<XboxOneGamepadAndroid>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Exit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bb67e296-508a-41a1-b28b-bad9e0092e16"",
                    ""path"": ""<XboxOneGampadiOS>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Exit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4d74e85f-1a4d-4463-af70-d75333625d12"",
                    ""path"": ""<DualShockGamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Exit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""73fcb86c-9bf1-48f1-ad6b-f8ed5fee1885"",
                    ""path"": ""<DualSenseGamepadHID>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Exit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Game"",
            ""bindingGroup"": ""Game"",
            ""devices"": []
        }
    ]
}");
        // Shop
        m_Shop = asset.FindActionMap("Shop", throwIfNotFound: true);
        m_Shop_Scroll = m_Shop.FindAction("Scroll", throwIfNotFound: true);
        m_Shop_Buy = m_Shop.FindAction("Buy", throwIfNotFound: true);
        // Game
        m_Game = asset.FindActionMap("Game", throwIfNotFound: true);
        m_Game_Exit = m_Game.FindAction("Exit", throwIfNotFound: true);
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
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Shop
    private readonly InputActionMap m_Shop;
    private IShopActions m_ShopActionsCallbackInterface;
    private readonly InputAction m_Shop_Scroll;
    private readonly InputAction m_Shop_Buy;
    public struct ShopActions
    {
        private @UserInput m_Wrapper;
        public ShopActions(@UserInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Scroll => m_Wrapper.m_Shop_Scroll;
        public InputAction @Buy => m_Wrapper.m_Shop_Buy;
        public InputActionMap Get() { return m_Wrapper.m_Shop; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ShopActions set) { return set.Get(); }
        public void SetCallbacks(IShopActions instance)
        {
            if (m_Wrapper.m_ShopActionsCallbackInterface != null)
            {
                @Scroll.started -= m_Wrapper.m_ShopActionsCallbackInterface.OnScroll;
                @Scroll.performed -= m_Wrapper.m_ShopActionsCallbackInterface.OnScroll;
                @Scroll.canceled -= m_Wrapper.m_ShopActionsCallbackInterface.OnScroll;
                @Buy.started -= m_Wrapper.m_ShopActionsCallbackInterface.OnBuy;
                @Buy.performed -= m_Wrapper.m_ShopActionsCallbackInterface.OnBuy;
                @Buy.canceled -= m_Wrapper.m_ShopActionsCallbackInterface.OnBuy;
            }
            m_Wrapper.m_ShopActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Scroll.started += instance.OnScroll;
                @Scroll.performed += instance.OnScroll;
                @Scroll.canceled += instance.OnScroll;
                @Buy.started += instance.OnBuy;
                @Buy.performed += instance.OnBuy;
                @Buy.canceled += instance.OnBuy;
            }
        }
    }
    public ShopActions @Shop => new ShopActions(this);

    // Game
    private readonly InputActionMap m_Game;
    private IGameActions m_GameActionsCallbackInterface;
    private readonly InputAction m_Game_Exit;
    public struct GameActions
    {
        private @UserInput m_Wrapper;
        public GameActions(@UserInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Exit => m_Wrapper.m_Game_Exit;
        public InputActionMap Get() { return m_Wrapper.m_Game; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameActions set) { return set.Get(); }
        public void SetCallbacks(IGameActions instance)
        {
            if (m_Wrapper.m_GameActionsCallbackInterface != null)
            {
                @Exit.started -= m_Wrapper.m_GameActionsCallbackInterface.OnExit;
                @Exit.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnExit;
                @Exit.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnExit;
            }
            m_Wrapper.m_GameActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Exit.started += instance.OnExit;
                @Exit.performed += instance.OnExit;
                @Exit.canceled += instance.OnExit;
            }
        }
    }
    public GameActions @Game => new GameActions(this);
    private int m_GameSchemeIndex = -1;
    public InputControlScheme GameScheme
    {
        get
        {
            if (m_GameSchemeIndex == -1) m_GameSchemeIndex = asset.FindControlSchemeIndex("Game");
            return asset.controlSchemes[m_GameSchemeIndex];
        }
    }
    public interface IShopActions
    {
        void OnScroll(InputAction.CallbackContext context);
        void OnBuy(InputAction.CallbackContext context);
    }
    public interface IGameActions
    {
        void OnExit(InputAction.CallbackContext context);
    }
}
