using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerTest : MonoBehaviour
{
    public PlayerBehavior Player;

    InputActionAsset inputAsset;
    private Controllers input;
    public static ControllerTest instance;
    bool moving;
    bool jumping;
    bool diving;
    bool shooting;
    bool reseting;

    private Coroutine DiveCooldownInstance;
    private Coroutine JumpHeightInstance;

    public bool IsAiming;
    public Vector2 AimDirection;
    public float XMove;
    public float YMove;
    public float DiveMove;
    public float GunShot;
    public float Reset;
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
        inputAsset = this.GetComponent<PlayerInput>().actions;
        input = new Controllers();
        input.Test.Jumping.performed += ctx => Jumping();
        input.Test.Jumping.canceled += ctx => JumpingEnded();
        input.Test.Diving.performed += ctx => Diving();
        input.Test.Shooting.performed += ctx => Shooting();
        input.Test.Reseting.performed += ctx => Reseting();
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
        if (JumpHeightInstance == null)
        {
            JumpHeightInstance = StartCoroutine(JumpHeight());
        }
    }
    public void JumpingEnded()
    {
        jumping = false;
        StopCoroutine(JumpHeight());
    }

    public void Diving()
    {
        diving = true;
        if (DiveCooldownInstance == null)
        {
            DiveCooldownInstance = StartCoroutine(DiveCooldown());
        }
    }
    public void Shooting()
    {
        shooting = true;
    }
    public void Reseting()
    {
        reseting = true;
    }
    private void OnEnable()
    {
        input.Test.Enable();
    }
    private void OnDisable()
    {
        /*input.Test.Jumping.performed -= ctx => Jumping();
        input.Test.Jumping.canceled -= ctx => JumpingEnded();
        input.Test.Diving.performed -= ctx => Diving();
        input.Test.Shooting.performed -= ctx => Shooting();
        input.Test.Reseting.performed -= ctx => Reseting();
        input.Test.MovementX.started -= MovementX_started;
        input.Test.MovementX.canceled -= MovementX_ended;
        input.Test.StartAiming.started -= Aiming_started;
        input.Test.StartAiming.canceled -= Aiming_ended;*/
        input.Test.Disable();
    }
    private void Update()
    {        
        if (Player == null)
        {
            Player = GameObject.Find("Eeveeon").GetComponent<PlayerBehavior>();
        }
        if(moving)
        {
            XMove = input.Test.MovementX.ReadValue<float>();    
        } else {
            XMove = 0;
        }
        if (jumping)
        {
            YMove = 3;
        } else {
            YMove = 0;
        }
        if (shooting)
        {
            GunShot = input.Test.Shooting.ReadValue<float>();
        }
        else
        {
            GunShot = 0;
        }
        /*if (reseting)
        {
            Reset = input.Test.Reseting.ReadValue<float>();
        }
        else
        {
            Reset = 0;
        }*/
        if (IsAiming)
        {
           AimDirection = input.Test.Aiming.ReadValue<Vector2>();
        } 
    }

    public IEnumerator JumpHeight()
    {
        Player.JumpTimer = 0;
        while (Player.JumpTimer < Player.JumpTimerMax)
        {
            Player.JumpTimer += Time.deltaTime;
            yield return null;
        }
        jumping = false;
        JumpHeightInstance = null;
        StopCoroutine(JumpHeight());
    }
    public IEnumerator DiveCooldown()
    {
        //Player.Dive();
        float Timer = 0.5f;
        while (Timer > 0)
        {
            Timer -= Time.deltaTime;
            yield return null;
        }
        DiveCooldownInstance = null;
    }
}
