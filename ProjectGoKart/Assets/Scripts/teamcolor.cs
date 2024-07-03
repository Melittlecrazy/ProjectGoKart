using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teamcolor : MonoBehaviour
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
                checkpoints.GetComponent<Scoring>().player1score = checkpoints.GetComponent<Scoring>().player1score + 1;
                //other.GetComponent<HasBall>().first = false;
                kart.material.color = Color.red;
                p1activated = true;
                if (p2activated == true) checkpoints.GetComponent<Scoring>().player2score = checkpoints.GetComponent<Scoring>().player2score - 1;
                p2activated = false;
            }
            //if (other.gameObject.tag == "Enemy" && other.gameObject.GetComponent<HasBall>().hasBall == true)
            //{
            //    kart.material.color = Color.blue;
            //    p2activated = true;
            //    checkpoints.GetComponent<Scoring>().player2score = checkpoints.GetComponent<Scoring>().player2score - 1;
            //}
        }

        if (!p2activated)
        {
            if (other.gameObject.tag == "Enemy" && other.gameObject.GetComponent<HasBall>().hasBall == true)
            {
                kart.material.color = Color.blue;
                p2activated = true;
                if (p1activated== true) checkpoints.GetComponent<Scoring>().player1score = checkpoints.GetComponent<Scoring>().player1score - 1;
                //other.GetComponent<HasBall>().first = false;
                p1activated = false;
                checkpoints.GetComponent<Scoring>().player2score = checkpoints.GetComponent<Scoring>().player2score + 1;
            }
        //    if (other.gameObject.CompareTag("Player") && other.gameObject.GetComponent<HasBall>().hasBall == true)
        //    {
        //        checkpoints.GetComponent<Scoring>().player1score = checkpoints.GetComponent<Scoring>().player1score - 1;
        //        kart.material.color = Color.red;
        //        p1activated = true;
        //    }
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
