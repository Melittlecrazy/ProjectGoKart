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

    public HasBall hasBall;

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

        if (hasBall.gameObject.GetComponent<HasBall>().hasBall == true)
        {
            //target.gameObject = player.gameObject;
            //pick a random number out of a list and follow it a round in a circle
            //hasBall.gameObject.GetComponent<HasBall>().point2 = hasBall.gameObject.GetComponent<HasBall>().point2 + 1;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball") jeff = false;
        else jeff = true;

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player") StartCoroutine(Boing());
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player") speed = 5;
    }

    IEnumerator Boing()
    {
        yield return new WaitForSeconds(1);
        speed = 0;
        yield return new WaitForSeconds(3);
        speed = 5;
    }
}
