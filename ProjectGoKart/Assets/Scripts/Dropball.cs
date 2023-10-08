using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropball : MonoBehaviour
{
    public Material daball;
    public Rigidbody rb;
    [SerializeField] GameObject bob;
    HasBall hasball;

    void Start()
    {
        hasball = GetComponent<HasBall>();
    }

    void Update()
    {
        
    }


    private void OnCollisionEnter(Collision col)
    {


        if (col.gameObject.tag == "Respawn")
        {
            this.transform.parent = null;
            daball.SetColor("_Color", Color.grey);
            rb.constraints = RigidbodyConstraints.None;
            //hasball.hasBall = false;
        }
    }
}
