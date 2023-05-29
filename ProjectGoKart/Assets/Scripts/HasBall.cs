using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasBall : MonoBehaviour
{
    public GameObject Ball;
    public GameObject trail;

    bool particle = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ball") trail.SetActive(true);
    }
}
