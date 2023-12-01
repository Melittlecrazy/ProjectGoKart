using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject target;
    [SerializeField] private float speed;

    HasBall hasBall;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        transform.forward = player.transform.position - transform.position;
    }

    private void OnCollisionStay(Collision collision)
    {
        //if (collision.gameObject.tag == "Ball")
        //{
        //    speed = 0;
        //}
        ////else speed = 10;
        //if (collision.gameObject.tag != "Ball") { speed = 10;}
    }
}
