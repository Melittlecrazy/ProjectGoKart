using UnityEngine;
using UnityEngine.InputSystem;

public class NewInputDriving : MonoBehaviour
{
    [SerializeField] float speed;
    Rigidbody rb;
    private bool isAccelerating,isReversing;
    private Vector2 moveInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        Debug.Log($"Move Input: {moveInput}");

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
    }
}
