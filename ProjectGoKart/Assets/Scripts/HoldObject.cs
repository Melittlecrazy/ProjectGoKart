using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldObject : MonoBehaviour
{
    //[SerializeField] Transform hold;
    private GameObject holdObj;
    private Rigidbody rigidbody;
    //public ;
    public GameObject ball;
    public GameObject grab;
    [SerializeField] float speed = 1.5f;

    //[SerializeField] private float pickupRan = 5f;
    //[SerializeField] private float pickupFor = 5f;

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ball")
        {
            ball.transform.parent = grab.transform;
        }

        if (col.gameObject.tag == "Grabbed") ball.transform.position = Vector3.MoveTowards(transform.position, grab.transform.position, speed * Time.deltaTime);
    }

    private void Update()
    {
        
    }

    //void MoveObj()
    //{
    //    if (Vector3.Distance(holdObj.transform.position, hold.position) > 0.1f)
    //    {
    //        Vector3 moveDirection = (hold.position - holdObj.transform.position);
    //        rigidbody.AddForce(moveDirection * pickupFor);
    //    }
    //}
    //void Pickup(GameObject pickObj)
    //{
    //    if (pickObj.GetComponent<Rigidbody>())
    //    {
    //        rigidbody = pickObj.GetComponent<Rigidbody>();
    //        rigidbody.useGravity = false;
    //        rigidbody.drag = 10;
    //        rigidbody.constraints = RigidbodyConstraints.FreezeRotation;

    //        rigidbody.transform.parent = hold;
    //        holdObj = pickObj;
    //    }
    //}
    //void Drop()
    //{
    //        rigidbody.useGravity = false;
    //        rigidbody.drag = 1;
    //        rigidbody.constraints = RigidbodyConstraints.None;

    //        rigidbody.transform.parent = null;
    //        holdObj = null;

    //}
}
