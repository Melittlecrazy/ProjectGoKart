using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicKartMove : MonoBehaviour
{
    [SerializeField] private Rigidbody body;
    private float forwardAmount;
    private float currentSpeed;
    public float speed = 1f;

    private void Start()
    {
        body.transform.parent = null;
    }

    private void Update()
    {
        transform.position = body.transform.position;

        forwardAmount = Input.GetAxis("Vertical");

        if (forwardAmount != 0) Drive();

    }
    private void FixedUpdate()
    {
        body.AddForce(transform.forward * currentSpeed, ForceMode.Acceleration);
    }

    private void Drive()
    {
        currentSpeed = forwardAmount *= speed;
    }
    //void DriveBack()
    //{
    //    currentSpeed = forwardAmount *= speed;
    //}
}
