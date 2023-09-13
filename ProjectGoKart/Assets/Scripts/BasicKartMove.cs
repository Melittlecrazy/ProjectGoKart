using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicKartMove : MonoBehaviour
{
    [SerializeField] private Rigidbody body;
    [SerializeField] private LayerMask ground;
    private float forwardAmount;
    private float currentSpeed;
    [SerializeField] public float speed;
    float turnAmount;
    [SerializeField] public float turnSpeed;

    private void Start()
    {
        body.transform.parent = null;
    }

    private void Update()
    {
        transform.position = body.transform.position;

        //forwardAmount = Input.GetAxis("Vertical");
        turnAmount = Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.JoystickButton0) || Input.GetKey(KeyCode.Space)) Drive(); 
        else currentSpeed = 0f;

        if (Input.GetKey(KeyCode.Joystick1Button1) || Input.GetKey(KeyCode.LeftShift)) DriveNowhere();

        Turning();
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
        currentSpeed = -speed;
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
