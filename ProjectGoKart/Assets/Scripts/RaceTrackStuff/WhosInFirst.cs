using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhosInFirst : MonoBehaviour
{
    public GameObject cp, checkHold;

    public GameObject[] cars,forEachCar;
    public Transform[] checkPos;

    private int totalCars, totalCheckpoints;

    private void Start()
    {
        totalCars = cars.Length;
        totalCheckpoints = checkHold.transform.childCount;


    }

    void setCheckpoints()
    {
        checkPos = new Transform[totalCheckpoints];

        for (int i =0; i < totalCheckpoints; i++)
        {
            checkPos[i] = checkHold.transform.GetChild(i).transform;
        }
    }

    private void Update()
    {
        
    }
}
