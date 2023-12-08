using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Pathfinding : MonoBehaviour
{
    public GameObject start;
    public GameObject mid;

    public TextMeshProUGUI daLap;

    int lap;
    public int seconds;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            lap = lap + 1;
            daLap.text = "" + lap;
            StartCoroutine(Laps());
        }
    }

    IEnumerator Laps()
    {
        start.SetActive(false);
        yield return new WaitForSeconds(seconds);
        start.SetActive(true);
    }
}
