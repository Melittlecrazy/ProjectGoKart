using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.XInput;

public class BasicKartMove : MonoBehaviour
{
    [SerializeField] private Rigidbody body;
    [SerializeField] private LayerMask ground;

    PlayerManager playerManager;
    
    private float forwardAmount;
    private float currentSpeed;
    [SerializeField] public float speed;
    [SerializeField] public float deeps;
    float turnAmount;
    [SerializeField] public float turnSpeed;
    
    public bool isPlayer1,isPlayer2;

    public enum ControllerTypeConnected { Xbox, Playstation, Other }
    [HideInInspector]
    public ControllerTypeConnected controllerTypeConnected;


    private void Start()
    {
        body.transform.parent = null;
        
    }

    private void Update()
    {
        transform.position = body.transform.position;

        //forwardAmount = Input.GetAxis("Vertical");
        turnAmount = Input.GetAxis("Horizontal");
        string joystickName = Input.GetJoystickNames().First();
        //if (Input.GetKey(KeyCode.JoystickButton0) || Input.GetKey(KeyCode.Space)) Drive();

        if (isPlayer1 == true && joystickName.ToLower().Contains("xbox"))//&& playerManager.controllerTypeConnected == PlayerManager.ControllerTypeConnected.Xbox)
        {
            if (Gamepad.current.buttonSouth.isPressed) Drive();
            else currentSpeed = 0f;

            if (Gamepad.current.buttonEast.isPressed) DriveNowhere();

            Turning();
        }

        //if (isPlayer2 == true && joystickName.ToLower().Contains("xbox"))
        //{
        //    if (GamepadButton.South) Drive();
        //    else currentSpeed = 0f;

        //    if (Input.GetKeyDown(KeyCode.LeftShift)) DriveNowhere();

        //    Turning();
        //}

        //GroundHandler();
    }
    private void FixedUpdate()
    {
        body.AddForce(transform.forward * currentSpeed, ForceMode.Acceleration);
    }

    private void Drive()
    {
        //currentSpeed = forwardAmount *= speed;
        currentSpeed = speed;
        
    }
    void DriveNowhere()
    {
        currentSpeed = -speed * deeps;
        
    }
    //This is for tighter controls, might add it later.

    void Turning()
    {
        float newRotation = turnAmount * turnSpeed * Time.deltaTime;
        transform.Rotate(xAngle:0, yAngle:newRotation, zAngle:0, relativeTo:Space.World);
    }
    void GroundHandler()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit, 0.75f))
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.FromToRotation(transform.up * 2, hit.normal) * transform.rotation, 0.75f * Time.deltaTime);
        }
    }

    
}
