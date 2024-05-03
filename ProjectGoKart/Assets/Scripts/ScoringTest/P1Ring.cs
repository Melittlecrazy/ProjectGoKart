using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1Ring : MonoBehaviour
{
    public Renderer kart;

    private HasBall HasBall;
    public GameObject checkpoints;

    public bool p1activated, p2activated;


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
        if (!p1activated)
        {
            if (other.gameObject.CompareTag("Player") && other.gameObject.GetComponent<HasBall>().hasBall == true)
            {
                checkpoints.GetComponent<Scoring>().player1score = checkpoints.GetComponent<Scoring>().player1score + 1f - 1f;
                kart.material.color = Color.red;
                p1activated = true;
            }
            //if (other.gameObject.tag == "Enemy" && other.gameObject.GetComponent<HasBall>().hasBall == true)
            //{
            //    kart.material.color = Color.white;
            //    //    p2activated = true;
            //    checkpoints.GetComponent<Scoring>().player1score = checkpoints.GetComponent<Scoring>().player1score - .5f;
            //}
    }
    }
    public IEnumerator Gray()
    {
        yield return new WaitForSeconds(.5f);
        kart.material.color = Color.white;
        yield return new WaitForSeconds(1);
        checkpoints.GetComponent<Scoring>().player1score = 1;
        checkpoints.GetComponent<Scoring>().player2score = 1;
        p1activated = false;
        p2activated = false;
    }
}
