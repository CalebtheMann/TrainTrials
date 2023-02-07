//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/Controller/Controllers.inputactions
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

public partial class @Controllers : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controllers()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controllers"",
    ""maps"": [
        {
            ""name"": ""Test"",
            ""id"": ""6c116c22-c852-4aee-9a9f-fd677a77ef80"",
            ""actions"": [
                {
                    ""name"": ""Jumping"",
                    ""type"": ""Button"",
                    ""id"": ""cc9e7c00-3acd-4de8-a034-de43e8f946cf"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MovementX"",
                    ""type"": ""Value"",
                    ""id"": ""9f6e8500-cd4c-44b0-bdfe-23d6e1da7d88"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Diving"",
                    ""type"": ""Button"",
                    ""id"": ""23333b89-f4b1-49c7-abeb-74216b2f82b8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Shooting"",
                    ""type"": ""Button"",
                    ""id"": ""bc6de081-7a6f-4182-af39-4941283cbbc6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Aiming"",
                    ""type"": ""PassThrough"",
                    ""id"": ""4262cd71-cde8-411e-a7ac-aea4019a825d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""StartAiming"",
                    ""type"": ""Value"",
                    ""id"": ""03de5b10-c263-4c80-ac60-87115513447d"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""63e66816-60b7-407a-bd8b-afb37fc28b54"",
                    ""path"": ""<XInputController>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jumping"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e39c53ac-3f87-4e75-8d04-23e362cf8444"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jumping"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c00491ee-a260-4cf7-b90f-4910d9b9afba"",
                    ""path"": ""<Gamepad>/dpad/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e356abcc-bb28-4211-b0a2-a5c1c3634557"",
                    ""path"": ""<Gamepad>/leftStick/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""d6c9f35a-14dc-41fd-90d6-27bc7ca84335"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementX"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""b784ba44-1d24-4b75-85cc-af9a346ea44d"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""22a991a8-c118-447b-b5ab-88f8b856bc6f"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""74b60411-820d-464d-a4d7-c484955bd2c5"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementX"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""18da7a03-6780-4878-8f54-6258dca6f5fb"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""2d80249b-4f45-4afa-9cc6-2b0edf039f06"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""65f531c0-60a5-414a-b280-e411cc2f1bb4"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jumping"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ae728e73-0294-470f-894e-44d915291289"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jumping"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""73fcb938-e972-46a6-9669-7096f082ba13"",
                    ""path"": ""<XInputController>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jumping"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""104df697-855b-4d7d-a56c-89b2d02fd3de"",
                    ""path"": ""<XInputController>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Diving"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6a0ca9f3-17cd-41dd-a822-c2216d24a723"",
                    ""path"": ""<XInputController>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Diving"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""063043f4-25d6-448f-b029-6d48cfeead6c"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Diving"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""faa1ecf6-9d17-4b15-b1e9-2cfe46015b2e"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Diving"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""40cb8962-2918-40cb-bc71-d538a92d4b30"",
                    ""path"": ""<XInputController>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shooting"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bb159946-2d43-40da-bfa6-0300ea0d4fc8"",
                    ""path"": ""<XInputController>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shooting"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c79143b2-a4a0-4bcf-b33b-b3e58426eeb1"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shooting"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e9920f2b-10f8-4edd-8f88-887d72eae9c3"",
                    ""path"": ""<XInputController>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aiming"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""15183e61-9b5b-4667-8e12-72c3cf41f2d2"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StartAiming"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Test
        m_Test = asset.FindActionMap("Test", throwIfNotFound: true);
        m_Test_Jumping = m_Test.FindAction("Jumping", throwIfNotFound: true);
        m_Test_MovementX = m_Test.FindAction("MovementX", throwIfNotFound: true);
        m_Test_Diving = m_Test.FindAction("Diving", throwIfNotFound: true);
        m_Test_Shooting = m_Test.FindAction("Shooting", throwIfNotFound: true);
        m_Test_Aiming = m_Test.FindAction("Aiming", throwIfNotFound: true);
        m_Test_StartAiming = m_Test.FindAction("StartAiming", throwIfNotFound: true);
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

    // Test
    private readonly InputActionMap m_Test;
    private ITestActions m_TestActionsCallbackInterface;
    private readonly InputAction m_Test_Jumping;
    private readonly InputAction m_Test_MovementX;
    private readonly InputAction m_Test_Diving;
    private readonly InputAction m_Test_Shooting;
    private readonly InputAction m_Test_Aiming;
    private readonly InputAction m_Test_StartAiming;
    public struct TestActions
    {
        private @Controllers m_Wrapper;
        public TestActions(@Controllers wrapper) { m_Wrapper = wrapper; }
        public InputAction @Jumping => m_Wrapper.m_Test_Jumping;
        public InputAction @MovementX => m_Wrapper.m_Test_MovementX;
        public InputAction @Diving => m_Wrapper.m_Test_Diving;
        public InputAction @Shooting => m_Wrapper.m_Test_Shooting;
        public InputAction @Aiming => m_Wrapper.m_Test_Aiming;
        public InputAction @StartAiming => m_Wrapper.m_Test_StartAiming;
        public InputActionMap Get() { return m_Wrapper.m_Test; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TestActions set) { return set.Get(); }
        public void SetCallbacks(ITestActions instance)
        {
            if (m_Wrapper.m_TestActionsCallbackInterface != null)
            {
                @Jumping.started -= m_Wrapper.m_TestActionsCallbackInterface.OnJumping;
                @Jumping.performed -= m_Wrapper.m_TestActionsCallbackInterface.OnJumping;
                @Jumping.canceled -= m_Wrapper.m_TestActionsCallbackInterface.OnJumping;
                @MovementX.started -= m_Wrapper.m_TestActionsCallbackInterface.OnMovementX;
                @MovementX.performed -= m_Wrapper.m_TestActionsCallbackInterface.OnMovementX;
                @MovementX.canceled -= m_Wrapper.m_TestActionsCallbackInterface.OnMovementX;
                @Diving.started -= m_Wrapper.m_TestActionsCallbackInterface.OnDiving;
                @Diving.performed -= m_Wrapper.m_TestActionsCallbackInterface.OnDiving;
                @Diving.canceled -= m_Wrapper.m_TestActionsCallbackInterface.OnDiving;
                @Shooting.started -= m_Wrapper.m_TestActionsCallbackInterface.OnShooting;
                @Shooting.performed -= m_Wrapper.m_TestActionsCallbackInterface.OnShooting;
                @Shooting.canceled -= m_Wrapper.m_TestActionsCallbackInterface.OnShooting;
                @Aiming.started -= m_Wrapper.m_TestActionsCallbackInterface.OnAiming;
                @Aiming.performed -= m_Wrapper.m_TestActionsCallbackInterface.OnAiming;
                @Aiming.canceled -= m_Wrapper.m_TestActionsCallbackInterface.OnAiming;
                @StartAiming.started -= m_Wrapper.m_TestActionsCallbackInterface.OnStartAiming;
                @StartAiming.performed -= m_Wrapper.m_TestActionsCallbackInterface.OnStartAiming;
                @StartAiming.canceled -= m_Wrapper.m_TestActionsCallbackInterface.OnStartAiming;
            }
            m_Wrapper.m_TestActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Jumping.started += instance.OnJumping;
                @Jumping.performed += instance.OnJumping;
                @Jumping.canceled += instance.OnJumping;
                @MovementX.started += instance.OnMovementX;
                @MovementX.performed += instance.OnMovementX;
                @MovementX.canceled += instance.OnMovementX;
                @Diving.started += instance.OnDiving;
                @Diving.performed += instance.OnDiving;
                @Diving.canceled += instance.OnDiving;
                @Shooting.started += instance.OnShooting;
                @Shooting.performed += instance.OnShooting;
                @Shooting.canceled += instance.OnShooting;
                @Aiming.started += instance.OnAiming;
                @Aiming.performed += instance.OnAiming;
                @Aiming.canceled += instance.OnAiming;
                @StartAiming.started += instance.OnStartAiming;
                @StartAiming.performed += instance.OnStartAiming;
                @StartAiming.canceled += instance.OnStartAiming;
            }
        }
    }
    public TestActions @Test => new TestActions(this);
    public interface ITestActions
    {
        void OnJumping(InputAction.CallbackContext context);
        void OnMovementX(InputAction.CallbackContext context);
        void OnDiving(InputAction.CallbackContext context);
        void OnShooting(InputAction.CallbackContext context);
        void OnAiming(InputAction.CallbackContext context);
        void OnStartAiming(InputAction.CallbackContext context);
    }
}