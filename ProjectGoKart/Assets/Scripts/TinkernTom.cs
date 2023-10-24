using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TinkernTom : MonoBehaviour
{
    public float powerUp = 0;
    public GameObject icon1, icon2,icon3;
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "PowerUp") { powerUp = powerUp + 1; }
    }

    // Update is called once per frame
    void Update()
    {
        if (powerUp == 1) icon1.SetActive(true);
        if (powerUp == 2) icon2.SetActive(true);
        if (powerUp == 3) icon3.SetActive(true);
    }
}
