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
    public bool isPlayer1, isPlayer2;

    public GameObject[] clowns; 


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PowerUp" && enoughSlices == true) { powerUp = powerUp + 1; }
    }

    // Update is called once per frame
    void Update()
    {
        if (powerUp >= 2) { icon1.SetActive(true); }
        if (powerUp >= 4)
        {
            icon2.SetActive(true);

            if (isPlayer1 == true)
            {
                if (Input.GetAxis("Tier1") == 1)
                {
                    StartCoroutine(Delivery());
                }
            }
            if (isPlayer2 == true)
            {
                if (Input.GetAxis("p2Tier1") == 1)
                {
                    StartCoroutine(Delivery());
                }
            }
        }
        if (powerUp == 6)
        {
            icon3.SetActive(true);
            enoughSlices = false;

            if (isPlayer1 == true)
            {
                if (Input.GetAxis("Tier2") == 1)
                {
                    StartCoroutine(Tier2());
                }
            }
            if (isPlayer2 == true)
            {
                if (Input.GetAxis("p2Tier2") == 1)
                {
                    StartCoroutine(Tier2());
                }
            }
        }


        //if (powerUp == 0) { icon1.SetActive(false);  }
        if (powerUp > 6) { powerUp = 6; }
    }


    private void OnCollisionEnter(Collision col)
    {
        foreach (GameObject clown in clowns)
        {
            if(isPlayer1 == true)
            {
                if (col.gameObject.tag == "Enemy")
                Instantiate(clown, box.transform.position, box.transform.rotation);
            }
            if (isPlayer2 == true)
            {
                if (col.gameObject.tag == "Player")
                Instantiate(clown, box.transform.position, box.transform.rotation);
            }
        }
    }

    IEnumerator Delivery()
    {
        //on
        //tathrow.SetActive(true);
        foreach (GameObject clown in clowns)
        {
            Instantiate(clown, box.transform.position, box.transform.rotation);
        }
        yield return new WaitForSeconds(datime);
        //off
        //tathrow.SetActive(false);

    }

    IEnumerator Tier2()
    {
        //on
        //tathrow.SetActive(true);
        yield return new WaitForSeconds(datime);
        //off
        //tathrow.SetActive(false);

    }
}
