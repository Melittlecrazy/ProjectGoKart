using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spewingtools : MonoBehaviour
{
    public GameObject[] tools;
    public Transform fireplace;
    public int daforce;


    // Update is called once per frame
    void FixedUpdate()
    {
        fire();
    }

    private void fire()
    {
        foreach (GameObject Tool in tools)
        {
            Instantiate(Tool,fireplace.position, fireplace.rotation);
            Rigidbody rb = Tool.GetComponent<Rigidbody>();
            //rb.AddForce(fireplace.forward * daforce, ForceMode.Acceleration);
            rb.velocity = (Vector3.forward * daforce);
        }
    }
}
