//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Scripts/player/FPSControl.inputactions
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

public partial class @FPSControl: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @FPSControl()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""FPSControl"",
    ""maps"": [
        {
            ""name"": ""FPSController"",
            ""id"": ""2a8b124d-b40d-4089-9bb1-3e7687c3c29f"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""6e44727f-40d2-41de-9df8-ef9c859bb7f5"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""5199bef6-c81b-4c89-a767-9d8947696c32"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""8c6383d9-9222-42b4-8c8b-23636c49bbb2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""9e0341e9-22b1-45ac-8d40-d59fa32368a5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Cancel"",
                    ""type"": ""Button"",
                    ""id"": ""0610e9bc-de54-453d-9334-f6d9e030feae"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MouseDownHelper"",
                    ""type"": ""Button"",
                    ""id"": ""79c38dd5-ab8d-447d-8cdb-1bbd79485114"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""e1c66f5d-86f8-4819-9ffb-46c51392ba9b"",
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
                    ""id"": ""b2b620ce-fd94-4aa9-9452-511a00d48e5e"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""FPSControllerInputs"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""0a533e67-c661-464c-8486-a99fdbe48997"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""FPSControllerInputs"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""864a6caa-192d-4320-9e3e-06dc3d60bead"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""FPSControllerInputs"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""259e7673-3108-4433-8958-246644928eea"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""FPSControllerInputs"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""f5a0feef-fa07-4fda-8e57-98862b13abfa"",
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
                    ""id"": ""7ca7ef42-34ce-439e-ba30-93fd2fcc6708"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""FPSControllerInputs"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""b894679b-485b-41e1-ab9e-7f1d5e02c2a8"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""FPSControllerInputs"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""bea5abaf-7361-4a3b-8ea0-96e1afaf7c92"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""FPSControllerInputs"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""1c67ce8f-8e4b-47fc-bee9-35bf8a7fe760"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""FPSControllerInputs"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""a4145e3e-192b-4cc8-82eb-ebae065cddae"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": ""ScaleVector2(x=5,y=5)"",
                    ""groups"": ""FPSControllerInputs"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""de7cdca1-c0b2-4408-83fe-c06771dd6234"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": ""ScaleVector2"",
                    ""groups"": ""FPSControllerInputs"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f13ca7c1-bd6e-4b15-9012-39597d60e60f"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""FPSControllerInputs"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c97d1675-94e3-4247-8f5d-e63efdc8ed22"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""FPSControllerInputs"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""40030496-8e56-4241-af87-502635238656"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""FPSControllerInputs"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""41ece9d3-6e33-4e80-a0c9-3b5a05a99803"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""FPSControllerInputs"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5feb086f-0b02-49e6-9c3d-61387c52416c"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""FPSControllerInputs"",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""90bc902b-beaa-41bd-a14d-e26d3896f593"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""FPSControllerInputs"",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""79cab11b-b004-4b1a-be60-95dca228a8ba"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""FPSControllerInputs"",
                    ""action"": ""MouseDownHelper"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""FPSControllerInputs"",
            ""bindingGroup"": ""FPSControllerInputs"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": true,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // FPSController
        m_FPSController = asset.FindActionMap("FPSController", throwIfNotFound: true);
        m_FPSController_Move = m_FPSController.FindAction("Move", throwIfNotFound: true);
        m_FPSController_Look = m_FPSController.FindAction("Look", throwIfNotFound: true);
        m_FPSController_Jump = m_FPSController.FindAction("Jump", throwIfNotFound: true);
        m_FPSController_Interact = m_FPSController.FindAction("Interact", throwIfNotFound: true);
        m_FPSController_Cancel = m_FPSController.FindAction("Cancel", throwIfNotFound: true);
        m_FPSController_MouseDownHelper = m_FPSController.FindAction("MouseDownHelper", throwIfNotFound: true);
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

    // FPSController
    private readonly InputActionMap m_FPSController;
    private List<IFPSControllerActions> m_FPSControllerActionsCallbackInterfaces = new List<IFPSControllerActions>();
    private readonly InputAction m_FPSController_Move;
    private readonly InputAction m_FPSController_Look;
    private readonly InputAction m_FPSController_Jump;
    private readonly InputAction m_FPSController_Interact;
    private readonly InputAction m_FPSController_Cancel;
    private readonly InputAction m_FPSController_MouseDownHelper;
    public struct FPSControllerActions
    {
        private @FPSControl m_Wrapper;
        public FPSControllerActions(@FPSControl wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_FPSController_Move;
        public InputAction @Look => m_Wrapper.m_FPSController_Look;
        public InputAction @Jump => m_Wrapper.m_FPSController_Jump;
        public InputAction @Interact => m_Wrapper.m_FPSController_Interact;
        public InputAction @Cancel => m_Wrapper.m_FPSController_Cancel;
        public InputAction @MouseDownHelper => m_Wrapper.m_FPSController_MouseDownHelper;
        public InputActionMap Get() { return m_Wrapper.m_FPSController; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(FPSControllerActions set) { return set.Get(); }
        public void AddCallbacks(IFPSControllerActions instance)
        {
            if (instance == null || m_Wrapper.m_FPSControllerActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_FPSControllerActionsCallbackInterfaces.Add(instance);
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
            @Look.started += instance.OnLook;
            @Look.performed += instance.OnLook;
            @Look.canceled += instance.OnLook;
            @Jump.started += instance.OnJump;
            @Jump.performed += instance.OnJump;
            @Jump.canceled += instance.OnJump;
            @Interact.started += instance.OnInteract;
            @Interact.performed += instance.OnInteract;
            @Interact.canceled += instance.OnInteract;
            @Cancel.started += instance.OnCancel;
            @Cancel.performed += instance.OnCancel;
            @Cancel.canceled += instance.OnCancel;
            @MouseDownHelper.started += instance.OnMouseDownHelper;
            @MouseDownHelper.performed += instance.OnMouseDownHelper;
            @MouseDownHelper.canceled += instance.OnMouseDownHelper;
        }

        private void UnregisterCallbacks(IFPSControllerActions instance)
        {
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
            @Look.started -= instance.OnLook;
            @Look.performed -= instance.OnLook;
            @Look.canceled -= instance.OnLook;
            @Jump.started -= instance.OnJump;
            @Jump.performed -= instance.OnJump;
            @Jump.canceled -= instance.OnJump;
            @Interact.started -= instance.OnInteract;
            @Interact.performed -= instance.OnInteract;
            @Interact.canceled -= instance.OnInteract;
            @Cancel.started -= instance.OnCancel;
            @Cancel.performed -= instance.OnCancel;
            @Cancel.canceled -= instance.OnCancel;
            @MouseDownHelper.started -= instance.OnMouseDownHelper;
            @MouseDownHelper.performed -= instance.OnMouseDownHelper;
            @MouseDownHelper.canceled -= instance.OnMouseDownHelper;
        }

        public void RemoveCallbacks(IFPSControllerActions instance)
        {
            if (m_Wrapper.m_FPSControllerActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IFPSControllerActions instance)
        {
            foreach (var item in m_Wrapper.m_FPSControllerActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_FPSControllerActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public FPSControllerActions @FPSController => new FPSControllerActions(this);
    private int m_FPSControllerInputsSchemeIndex = -1;
    public InputControlScheme FPSControllerInputsScheme
    {
        get
        {
            if (m_FPSControllerInputsSchemeIndex == -1) m_FPSControllerInputsSchemeIndex = asset.FindControlSchemeIndex("FPSControllerInputs");
            return asset.controlSchemes[m_FPSControllerInputsSchemeIndex];
        }
    }
    public interface IFPSControllerActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnCancel(InputAction.CallbackContext context);
        void OnMouseDownHelper(InputAction.CallbackContext context);
    }
}
