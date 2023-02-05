//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/Input/Controls.inputactions
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

namespace Rootlesnake.Input
{
    public partial class @Controls : IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @Controls()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Root"",
            ""id"": ""f1f108cc-c1ef-45ac-878d-67eb51245c30"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""9bfc5491-099c-4589-aa34-3718b1dda655"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""1ac84d3e-1eba-455c-bae0-aa792806da7b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Start"",
                    ""type"": ""Button"",
                    ""id"": ""e7346dcb-276f-4297-b9b6-d47bd9f75c78"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ToMainMenu"",
                    ""type"": ""Button"",
                    ""id"": ""8442d63d-9464-444b-b9b0-97872adc223d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""UIDown"",
                    ""type"": ""Button"",
                    ""id"": ""812b8606-2b92-4618-95ca-82f6f6cae592"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""UIUp"",
                    ""type"": ""Button"",
                    ""id"": ""94a3a4b8-cd46-4f45-868d-4b065e1485e9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""49946645-9f71-49f6-9cd2-16012888ab24"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""781804d7-928c-4abf-97cb-ce83702b340f"",
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
                    ""id"": ""8fd99e9a-4139-4951-83ce-839324225aac"",
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
                    ""id"": ""72590376-ab4e-4e4c-8fd2-ca5848d538cd"",
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
                    ""id"": ""542b2c46-245b-437c-b222-ddb8d9484520"",
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
                    ""id"": ""0f39e184-a506-438d-ad08-3170719021cc"",
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
                    ""id"": ""6a39e152-53c4-48fa-af40-be2687a0e56e"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""44595eeb-a53c-4681-8e62-07bda5f05ee4"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6fdb8f2d-5a00-427f-bd8a-170833c2cd7d"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Start"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""026845f8-d636-4c08-80af-677527736ec2"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Start"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ea0fe319-bec8-440b-9bc4-36692117ec4d"",
                    ""path"": ""<Gamepad>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToMainMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a4afee6d-63f8-47f8-b609-2f650ec9998b"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToMainMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d47579dc-3906-44f2-8b48-0aee09373602"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UIDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""29a36df0-8d79-4887-bba9-d62a42161c77"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UIUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Debug"",
            ""id"": ""4b20f42b-4a7f-421b-ae63-3cef212f4d8b"",
            ""actions"": [
                {
                    ""name"": ""F1"",
                    ""type"": ""Button"",
                    ""id"": ""d246e01e-ef90-4438-9b07-454a6e56d62b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""F2"",
                    ""type"": ""Button"",
                    ""id"": ""e01c07d2-5def-4f8d-8a87-b48c9ed00ec8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""F3"",
                    ""type"": ""Button"",
                    ""id"": ""ed7e27cf-5f0c-4200-98bb-f71806d28224"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""F4"",
                    ""type"": ""Button"",
                    ""id"": ""e88d8446-7d4a-40a3-88ea-6a2bec532cf9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""F5"",
                    ""type"": ""Button"",
                    ""id"": ""899abf46-5193-4d30-bc17-5a73ec9fe833"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""F6"",
                    ""type"": ""Button"",
                    ""id"": ""a9dffa49-10a4-4034-9739-5e8d8ce2835e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""F7"",
                    ""type"": ""Button"",
                    ""id"": ""0e64ba42-033b-4e59-946a-1c2dd2a519df"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""F8"",
                    ""type"": ""Button"",
                    ""id"": ""c58c279a-0d33-4da8-96bd-5eb92e17030d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""F9"",
                    ""type"": ""Button"",
                    ""id"": ""58e0ae08-af61-4a56-b9a2-9889e59c9529"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""F10"",
                    ""type"": ""Button"",
                    ""id"": ""cffc53d2-5f8c-4b1f-b4ee-7f8e3d934f6f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""F11"",
                    ""type"": ""Button"",
                    ""id"": ""6b0b75a9-1222-4a7b-9827-b46db5e9f396"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""F12"",
                    ""type"": ""Button"",
                    ""id"": ""a1a2e64d-fea4-4bcf-b564-20d2ea064438"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""2d025f27-01fd-4bbe-894b-ffd877e8546f"",
                    ""path"": ""<Keyboard>/f1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""F1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6c08fbb0-b660-4f50-9a6c-cea4917bbafe"",
                    ""path"": ""<Keyboard>/f2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""F2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""237d2ad8-a625-492a-891d-8724d33607a9"",
                    ""path"": ""<Keyboard>/f3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""F3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""89ad8f38-242b-4dfe-99d4-06d11dc9ba7a"",
                    ""path"": ""<Keyboard>/f4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""F4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0f4cd88e-4099-4f14-a554-73a30ee89c5f"",
                    ""path"": ""<Keyboard>/f5"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""F5"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""24e003cc-5bdc-4a0d-a3a6-217b10e68483"",
                    ""path"": ""<Keyboard>/f6"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""F6"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5c2d9eda-f804-46c5-8edf-3861c0888461"",
                    ""path"": ""<Keyboard>/f7"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""F7"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a0a8a345-8d31-4253-95c5-f783a203df36"",
                    ""path"": ""<Keyboard>/f8"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""F8"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7a5b05a6-0acb-457e-9f3a-40da817d8192"",
                    ""path"": ""<Keyboard>/f9"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""F9"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a9358f58-1bab-4564-a1ef-72b5daa78eca"",
                    ""path"": ""<Keyboard>/f10"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""F10"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8c9fa1de-6d9a-428b-b6ea-7e54f2789fe5"",
                    ""path"": ""<Keyboard>/f11"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""F11"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""13822263-d0c9-4267-8f24-ef77cb9b5489"",
                    ""path"": ""<Keyboard>/f12"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""F12"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
            // Root
            m_Root = asset.FindActionMap("Root", throwIfNotFound: true);
            m_Root_Move = m_Root.FindAction("Move", throwIfNotFound: true);
            m_Root_Interact = m_Root.FindAction("Interact", throwIfNotFound: true);
            m_Root_Start = m_Root.FindAction("Start", throwIfNotFound: true);
            m_Root_ToMainMenu = m_Root.FindAction("ToMainMenu", throwIfNotFound: true);
            m_Root_UIDown = m_Root.FindAction("UIDown", throwIfNotFound: true);
            m_Root_UIUp = m_Root.FindAction("UIUp", throwIfNotFound: true);
            // Debug
            m_Debug = asset.FindActionMap("Debug", throwIfNotFound: true);
            m_Debug_F1 = m_Debug.FindAction("F1", throwIfNotFound: true);
            m_Debug_F2 = m_Debug.FindAction("F2", throwIfNotFound: true);
            m_Debug_F3 = m_Debug.FindAction("F3", throwIfNotFound: true);
            m_Debug_F4 = m_Debug.FindAction("F4", throwIfNotFound: true);
            m_Debug_F5 = m_Debug.FindAction("F5", throwIfNotFound: true);
            m_Debug_F6 = m_Debug.FindAction("F6", throwIfNotFound: true);
            m_Debug_F7 = m_Debug.FindAction("F7", throwIfNotFound: true);
            m_Debug_F8 = m_Debug.FindAction("F8", throwIfNotFound: true);
            m_Debug_F9 = m_Debug.FindAction("F9", throwIfNotFound: true);
            m_Debug_F10 = m_Debug.FindAction("F10", throwIfNotFound: true);
            m_Debug_F11 = m_Debug.FindAction("F11", throwIfNotFound: true);
            m_Debug_F12 = m_Debug.FindAction("F12", throwIfNotFound: true);
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

        // Root
        private readonly InputActionMap m_Root;
        private IRootActions m_RootActionsCallbackInterface;
        private readonly InputAction m_Root_Move;
        private readonly InputAction m_Root_Interact;
        private readonly InputAction m_Root_Start;
        private readonly InputAction m_Root_ToMainMenu;
        private readonly InputAction m_Root_UIDown;
        private readonly InputAction m_Root_UIUp;
        public struct RootActions
        {
            private @Controls m_Wrapper;
            public RootActions(@Controls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Move => m_Wrapper.m_Root_Move;
            public InputAction @Interact => m_Wrapper.m_Root_Interact;
            public InputAction @Start => m_Wrapper.m_Root_Start;
            public InputAction @ToMainMenu => m_Wrapper.m_Root_ToMainMenu;
            public InputAction @UIDown => m_Wrapper.m_Root_UIDown;
            public InputAction @UIUp => m_Wrapper.m_Root_UIUp;
            public InputActionMap Get() { return m_Wrapper.m_Root; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(RootActions set) { return set.Get(); }
            public void SetCallbacks(IRootActions instance)
            {
                if (m_Wrapper.m_RootActionsCallbackInterface != null)
                {
                    @Move.started -= m_Wrapper.m_RootActionsCallbackInterface.OnMove;
                    @Move.performed -= m_Wrapper.m_RootActionsCallbackInterface.OnMove;
                    @Move.canceled -= m_Wrapper.m_RootActionsCallbackInterface.OnMove;
                    @Interact.started -= m_Wrapper.m_RootActionsCallbackInterface.OnInteract;
                    @Interact.performed -= m_Wrapper.m_RootActionsCallbackInterface.OnInteract;
                    @Interact.canceled -= m_Wrapper.m_RootActionsCallbackInterface.OnInteract;
                    @Start.started -= m_Wrapper.m_RootActionsCallbackInterface.OnStart;
                    @Start.performed -= m_Wrapper.m_RootActionsCallbackInterface.OnStart;
                    @Start.canceled -= m_Wrapper.m_RootActionsCallbackInterface.OnStart;
                    @ToMainMenu.started -= m_Wrapper.m_RootActionsCallbackInterface.OnToMainMenu;
                    @ToMainMenu.performed -= m_Wrapper.m_RootActionsCallbackInterface.OnToMainMenu;
                    @ToMainMenu.canceled -= m_Wrapper.m_RootActionsCallbackInterface.OnToMainMenu;
                    @UIDown.started -= m_Wrapper.m_RootActionsCallbackInterface.OnUIDown;
                    @UIDown.performed -= m_Wrapper.m_RootActionsCallbackInterface.OnUIDown;
                    @UIDown.canceled -= m_Wrapper.m_RootActionsCallbackInterface.OnUIDown;
                    @UIUp.started -= m_Wrapper.m_RootActionsCallbackInterface.OnUIUp;
                    @UIUp.performed -= m_Wrapper.m_RootActionsCallbackInterface.OnUIUp;
                    @UIUp.canceled -= m_Wrapper.m_RootActionsCallbackInterface.OnUIUp;
                }
                m_Wrapper.m_RootActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Move.started += instance.OnMove;
                    @Move.performed += instance.OnMove;
                    @Move.canceled += instance.OnMove;
                    @Interact.started += instance.OnInteract;
                    @Interact.performed += instance.OnInteract;
                    @Interact.canceled += instance.OnInteract;
                    @Start.started += instance.OnStart;
                    @Start.performed += instance.OnStart;
                    @Start.canceled += instance.OnStart;
                    @ToMainMenu.started += instance.OnToMainMenu;
                    @ToMainMenu.performed += instance.OnToMainMenu;
                    @ToMainMenu.canceled += instance.OnToMainMenu;
                    @UIDown.started += instance.OnUIDown;
                    @UIDown.performed += instance.OnUIDown;
                    @UIDown.canceled += instance.OnUIDown;
                    @UIUp.started += instance.OnUIUp;
                    @UIUp.performed += instance.OnUIUp;
                    @UIUp.canceled += instance.OnUIUp;
                }
            }
        }
        public RootActions @Root => new RootActions(this);

        // Debug
        private readonly InputActionMap m_Debug;
        private IDebugActions m_DebugActionsCallbackInterface;
        private readonly InputAction m_Debug_F1;
        private readonly InputAction m_Debug_F2;
        private readonly InputAction m_Debug_F3;
        private readonly InputAction m_Debug_F4;
        private readonly InputAction m_Debug_F5;
        private readonly InputAction m_Debug_F6;
        private readonly InputAction m_Debug_F7;
        private readonly InputAction m_Debug_F8;
        private readonly InputAction m_Debug_F9;
        private readonly InputAction m_Debug_F10;
        private readonly InputAction m_Debug_F11;
        private readonly InputAction m_Debug_F12;
        public struct DebugActions
        {
            private @Controls m_Wrapper;
            public DebugActions(@Controls wrapper) { m_Wrapper = wrapper; }
            public InputAction @F1 => m_Wrapper.m_Debug_F1;
            public InputAction @F2 => m_Wrapper.m_Debug_F2;
            public InputAction @F3 => m_Wrapper.m_Debug_F3;
            public InputAction @F4 => m_Wrapper.m_Debug_F4;
            public InputAction @F5 => m_Wrapper.m_Debug_F5;
            public InputAction @F6 => m_Wrapper.m_Debug_F6;
            public InputAction @F7 => m_Wrapper.m_Debug_F7;
            public InputAction @F8 => m_Wrapper.m_Debug_F8;
            public InputAction @F9 => m_Wrapper.m_Debug_F9;
            public InputAction @F10 => m_Wrapper.m_Debug_F10;
            public InputAction @F11 => m_Wrapper.m_Debug_F11;
            public InputAction @F12 => m_Wrapper.m_Debug_F12;
            public InputActionMap Get() { return m_Wrapper.m_Debug; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(DebugActions set) { return set.Get(); }
            public void SetCallbacks(IDebugActions instance)
            {
                if (m_Wrapper.m_DebugActionsCallbackInterface != null)
                {
                    @F1.started -= m_Wrapper.m_DebugActionsCallbackInterface.OnF1;
                    @F1.performed -= m_Wrapper.m_DebugActionsCallbackInterface.OnF1;
                    @F1.canceled -= m_Wrapper.m_DebugActionsCallbackInterface.OnF1;
                    @F2.started -= m_Wrapper.m_DebugActionsCallbackInterface.OnF2;
                    @F2.performed -= m_Wrapper.m_DebugActionsCallbackInterface.OnF2;
                    @F2.canceled -= m_Wrapper.m_DebugActionsCallbackInterface.OnF2;
                    @F3.started -= m_Wrapper.m_DebugActionsCallbackInterface.OnF3;
                    @F3.performed -= m_Wrapper.m_DebugActionsCallbackInterface.OnF3;
                    @F3.canceled -= m_Wrapper.m_DebugActionsCallbackInterface.OnF3;
                    @F4.started -= m_Wrapper.m_DebugActionsCallbackInterface.OnF4;
                    @F4.performed -= m_Wrapper.m_DebugActionsCallbackInterface.OnF4;
                    @F4.canceled -= m_Wrapper.m_DebugActionsCallbackInterface.OnF4;
                    @F5.started -= m_Wrapper.m_DebugActionsCallbackInterface.OnF5;
                    @F5.performed -= m_Wrapper.m_DebugActionsCallbackInterface.OnF5;
                    @F5.canceled -= m_Wrapper.m_DebugActionsCallbackInterface.OnF5;
                    @F6.started -= m_Wrapper.m_DebugActionsCallbackInterface.OnF6;
                    @F6.performed -= m_Wrapper.m_DebugActionsCallbackInterface.OnF6;
                    @F6.canceled -= m_Wrapper.m_DebugActionsCallbackInterface.OnF6;
                    @F7.started -= m_Wrapper.m_DebugActionsCallbackInterface.OnF7;
                    @F7.performed -= m_Wrapper.m_DebugActionsCallbackInterface.OnF7;
                    @F7.canceled -= m_Wrapper.m_DebugActionsCallbackInterface.OnF7;
                    @F8.started -= m_Wrapper.m_DebugActionsCallbackInterface.OnF8;
                    @F8.performed -= m_Wrapper.m_DebugActionsCallbackInterface.OnF8;
                    @F8.canceled -= m_Wrapper.m_DebugActionsCallbackInterface.OnF8;
                    @F9.started -= m_Wrapper.m_DebugActionsCallbackInterface.OnF9;
                    @F9.performed -= m_Wrapper.m_DebugActionsCallbackInterface.OnF9;
                    @F9.canceled -= m_Wrapper.m_DebugActionsCallbackInterface.OnF9;
                    @F10.started -= m_Wrapper.m_DebugActionsCallbackInterface.OnF10;
                    @F10.performed -= m_Wrapper.m_DebugActionsCallbackInterface.OnF10;
                    @F10.canceled -= m_Wrapper.m_DebugActionsCallbackInterface.OnF10;
                    @F11.started -= m_Wrapper.m_DebugActionsCallbackInterface.OnF11;
                    @F11.performed -= m_Wrapper.m_DebugActionsCallbackInterface.OnF11;
                    @F11.canceled -= m_Wrapper.m_DebugActionsCallbackInterface.OnF11;
                    @F12.started -= m_Wrapper.m_DebugActionsCallbackInterface.OnF12;
                    @F12.performed -= m_Wrapper.m_DebugActionsCallbackInterface.OnF12;
                    @F12.canceled -= m_Wrapper.m_DebugActionsCallbackInterface.OnF12;
                }
                m_Wrapper.m_DebugActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @F1.started += instance.OnF1;
                    @F1.performed += instance.OnF1;
                    @F1.canceled += instance.OnF1;
                    @F2.started += instance.OnF2;
                    @F2.performed += instance.OnF2;
                    @F2.canceled += instance.OnF2;
                    @F3.started += instance.OnF3;
                    @F3.performed += instance.OnF3;
                    @F3.canceled += instance.OnF3;
                    @F4.started += instance.OnF4;
                    @F4.performed += instance.OnF4;
                    @F4.canceled += instance.OnF4;
                    @F5.started += instance.OnF5;
                    @F5.performed += instance.OnF5;
                    @F5.canceled += instance.OnF5;
                    @F6.started += instance.OnF6;
                    @F6.performed += instance.OnF6;
                    @F6.canceled += instance.OnF6;
                    @F7.started += instance.OnF7;
                    @F7.performed += instance.OnF7;
                    @F7.canceled += instance.OnF7;
                    @F8.started += instance.OnF8;
                    @F8.performed += instance.OnF8;
                    @F8.canceled += instance.OnF8;
                    @F9.started += instance.OnF9;
                    @F9.performed += instance.OnF9;
                    @F9.canceled += instance.OnF9;
                    @F10.started += instance.OnF10;
                    @F10.performed += instance.OnF10;
                    @F10.canceled += instance.OnF10;
                    @F11.started += instance.OnF11;
                    @F11.performed += instance.OnF11;
                    @F11.canceled += instance.OnF11;
                    @F12.started += instance.OnF12;
                    @F12.performed += instance.OnF12;
                    @F12.canceled += instance.OnF12;
                }
            }
        }
        public DebugActions @Debug => new DebugActions(this);
        private int m_GamepadSchemeIndex = -1;
        public InputControlScheme GamepadScheme
        {
            get
            {
                if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
                return asset.controlSchemes[m_GamepadSchemeIndex];
            }
        }
        private int m_KeyboardSchemeIndex = -1;
        public InputControlScheme KeyboardScheme
        {
            get
            {
                if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
                return asset.controlSchemes[m_KeyboardSchemeIndex];
            }
        }
        public interface IRootActions
        {
            void OnMove(InputAction.CallbackContext context);
            void OnInteract(InputAction.CallbackContext context);
            void OnStart(InputAction.CallbackContext context);
            void OnToMainMenu(InputAction.CallbackContext context);
            void OnUIDown(InputAction.CallbackContext context);
            void OnUIUp(InputAction.CallbackContext context);
        }
        public interface IDebugActions
        {
            void OnF1(InputAction.CallbackContext context);
            void OnF2(InputAction.CallbackContext context);
            void OnF3(InputAction.CallbackContext context);
            void OnF4(InputAction.CallbackContext context);
            void OnF5(InputAction.CallbackContext context);
            void OnF6(InputAction.CallbackContext context);
            void OnF7(InputAction.CallbackContext context);
            void OnF8(InputAction.CallbackContext context);
            void OnF9(InputAction.CallbackContext context);
            void OnF10(InputAction.CallbackContext context);
            void OnF11(InputAction.CallbackContext context);
            void OnF12(InputAction.CallbackContext context);
        }
    }
}
