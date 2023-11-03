using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockbackOnCollision : MonoBehaviour
{
    [SerializeField] private float knockbackStrength;
    [SerializeField] private bool isBumpedP1, isBumpedP2;
    [SerializeField] private float stunTimer;

    private void OnCollisionEnter(Collision collision)
    {
        BasicKartMove moveScript = GetComponent<BasicKartMove>();
        Rigidbody rb = collision.collider.GetComponent<Rigidbody>();

        if (rb != null)
        {
            Vector3 direction = collision.transform.position - transform.position;
            direction.y = 0f;

            rb.AddForce(direction.normalized * knockbackStrength, ForceMode.VelocityChange);

            if(collision.gameObject.tag == "Player")
            {
                isBumpedP1 = true;
                if(stunTimer > 0f && isBumpedP1 == true)
                {
                    stunTimer -= Time.deltaTime;
                    moveScript.currentSpeed1 = 0f;
                }
                if (stunTimer <= 0f)
                {
                    moveScript.currentSpeed1 = moveScript.speed;
                }
                

            }
            if(collision.gameObject.tag == "Enemy")
            {
                isBumpedP2 = true;
                if (stunTimer > 0f && isBumpedP2 == true)
                {
                    stunTimer -= Time.deltaTime;
                    moveScript.currentSpeed2 = 0f;
                }
                if (stunTimer <= 0f)
                {
                    moveScript.currentSpeed2 = moveScript.speed;
                }
            }
        }

    }
}
