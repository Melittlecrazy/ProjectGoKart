using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teamcolor : MonoBehaviour
{
    public Renderer kart;

    private HasBall HasBall;
    public GameObject checkpoints;


    private void Start()
    {
        checkpoints.GetComponent<Scoring>();
        Gray();
    }

    private void Update()
    {
        if (checkpoints.GetComponent<Scoring>().player1score == 0) Gray();
        if (checkpoints.GetComponent<Scoring>().player2score == 0) Gray();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && other.GetComponent<HasBall>().hasBall == true) { kart.material.color = Color.red; }
        if (other.CompareTag("Enemy") && other.GetComponent<HasBall>().hasBall == true) { kart.material.color = Color.blue; }
    }

    public void Gray()
    {
        kart.material.color = Color.white;
    }
}
