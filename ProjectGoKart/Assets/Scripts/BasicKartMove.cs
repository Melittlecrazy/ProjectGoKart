using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.XInput;

public class BasicKartMove : MonoBehaviour
{
    [SerializeField] private Rigidbody body, body2;
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

    [SerializeField] private GameObject stunEffect;
    public bool isPlayer1, isPlayer2;

    public float stun;
    private bool isStunned = false;

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

        if (isPlayer1 == true)//&& playerManager.controllerTypeConnected == PlayerManager.ControllerTypeConnected.Xbox)
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

        //thanks to Toyful Games on Youtube for the code
        //if (rayDidHit)
        //{
        //    Vector3 springDir = tireTransform.up;

        //    Vector3 tireWorldVel = carRidgidBody.GetPointVelocity(tireTransform.position);

        //    float offset = suspensionResDist - tireRay.distiance;

        //    float vel = Vector3.Dot(springDir, tireWorldVel);

        //    float force = (offset * spingStrength) - (vel - springDamper);

        //    carRigidBody.AddForceAtPosition(springDir * force, tireTransform.position);
        //}

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
        transform.Rotate(xAngle: 0, yAngle: newRotation, zAngle: 0, relativeTo: Space.World);
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
        if (col.gameObject.tag == "Player" || col.gameObject.tag == "Enemy") StartCoroutine(PlayerCrash(col.gameObject));
    }

    IEnumerator PlayerCrash(GameObject kart)
    {
        BasicKartMove script = kart.GetComponent<BasicKartMove>();

        if (currentSpeed1 < script.currentSpeed2 && isPlayer1 && !isStunned)
        {
            isStunned = true;
            stunEffect.SetActive(true);
            StartCoroutine(Stun());
        }
        if (currentSpeed2 < script.currentSpeed1 && isPlayer2 == true && !isStunned)
        {
            isStunned = true;
            stunEffect.SetActive(true);
            StartCoroutine(Stun());
        }
        yield return new WaitForSeconds(3);
    }
    IEnumerator Stun()
    {
        if (isPlayer1 == true) speed = 0;
        if (isPlayer2 == true) speed = 0;
        yield return new WaitForSeconds(stun);
        if (isPlayer1 == true)
        {
            isStunned = false;
            speed = 50;
            stunEffect.SetActive(false);
        }
        if (isPlayer2 == true)
        {
            isStunned = false;
            speed = 50;
            stunEffect.SetActive(false);
        }
    }

    public IEnumerator Dash()
    {
        float startTime = Time.time;


        while (Time.time < startTime + dashTime)
        {
            if (isPlayer1)
                currentSpeed1 = speed * dashSpeed;
            if (isPlayer2)
                currentSpeed2 = speed * dashSpeed;

            yield return null;
        }


    }
}
