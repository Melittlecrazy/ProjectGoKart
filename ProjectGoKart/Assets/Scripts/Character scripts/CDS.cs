using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class CDS : MonoBehaviour
{
    public float powerUp = 0;
    public int datime;
    public GameObject box,mimes;
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
        if (powerUp == 0) { icon1.SetActive(false); icon2.SetActive(false); icon3.SetActive(false); StartCoroutine(Always()); }
        if (powerUp >= 2) 
        {
            icon1.SetActive(true);
            if (isPlayer1 == true)
            {
                if (Input.GetAxis("Dash") == 1)
                {
                    StartCoroutine(Passive());
                }
            }
            if (isPlayer2 == true)
            {
                if (Input.GetAxis("Passive2") == 1)
                {
                    StartCoroutine(Passive());
                }
            }
             
        }
        //if (powerUp >= 4)
        //{
        //    icon2.SetActive(true);

        //}
        if (powerUp == 4)
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
        if (powerUp > 4) { powerUp = 4; }
    }


    //private void OnCollisionEnter(Collision col)
    //{
    //    foreach (GameObject clown in clowns)
    //    {
    //        if(isPlayer1 == true)
    //        {
    //            if (col.gameObject.tag == "Enemy")
    //            Instantiate(clown, box.transform.position, box.transform.rotation);
    //        }
    //        if (isPlayer2 == true)
    //        {
    //            if (col.gameObject.tag == "Player")
    //            Instantiate(clown, box.transform.position, box.transform.rotation);
    //        }
    //    }
    //}
    IEnumerator Always()
    {
        yield return new WaitForSeconds(3);
        powerUp = 1;
        yield return new WaitForSeconds(3);
        powerUp = 2;
    }
    IEnumerator Delivery()
    {
        
        //on
        mimes.SetActive(true);
        powerUp = 2;
        enoughSlices = true;
        yield return new WaitForSeconds(datime);
        //off
        icon2.SetActive(false);
        icon3.SetActive(false);
        mimes.SetActive(false);
    }
    IEnumerator Passive()//Button LB
    {

        //on
       //box.SetActive(true);
        powerUp = powerUp - 2;
        StartCoroutine(this.GetComponent<BasicKartMove>().Dash());
        enoughSlices = true;
        yield return new WaitForSeconds(2);
        //off
        //this.GetComponent<BasicKartMove>().speed = 50;
        icon1.SetActive(false);
       // box.SetActive(false);
    }
    IEnumerator Tier2()
    {
        //on
        //tathrow.SetActive(true);
        powerUp = 2;
        foreach (GameObject clown in clowns)
        {
            Instantiate(clown, box.transform.position, box.transform.rotation);
        }
        enoughSlices = true;
        yield return new WaitForSeconds(datime);
        //off
        icon2.SetActive(false);
        icon3.SetActive(false);
        //off
        //tathrow.SetActive(false);

    }
}
