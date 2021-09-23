// GENERATED AUTOMATICALLY FROM 'Assets/Project/Script/InputSystem/InputController.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputController : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputController()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputController"",
    ""maps"": [
        {
            ""name"": ""Generic"",
            ""id"": ""cf25986b-d95d-46c0-9cd8-8e5e2cdb533e"",
            ""actions"": [
                {
                    ""name"": ""StartContact"",
                    ""type"": ""PassThrough"",
                    ""id"": ""64d14efb-fa53-4b05-b8c0-dd98f82283d8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""TouchPosition"",
                    ""type"": ""PassThrough"",
                    ""id"": ""b1c2b842-0108-4034-bfc9-2ddc85ae0576"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a6e6725e-b798-4f49-829c-c7ba8e4dc484"",
                    ""path"": ""<Touchscreen>/primaryTouch/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StartContact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""379c6ed8-7c63-4a7b-b300-9717658d22c0"",
                    ""path"": ""<Touchscreen>/primaryTouch/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""InputController"",
            ""bindingGroup"": ""InputController"",
            ""devices"": [
                {
                    ""devicePath"": ""<Touchscreen>"",
                    ""isOptional"": false,
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
        // Generic
        m_Generic = asset.FindActionMap("Generic", throwIfNotFound: true);
        m_Generic_StartContact = m_Generic.FindAction("StartContact", throwIfNotFound: true);
        m_Generic_TouchPosition = m_Generic.FindAction("TouchPosition", throwIfNotFound: true);
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

    // Generic
    private readonly InputActionMap m_Generic;
    private IGenericActions m_GenericActionsCallbackInterface;
    private readonly InputAction m_Generic_StartContact;
    private readonly InputAction m_Generic_TouchPosition;
    public struct GenericActions
    {
        private @InputController m_Wrapper;
        public GenericActions(@InputController wrapper) { m_Wrapper = wrapper; }
        public InputAction @StartContact => m_Wrapper.m_Generic_StartContact;
        public InputAction @TouchPosition => m_Wrapper.m_Generic_TouchPosition;
        public InputActionMap Get() { return m_Wrapper.m_Generic; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GenericActions set) { return set.Get(); }
        public void SetCallbacks(IGenericActions instance)
        {
            if (m_Wrapper.m_GenericActionsCallbackInterface != null)
            {
                @StartContact.started -= m_Wrapper.m_GenericActionsCallbackInterface.OnStartContact;
                @StartContact.performed -= m_Wrapper.m_GenericActionsCallbackInterface.OnStartContact;
                @StartContact.canceled -= m_Wrapper.m_GenericActionsCallbackInterface.OnStartContact;
                @TouchPosition.started -= m_Wrapper.m_GenericActionsCallbackInterface.OnTouchPosition;
                @TouchPosition.performed -= m_Wrapper.m_GenericActionsCallbackInterface.OnTouchPosition;
                @TouchPosition.canceled -= m_Wrapper.m_GenericActionsCallbackInterface.OnTouchPosition;
            }
            m_Wrapper.m_GenericActionsCallbackInterface = instance;
            if (instance != null)
            {
                @StartContact.started += instance.OnStartContact;
                @StartContact.performed += instance.OnStartContact;
                @StartContact.canceled += instance.OnStartContact;
                @TouchPosition.started += instance.OnTouchPosition;
                @TouchPosition.performed += instance.OnTouchPosition;
                @TouchPosition.canceled += instance.OnTouchPosition;
            }
        }
    }
    public GenericActions @Generic => new GenericActions(this);
    private int m_InputControllerSchemeIndex = -1;
    public InputControlScheme InputControllerScheme
    {
        get
        {
            if (m_InputControllerSchemeIndex == -1) m_InputControllerSchemeIndex = asset.FindControlSchemeIndex("InputController");
            return asset.controlSchemes[m_InputControllerSchemeIndex];
        }
    }
    public interface IGenericActions
    {
        void OnStartContact(InputAction.CallbackContext context);
        void OnTouchPosition(InputAction.CallbackContext context);
    }
}
