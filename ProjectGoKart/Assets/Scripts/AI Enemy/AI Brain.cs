using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBrain : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject target;
    bool jeff;
    [SerializeField] private float speed;
    [SerializeField] private float targetTimer;

    HasBall hasBall;

    // Update is called once per frame
    void Update()
    {
        if (jeff == true)
        { 
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            transform.forward = player.transform.position - transform.position;
        }

        if (jeff == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
            transform.forward = target.transform.position - transform.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball") jeff = false;
        else jeff = true;
        
        //if (other.tag. player) stop moving 

        //if has the ball then try to score.
    }
}
