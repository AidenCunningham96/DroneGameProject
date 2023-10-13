// GENERATED AUTOMATICALLY FROM 'Assets/Player_Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Player_Controls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Player_Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Player_Controls"",
    ""maps"": [
        {
            ""name"": ""Boy"",
            ""id"": ""0034a7fe-dca6-4c64-ade1-7d77a1cdb6c0"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""bc2d3cb1-befe-41c5-b845-da9f4818bc3d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""78e85b74-4e61-4287-9e80-cfeb018e8040"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""c94ab2f4-8db2-4d96-9506-8ad878550540"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""87ad456a-6adc-4820-b69d-276a741bccac"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""13df2421-2b66-48f1-b00c-cca3e3a9f209"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e4a0aeea-5c8b-45a1-aae4-da9a7dc2aa88"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Drone"",
            ""id"": ""160f086a-93b4-4a13-8400-526ee6e21a01"",
            ""actions"": [
                {
                    ""name"": ""Fly"",
                    ""type"": ""Button"",
                    ""id"": ""37cf01d4-924c-4e68-ac1d-9c22492b02db"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(pressPoint=0.2,behavior=2)""
                },
                {
                    ""name"": ""Grab"",
                    ""type"": ""Button"",
                    ""id"": ""7d7c661e-78fe-41f4-88b8-c1501f6de97d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a558d058-6c1a-4709-8409-716e24c01f0f"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fly"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""77b66375-50a2-43ee-9532-bf219c84cf01"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fly"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8dcde5ce-ba95-4efb-94f5-6ce247b0f907"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Grab"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""eaeecc36-cebf-40b8-905f-20fb6c8b399d"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Grab"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""General"",
            ""id"": ""c098cff7-2a11-497d-9c1b-1fb1bc57563c"",
            ""actions"": [
                {
                    ""name"": ""Switch"",
                    ""type"": ""Button"",
                    ""id"": ""0982c2a1-3b77-4bc0-8442-a2229a6101bb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""54905b37-83d1-4fd1-af8b-374d464cc4f3"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Switch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""807809ab-7f86-4ff2-b386-f245826ab4af"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Switch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Boy
        m_Boy = asset.FindActionMap("Boy", throwIfNotFound: true);
        m_Boy_Jump = m_Boy.FindAction("Jump", throwIfNotFound: true);
        m_Boy_Interact = m_Boy.FindAction("Interact", throwIfNotFound: true);
        // Drone
        m_Drone = asset.FindActionMap("Drone", throwIfNotFound: true);
        m_Drone_Fly = m_Drone.FindAction("Fly", throwIfNotFound: true);
        m_Drone_Grab = m_Drone.FindAction("Grab", throwIfNotFound: true);
        // General
        m_General = asset.FindActionMap("General", throwIfNotFound: true);
        m_General_Switch = m_General.FindAction("Switch", throwIfNotFound: true);
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

    // Boy
    private readonly InputActionMap m_Boy;
    private IBoyActions m_BoyActionsCallbackInterface;
    private readonly InputAction m_Boy_Jump;
    private readonly InputAction m_Boy_Interact;
    public struct BoyActions
    {
        private @Player_Controls m_Wrapper;
        public BoyActions(@Player_Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Jump => m_Wrapper.m_Boy_Jump;
        public InputAction @Interact => m_Wrapper.m_Boy_Interact;
        public InputActionMap Get() { return m_Wrapper.m_Boy; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(BoyActions set) { return set.Get(); }
        public void SetCallbacks(IBoyActions instance)
        {
            if (m_Wrapper.m_BoyActionsCallbackInterface != null)
            {
                @Jump.started -= m_Wrapper.m_BoyActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_BoyActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_BoyActionsCallbackInterface.OnJump;
                @Interact.started -= m_Wrapper.m_BoyActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_BoyActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_BoyActionsCallbackInterface.OnInteract;
            }
            m_Wrapper.m_BoyActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
            }
        }
    }
    public BoyActions @Boy => new BoyActions(this);

    // Drone
    private readonly InputActionMap m_Drone;
    private IDroneActions m_DroneActionsCallbackInterface;
    private readonly InputAction m_Drone_Fly;
    private readonly InputAction m_Drone_Grab;
    public struct DroneActions
    {
        private @Player_Controls m_Wrapper;
        public DroneActions(@Player_Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Fly => m_Wrapper.m_Drone_Fly;
        public InputAction @Grab => m_Wrapper.m_Drone_Grab;
        public InputActionMap Get() { return m_Wrapper.m_Drone; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DroneActions set) { return set.Get(); }
        public void SetCallbacks(IDroneActions instance)
        {
            if (m_Wrapper.m_DroneActionsCallbackInterface != null)
            {
                @Fly.started -= m_Wrapper.m_DroneActionsCallbackInterface.OnFly;
                @Fly.performed -= m_Wrapper.m_DroneActionsCallbackInterface.OnFly;
                @Fly.canceled -= m_Wrapper.m_DroneActionsCallbackInterface.OnFly;
                @Grab.started -= m_Wrapper.m_DroneActionsCallbackInterface.OnGrab;
                @Grab.performed -= m_Wrapper.m_DroneActionsCallbackInterface.OnGrab;
                @Grab.canceled -= m_Wrapper.m_DroneActionsCallbackInterface.OnGrab;
            }
            m_Wrapper.m_DroneActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Fly.started += instance.OnFly;
                @Fly.performed += instance.OnFly;
                @Fly.canceled += instance.OnFly;
                @Grab.started += instance.OnGrab;
                @Grab.performed += instance.OnGrab;
                @Grab.canceled += instance.OnGrab;
            }
        }
    }
    public DroneActions @Drone => new DroneActions(this);

    // General
    private readonly InputActionMap m_General;
    private IGeneralActions m_GeneralActionsCallbackInterface;
    private readonly InputAction m_General_Switch;
    public struct GeneralActions
    {
        private @Player_Controls m_Wrapper;
        public GeneralActions(@Player_Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Switch => m_Wrapper.m_General_Switch;
        public InputActionMap Get() { return m_Wrapper.m_General; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GeneralActions set) { return set.Get(); }
        public void SetCallbacks(IGeneralActions instance)
        {
            if (m_Wrapper.m_GeneralActionsCallbackInterface != null)
            {
                @Switch.started -= m_Wrapper.m_GeneralActionsCallbackInterface.OnSwitch;
                @Switch.performed -= m_Wrapper.m_GeneralActionsCallbackInterface.OnSwitch;
                @Switch.canceled -= m_Wrapper.m_GeneralActionsCallbackInterface.OnSwitch;
            }
            m_Wrapper.m_GeneralActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Switch.started += instance.OnSwitch;
                @Switch.performed += instance.OnSwitch;
                @Switch.canceled += instance.OnSwitch;
            }
        }
    }
    public GeneralActions @General => new GeneralActions(this);
    public interface IBoyActions
    {
        void OnJump(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
    }
    public interface IDroneActions
    {
        void OnFly(InputAction.CallbackContext context);
        void OnGrab(InputAction.CallbackContext context);
    }
    public interface IGeneralActions
    {
        void OnSwitch(InputAction.CallbackContext context);
    }
}
