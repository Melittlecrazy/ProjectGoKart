using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldObject : MonoBehaviour
{
    //[SerializeField] Transform hold;
    private GameObject holdObj;
    [SerializeField] private Rigidbody rigidbody;
    //public ;
    public GameObject ball;
    public GameObject grab;
    [SerializeField] float speed = 1.5f;
    public Material daball;

    public bool isPlayer1, isPlayer2;

    //[SerializeField] private float pickupRan = 5f;
    //[SerializeField] private float pickupFor = 5f;

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ball")
        {
            ball.transform.parent = grab.transform;
            ball.transform.position = grab.transform.position;
            rigidbody.constraints = RigidbodyConstraints.FreezePosition;
            
            if (isPlayer1 == true) daball.SetColor("_Color", Color.red);
            if (isPlayer2 == true) daball.SetColor("_Color", Color.blue);
            
        }

        if (col.gameObject.CompareTag("Enemy")  || col.gameObject.CompareTag("Player"))
        {
            Drop();
        }
        if (col.gameObject.CompareTag("Respawn")) ; //print("If you're reading this... why?");
    }
    

    private void Start()
    {
        daball.SetColor("_Color", Color.grey);
    }

    public void Drop()
    {
        ball.transform.parent = null;
        daball.SetColor("_Color", Color.grey);
        rigidbody.constraints = RigidbodyConstraints.None;
    }
}
