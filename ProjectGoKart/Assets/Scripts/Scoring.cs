using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoring : MonoBehaviour
{
    public int player1score,player2score;


    

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") 
            && other.gameObject.GetComponent<HasBall>().hasBall == true) 
            player1score = player1score + 1;

        //if (other.tag == "Enemy" && other.gameObject.GetComponent<HasBall>().hasBall == true) player2score = player2score + 1;
    }
}
