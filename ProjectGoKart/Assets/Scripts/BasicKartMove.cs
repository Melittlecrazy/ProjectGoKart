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
    [SerializeField] private Rigidbody body,body2;
    [SerializeField] private LayerMask ground;

    PlayerManager playerManager;
    
    private float forwardAmount;
    public float currentSpeed1, currentSpeed2;
    [SerializeField] public float speed;
    [SerializeField] public float deeps;
    float turnAmount;
    [SerializeField] public float turnSpeed;

    [SerializeField] private bool canDash = true;
    [SerializeField] private bool isDashing;
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashTime;
    
    public bool isPlayer1,isPlayer2;

    public int stun;

    private void Start()
    {
        body.transform.parent = null;
        body2.transform.parent = null;
    }

    private void Update()
    {
        
        

        //forwardAmount = Input.GetAxis("Vertical");


        //string joystickName = Input.GetJoystickNames().First();
        //if (Input.GetKey(KeyCode.JoystickButton0) || Input.GetKey(KeyCode.Space)) Drive();

        if (isPlayer1 == true )//&& playerManager.controllerTypeConnected == PlayerManager.ControllerTypeConnected.Xbox)
        {
            transform.position = body.transform.position;
            turnAmount = Input.GetAxis("Horizontal");
            if (Input.GetAxis("Go") > 0) Drive();
            else currentSpeed1 = 0f;
            

            if (Input.GetAxis("Go1") > 0) DriveNowhere();
            //if (Gamepad.current.leftStick.left.) //Gamepad.current.buttonSouth.isPressed //Gamepad.current.buttonEast.isPressed

            //if (Input.GetAxis("Dash") > 0)
            //{
            //    StartCoroutine(Dash());
            //}


            Turning(); 
            
        }

        if (isPlayer2 == true)// && joystickName.ToLower().Contains("xbox"))
        {
            transform.position = body2.transform.position;
            turnAmount = Input.GetAxis("Horizontal2");
            if (Input.GetAxis("Jump") > 0) { currentSpeed2 = speed; }
                //Drive();
            else currentSpeed2 = 0f;

            if (Input.GetAxis("Jump2") > 0) { currentSpeed2 = -speed * deeps; }
                //DriveNowhere();

            //Input.GetKeyDown(KeyCode.LeftShift) 
            Turning();
        }

        //GroundHandler();
    }
    private void FixedUpdate()
    {
        body.AddForce(transform.forward * currentSpeed1, ForceMode.Acceleration);
        body2.AddForce(transform.forward * currentSpeed2, ForceMode.Acceleration);
        


    }

    private void Drive()
    {
        //currentSpeed = forwardAmount *= speed;
        currentSpeed1 = speed;
        
    }
    void DriveNowhere()
    {
        currentSpeed1 = -speed * deeps;
        
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

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Tool") StartCoroutine(Stun());
    }

    IEnumerator Stun()
    {
        if (isPlayer1 == true) speed = 0;
        if (isPlayer2 == true) speed = 0;
        yield return new WaitForSeconds(stun);
        if (isPlayer1 == true) speed = 50;
        if (isPlayer2 == true) speed= 50;
    }

    public IEnumerator Dash()
    {
        float startTime = Time.time;


        while(Time.time < startTime + dashTime)
        {
            if (isPlayer1)
            currentSpeed1 = speed * dashSpeed;
            if(isPlayer2)
            currentSpeed2 = speed * dashSpeed;

            yield return null;
        } 
        
    
    }
}
