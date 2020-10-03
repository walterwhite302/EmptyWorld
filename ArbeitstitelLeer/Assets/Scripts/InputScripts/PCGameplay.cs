// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/InputScripts/PCGameplay.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PCGameplay : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PCGameplay()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PCGameplay"",
    ""maps"": [
        {
            ""name"": ""MT"",
            ""id"": ""3ded0ed8-1d46-4125-8e8f-61aed868d99c"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""380f4a81-77fc-40fe-adf7-2049444989c3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""c80d775e-f32f-47d3-9eda-386c887ba389"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""95e448fb-b395-4dd7-afa6-ee7020c60172"",
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
                    ""id"": ""8bcfd8ec-d5ae-4b68-9453-9fa2015da894"",
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
                    ""id"": ""700fa2b4-c3fe-486c-a06a-c3b7273d2436"",
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
                    ""id"": ""b56c8fca-b391-4e8b-80f5-1888af9957cc"",
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
                    ""id"": ""f39566ef-f6b8-4033-a5d1-38c9698a8f13"",
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
                    ""id"": ""a702899e-4b88-4adb-8ff3-34882e8bb5ef"",
                    ""path"": ""<Keyboard>/#(e)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // MT
        m_MT = asset.FindActionMap("MT", throwIfNotFound: true);
        m_MT_Move = m_MT.FindAction("Move", throwIfNotFound: true);
        m_MT_Interact = m_MT.FindAction("Interact", throwIfNotFound: true);
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

    // MT
    private readonly InputActionMap m_MT;
    private IMTActions m_MTActionsCallbackInterface;
    private readonly InputAction m_MT_Move;
    private readonly InputAction m_MT_Interact;
    public struct MTActions
    {
        private @PCGameplay m_Wrapper;
        public MTActions(@PCGameplay wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_MT_Move;
        public InputAction @Interact => m_Wrapper.m_MT_Interact;
        public InputActionMap Get() { return m_Wrapper.m_MT; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MTActions set) { return set.Get(); }
        public void SetCallbacks(IMTActions instance)
        {
            if (m_Wrapper.m_MTActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_MTActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_MTActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_MTActionsCallbackInterface.OnMove;
                @Interact.started -= m_Wrapper.m_MTActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_MTActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_MTActionsCallbackInterface.OnInteract;
            }
            m_Wrapper.m_MTActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
            }
        }
    }
    public MTActions @MT => new MTActions(this);
    public interface IMTActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
    }
}
