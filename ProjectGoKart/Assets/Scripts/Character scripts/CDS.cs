using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CDS : MonoBehaviour
{
    public float powerUp = 0;
    public int datime;
    public GameObject box;
    public GameObject icon1, icon2, icon3;
    bool enoughSlices = true;

    public GameObject[] clowns; 


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PowerUp" && enoughSlices == true) { powerUp = powerUp + 1; }
    }

    // Update is called once per frame
    void Update()
    {
        if (powerUp >= 2) { icon1.SetActive(true); }//StartCoroutine(Spew());
        if (powerUp >= 4) { icon2.SetActive(true);  }
        if (powerUp >= 6) { icon3.SetActive(true); enoughSlices = false; }
    }


    private void OnCollisionEnter(Collision col)
    {
        foreach (GameObject clown in clowns)
        {
            Instantiate(clown, box.transform.position, box.transform.rotation);
        }
    }

    IEnumerator Spew()
    {
        //on
        //tathrow.SetActive(true);
        yield return new WaitForSeconds(datime);
        //off
        //tathrow.SetActive(false);

    }
}
