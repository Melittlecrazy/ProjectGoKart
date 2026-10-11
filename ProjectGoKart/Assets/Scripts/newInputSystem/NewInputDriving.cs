using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewInputDriving : MonoBehaviour
{
    [SerializeField] public float speed, turnSpeed;
    Rigidbody rb;
    private bool isAccelerating,isReversing;
    private Vector2 moveInput;

    //for knockback, I think
    public float currentSpeed1, currentSpeed2;

    //For the dashing
    [SerializeField] private bool canDash = true;
    [SerializeField] private bool isDashing;
    [SerializeField] public float dashSpeed;
    [SerializeField] private float dashTime;

    //For the Stunned effect
    //public float stun;
    private bool isStunned = false;
    [SerializeField] private GameObject stunEffect;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
        //moveInput = new Vector2(0,0);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        //Debug.Log($"Move Input: {moveInput}");
        //var rotate = moveInput.Player
        //transform.Rotate.y = moveInput;
    }

    public void OnForward(InputAction.CallbackContext context)
    {
        if (context.started && !isStunned)
        {
            isAccelerating = true;
            currentSpeed1 = speed;
        }

        if (context.canceled && !isStunned)
        {
            isAccelerating = false;
        }
    }
    public void OnReverse(InputAction.CallbackContext context)
    {
        if (context.started && !isStunned)
        {
            isReversing = true;
        }

        if (context.canceled && !isStunned)
        {
            isReversing = false;
        }
    }
    public void OnDash(InputAction.CallbackContext context)
    {
        if (context.started && !isStunned)
        {
            if (this.GetComponent<TinkernTom>().dash >= 2)
            {
                StartCoroutine(this.GetComponent<TinkernTom>().Passive());
            }
            //else speed = 50;

                Debug.Log($"Vroom");
        }
    }
    public void OnPause(InputAction.CallbackContext context)
    {
        if (context.started) Debug.Log($"Pause");
    }
    void FixedUpdate()
    {
        if (isAccelerating)
        {
            rb.AddForce(transform.forward * currentSpeed1, ForceMode.Acceleration);
        }
        if (isReversing)
        {
            rb.AddForce(transform.forward * -currentSpeed1, ForceMode.Acceleration);
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
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Tool") StartCoroutine(Stun());
        if (col.gameObject.tag == "Enemy" || col.gameObject.tag == "AI Enemy") StartCoroutine(PlayerCrash(col.gameObject));
    }//col.gameObject.tag == "Player" || 

    IEnumerator PlayerCrash(GameObject kart)
    {
        //BasicKartMove script = kart.GetComponent<BasicKartMove>();

        if (currentSpeed1 < currentSpeed2 && !isStunned)// && isPlayer1)
        {
            isStunned = true;
            stunEffect.SetActive(true);
            StartCoroutine(Stun());
        }
        //if (currentSpeed2 < script.currentSpeed1 && isPlayer2 == true && !isStunned)
        //{
        //    isStunned = true;
        //    stunEffect.SetActive(true);
        //    StartCoroutine(Stun());
        //}
        yield return new WaitForSeconds(3);
    }
    IEnumerator Stun()
    {
        //if (isPlayer1 == true) 
            currentSpeed1 = 0;
            speed = 0;
        //if (isPlayer2 == true) speed = 0;
        stunEffect.SetActive(true);
        yield return new WaitForSeconds(5);
        //if (isPlayer1 == true)
        //{
            isStunned = false;
        speed = 50;
        currentSpeed1 = speed;
        stunEffect.SetActive(false);
        //}
        //if (isPlayer2 == true)
        //{
        //    isStunned = false;
        //    speed = 50;
        //    stunEffect.SetActive(false);
        //}
    }

    public IEnumerator Dash()
    {
        float startTime = Time.time;

        while (Time.time < startTime + dashTime)
        {
            //if (isPlayer1)
                currentSpeed1 = speed * dashSpeed;
            //if (isPlayer2)
            //    currentSpeed2 = speed * dashSpeed;

            yield return null;
        }
    }
}
