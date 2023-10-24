using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class Spawner : MonoBehaviour
{
    public GameObject powerUp;
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
        print("george");
        yield return new WaitForSeconds(5f);
        //Instantiate(powerUp, this.transform.position, this.transform.rotation);
        powerUp.SetActive(true);
    }
}
