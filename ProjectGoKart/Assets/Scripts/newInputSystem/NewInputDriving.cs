using UnityEngine;
using UnityEngine.InputSystem;

public class NewInputDriving : MonoBehaviour
{
    [SerializeField] float speed, turnSpeed;
    Rigidbody rb;
    private bool isAccelerating,isReversing;
    private Vector2 moveInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
        //moveInput = new Vector2(0,0);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        Debug.Log($"Move Input: {moveInput}");
        //var rotate = moveInput.Player
        //transform.Rotate.y = moveInput;
    }

    public void OnForward(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            isAccelerating = true;
        }

        if (context.canceled)
        {
            isAccelerating = false;
        }
    }
    public void OnReverse(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            isReversing = true;
        }

        if (context.canceled)
        {
            isReversing = false;
        }
    }
    void FixedUpdate()
    {
        if (isAccelerating)
        {
            rb.AddForce(transform.forward * speed, ForceMode.Acceleration);
        }
        if (isReversing)
        {
            rb.AddForce(transform.forward * -speed, ForceMode.Acceleration);
        }
        if (moveInput.x > 0)
        {
            transform.Rotate(new Vector2(0, turnSpeed));
        }
        if (moveInput.x < 0)
        {
            transform.Rotate(new Vector2(0,-turnSpeed));
        }

    }
}
