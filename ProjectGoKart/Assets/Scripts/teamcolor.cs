using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teamcolor : MonoBehaviour
{
    [SerializeField]public Material color;

    private HasBall HasBall;


    private void Start()
    {
        Gray();
    }

    private void Update()
    {
        //if (GameObject.Find("Player").GetComponent<HasBall>().hasBall == false) Gray();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && other.GetComponent<HasBall>().hasBall == true) color.SetColor("_Color", Color.red);
        if (other.CompareTag("Enemy") && other.GetComponent<HasBall>().hasBall == true) color.SetColor("_Color", Color.blue);
    }

    public void Gray()
    {
        color.SetColor("_Color", Color.gray);
    }
}
