using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TinkernTom : MonoBehaviour
{
    public float powerUp = 0;
    public int datime,explosion;
    public GameObject tathrow, boom;
    public GameObject icon1, icon2,icon3;
    bool enoughSlices = true;

    public bool isPlayer1,isPlayer2;

    private BasicKartMove kart;

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
                if (Input.GetAxis("Dash") > 0)
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

        //    if (isPlayer1 == true)
        //    {
        //        if (Input.GetAxis("Tier1") == 1)
        //        {
        //            StartCoroutine(Lasso());
        //        }
        //    }
        //    if (isPlayer2 == true)
        //    {
        //        if (Input.GetAxis("p2Tier1") == 1)
        //        {
        //            StartCoroutine(Lasso());
        //        }
        //    }
        //}
        if (powerUp == 4)
        {
            icon3.SetActive(true);
            enoughSlices = false;

            if (isPlayer1 == true)
            {
                if (Input.GetAxis("Tier2") == 1)
                {
                    StartCoroutine(Spew());
                }
            }
            if (isPlayer2 == true)
            {
                if (Input.GetAxis("p2Tier2") == 1 )
                {
                    StartCoroutine(Spew());
                }
            }
        }
        
        
        //if (powerUp == 0) { icon1.SetActive(false);  }
        if (powerUp > 4) { powerUp = 4; }

    }

    IEnumerator Always()
    {
        yield return new WaitForSeconds(3);
        powerUp = 1;
        yield return new WaitForSeconds(3);
        powerUp = 2;
    }
    IEnumerator Passive()//Button RB
    {

        //on
        boom.SetActive(true);
        powerUp = powerUp - 2;
        StartCoroutine(this.GetComponent<BasicKartMove>().Dash());
        enoughSlices = true;
        yield return new WaitForSeconds(explosion);
        //off
        //this.GetComponent<BasicKartMove>().speed = 50;
        icon1.SetActive(false);
        boom.SetActive(false);
    }
    IEnumerator Lasso()//button x
    {
        //this is tier 2 thing
        //on
        //tathrow.SetActive(true);
        powerUp = powerUp - 4;
        enoughSlices = true;

        print("beep");
        yield return new WaitForSeconds(datime);
        //off

        print("boop");
        icon3.SetActive(false);
        //tathrow.SetActive(false);

    }

    IEnumerator Spew()//Button y
    {

        //on
        tathrow.SetActive(true);
        powerUp = 0;
        enoughSlices = true;
        yield return new WaitForSeconds(datime);
        //off
        icon2.SetActive(false); 
        icon3.SetActive(false);
        tathrow.SetActive(false);
    }
}
