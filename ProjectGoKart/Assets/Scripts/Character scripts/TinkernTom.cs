using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TinkernTom : MonoBehaviour
{
    public float powerUp = 0;
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
        if (powerUp >= 4) { icon2.SetActive(true); }
        if (powerUp >= 6) { icon3.SetActive(true); enoughSlices = false; }
    }
}
