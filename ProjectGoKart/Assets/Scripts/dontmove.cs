using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontmove : MonoBehaviour
{
    public GameObject drive;

    // Update is called once per frame
    void Update()
    {
       this.transform.position =  drive.transform.position;
    }
}
