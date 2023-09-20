using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.ProBuilder.Shapes;

[RequireComponent(typeof(CharacterController))]
public class KArtDrive : MonoBehaviour
{
    private Driving controller;



    private float _rotateSpeed = 50f;
    public float playerSpeed;


    private Vector3 movementUnput,playerVelocity;
    private bool driven;

    Rigidbody rb;


    private void Awake()
    {
        //controller = gameObject.GetComponent<CharacterController>();
        //rb = gameObject.GetComponent<Rigidbody>();
        //controller = new 


    }

    public void OnReverse(InputAction.CallbackContext con)
    {
        if (con.performed)
        {
            movementUnput = con.ReadValue<Vector3>();
            rb.AddForce(playerVelocity.x, 0, 0 * -playerSpeed * Time.deltaTime);
        }
    }

    public void OnDrive(InputAction.CallbackContext con)
    {
        //driven = context.ReadValue<bool>();
        //driven = context.action.triggered;
        if (con.performed)
        {
            movementUnput = con.ReadValue<Vector3>();
            rb.AddForce(playerVelocity.x, 0, 0 * playerSpeed * Time.deltaTime);
        }
    }

    public void OnTurn(InputAction.CallbackContext cont)
    {
        //Debug.Log("Current rotation is " + _dogInput.Dog.Rotate.ReadValue<float>());
        //float rotateDirection = this.rb.Rotate.ReadValue<float>();
        if (cont.performed)
        {
            // movementUnput = cont.ReadValue<Vector2>();
            transform.Rotate(Vector3.left * Time.deltaTime * _rotateSpeed * 2);
        }
    }

    void Update()
    {
        var gamepad = Gamepad.current;
        if (gamepad != null) return;
        //OnTurn();
    }

    private void OnEnable()
    {
        //controller.Drive.Enable();
    }

    private void OnDisable()
    {
        //controller.Drive.Disable();
    }
}
