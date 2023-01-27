using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerTest : MonoBehaviour
{
    private Controllers input;
    public static ControllerTest instance;
    bool moving;

    public float XMove; 
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
        input.Test.Pressing.performed += ctx => Pressing();
        input.Test.MovementX.started += MovementX_started;
        input.Test.MovementX.canceled += MovementX_ended;
    }

    private void MovementX_started(InputAction.CallbackContext obj)
    {
        moving = true;
    }
    private void MovementX_ended(InputAction.CallbackContext obj)
    {
        moving = false;
    }

    public void Pressing()
    {
        Debug.Log("lol");
    }
    private void OnEnable()
    {
        input.Test.Enable();
    }
    private void OnDisable()
    {
        input.Test.Pressing.performed -= ctx => Pressing();
        input.Test.MovementX.started -= MovementX_started;
        input.Test.MovementX.canceled -= MovementX_ended;
        input.Test.Disable();
    }
    private void Update()
    {
        if(moving){
            XMove = input.Test.MovementX.ReadValue<float>();
            
        } else {
            XMove = 0;
        }
    }
}
