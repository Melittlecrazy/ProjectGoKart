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
        StartCoroutine(Gray());
    }

    private void Update()
    {
        if (checkpoints.GetComponent<Scoring>().player1score == 0) StartCoroutine(Gray());
        if (checkpoints.GetComponent<Scoring>().player2score == 0) StartCoroutine(Gray());
    }

    private void OnTriggerEnter(Collider other)
    {
         if (other.gameObject.CompareTag("Player") && other.gameObject.GetComponent<HasBall>().hasBall == true) 
        { 
            kart.material.color = Color.red; 
        }
        if (other.gameObject.tag == "Enemy" && other.gameObject.GetComponent<HasBall>().hasBall == true) 
        { 
            kart.material.color = Color.blue; 
        }
    }
    public IEnumerator Gray()
    {
        yield return new WaitForSeconds(.5f);
        kart.material.color = Color.white;
        yield return new WaitForSeconds(1);
        checkpoints.GetComponent<Scoring>().player1score = 1;
        checkpoints.GetComponent<Scoring>().player2score = 1;
    }
}
