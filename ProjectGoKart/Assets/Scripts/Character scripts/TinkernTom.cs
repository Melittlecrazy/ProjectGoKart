using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TinkernTom : MonoBehaviour
{
    public float powerUp = 0;
    public int datime;
    public GameObject tathrow;
    public GameObject icon1, icon2,icon3;
    bool enoughSlices = true;


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
            if (Input.GetAxis("Tier1") == 1)
            {
                StartCoroutine(Spew()); 
            }
            if (Input.GetAxis("p2Tier1") == 1)
            {
                StopCoroutine(Spew());
            }
        }
        if (powerUp == 6)
        {
            icon3.SetActive(true);
            enoughSlices = false;


            if (Input.GetAxis("Tier2") == 1)
            {

            }


            if (Input.GetAxis("p2Tier2") == 1)
            {


            }
        }
        
        
        //if (powerUp == 0) { icon1.SetActive(false);  }
        //if (powerUp == 4) {  }

    }



    IEnumerator Spew()
    {
        //on
        tathrow.SetActive(true);
        powerUp = powerUp - 2;
        enoughSlices = true;
        yield return new WaitForSeconds(datime);
        //off
        icon2.SetActive(false);
        tathrow.SetActive(false);

    }

    //IEnumerator Tier2()
    //{ this is tier 2 thing
    //    //on
    //    tathrow.SetActive(true);
    //    yield return new WaitForSeconds(datime);
    //    //off
    //    icon3.SetActive(false);
    //    tathrow.SetActive(false);

    //}
}
