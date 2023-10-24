using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class Spawner : MonoBehaviour
{
    public GameObject powerUp;
    public int timer;
    public bool spawn;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
           
            StartCoroutine(Spawn());
        }
    }

    IEnumerator Spawn()
    {
        powerUp.SetActive(false);
        GetComponent<BoxCollider>().enabled = false;
        print("george");
        yield return new WaitForSeconds(timer);
        //Instantiate(powerUp, this.transform.position, this.transform.rotation);
        powerUp.SetActive(true);
        GetComponent<BoxCollider>().enabled = true;
    }
}
