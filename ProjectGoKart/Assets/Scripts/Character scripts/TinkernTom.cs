using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TinkernTom : MonoBehaviour
{
    public float powerUp = 0, dash =0;
    public int datime,explosion;
    public GameObject tathrow, boom;
    public GameObject icon1, icon2,icon3;
    bool enoughSlices = true;

    public bool isPlayer1,isPlayer2;

    private BasicKartMove kart;

    public GameObject dashu, spuke;

    public int ani;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PowerUp" && enoughSlices == true) { powerUp = powerUp + 1; }
    }


    // Update is called once per frame
    void Update()
    {
        if (powerUp == 0) { LeanTween.moveX(spuke.GetComponent<RectTransform>(), -250, ani); }//icon1.SetActive(false); icon2.SetActive(false); icon3.SetActive(false); }
        if (dash ==0) { StartCoroutine(Always()); }
        if (dash >= 2) 
        {
            //LeanTween.moveX(dashu, 0, 1);
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
        if (powerUp == 1) { LeanTween.moveX(spuke.GetComponent<RectTransform>(), -125, ani); }
        if (powerUp == 2)
        {
            //icon3.SetActive(true);
            enoughSlices = false;
            LeanTween.moveX(spuke.GetComponent<RectTransform>(), 0, ani);
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
        if (powerUp > 2) { powerUp = 2; }

    }

    IEnumerator Always()
    {
        yield return new WaitForSeconds(3);
        dash = 1;
        LeanTween.moveX(dashu.GetComponent<RectTransform>(), -125,ani);
        yield return new WaitForSeconds(3);
        dash = 2;
        LeanTween.moveX(dashu.GetComponent<RectTransform>(), 0, ani);
    }
    IEnumerator Passive()//Button RB
    {

        //on
        boom.SetActive(true);
        dash = dash - 2;
        StartCoroutine(this.GetComponent<BasicKartMove>().Dash());
        enoughSlices = true;
        LeanTween.moveX(dashu.GetComponent<RectTransform>(), -250f, ani);
        yield return new WaitForSeconds(explosion);
        //off
        //this.GetComponent<BasicKartMove>().speed = 50;
        //icon1.SetActive(false);
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
        //icon3.SetActive(false);
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
        LeanTween.moveX(spuke.GetComponent<RectTransform>(), -250, ani);
        //icon2.SetActive(false); 
        //icon3.SetActive(false);
        tathrow.SetActive(false);
    }
}
