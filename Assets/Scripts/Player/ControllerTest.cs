using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerTest : MonoBehaviour
{
    private Controllers input;
    public static ControllerTest instance;
    bool moving;
    bool aiming;
    bool jumping;
    bool diving;

    public bool IsAiming;
    public Vector2 AimDirection;
    public float XMove;
    public float YMove;
    public float DiveMove;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else 
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        input = new Controllers();
        input.Test.Jumping.performed += ctx => Jumping();
        input.Test.Diving.performed += ctx => Diving();
        input.Test.MovementX.started += MovementX_started;
        input.Test.MovementX.canceled += MovementX_ended;
        input.Test.StartAiming.started += Aiming_started;
        input.Test.StartAiming.canceled += Aiming_ended;
    }

    private void MovementX_started(InputAction.CallbackContext obj)
    {
        moving = true;
    }
    private void MovementX_ended(InputAction.CallbackContext obj)
    {
        moving = false;
    }
    private void Aiming_started(InputAction.CallbackContext obj)
    {
        IsAiming = true;
    }
    private void Aiming_ended(InputAction.CallbackContext obj)
    {
        IsAiming = false;
    }

    public void Jumping()
    {
        jumping = true;
    }
    public void Diving()
    {
        diving = true;
    }
    private void OnEnable()
    {
        input.Test.Enable();
    }
    private void OnDisable()
    {
        input.Test.Jumping.performed -= ctx => Jumping();
        input.Test.Diving.performed -= ctx => Diving();
        input.Test.MovementX.started -= MovementX_started;
        input.Test.MovementX.canceled -= MovementX_ended;
        input.Test.StartAiming.started -= Aiming_started;
        input.Test.StartAiming.canceled -= Aiming_ended;
        input.Test.Disable();
    }
    private void Update()
    {
        if(moving){
            XMove = input.Test.MovementX.ReadValue<float>();
            
        } else {
            XMove = 0;
        }
        if(jumping){
            YMove = input.Test.Jumping.ReadValue<float>();
        }
        else{
            YMove = 0;
        }
        if (diving)
        {
            DiveMove = input.Test.Diving.ReadValue<float>();
        }
        else
        {
            DiveMove = 0;
        }
        if (IsAiming)
        {
           // AimDirection = input.Test.Aiming.ReadValue<Vector2>();
        } 
    }
}
