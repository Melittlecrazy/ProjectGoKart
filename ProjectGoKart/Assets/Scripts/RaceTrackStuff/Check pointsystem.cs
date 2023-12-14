using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Checkpointsystem : MonoBehaviour
{
    public int player1score, player2score;

    public TextMeshProUGUI p1, p2;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player1score = player1score + 1;
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            player2score = player2score + 1;
        }
    }

    private void Update()
    {
        if (player1score > player2score) p1.text = "1";
        else p1.text = "2";

        if (player2score > player1score) p2.text = "1";
        else p2.text = "2";
    }
}
