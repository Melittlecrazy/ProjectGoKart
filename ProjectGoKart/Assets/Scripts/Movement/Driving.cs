using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Driving : MonoBehaviour
{
    private PlayerInput drive;
    private Rigidbody kart;
    private Drivng move;
    Vector2 bob;

    // Update is called once per frame
    //void Update()
    //{
    //    if (Gamepad.current == null)
    //        return;

    //   // if (Gamepad.current.leftStick.ReadValue() == -1);

    //    if(Gamepad.current.buttonSouth.isPressed)
    //    {
    //        print("george");
    //    }

    //}

    private void Awake()
    {
        kart = GetComponent<Rigidbody>();
        drive = GetComponent<PlayerInput>();

        Drivng move = new Drivng();
        move.Drive.Enable();
        //move.Drive.DriveForward.performed += MoveForward;
    }
    private void FixedUpdate()
    {
        float speed = 5f;
        if (Gamepad.current.buttonSouth.isPressed)
        { 
            kart.AddForce(bob.x, 0, 0 * speed * Time.deltaTime);
        }
    }

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }
}
