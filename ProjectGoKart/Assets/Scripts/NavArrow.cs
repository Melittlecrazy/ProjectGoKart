using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavArrow : MonoBehaviour
{
    [SerializeField] GameObject target;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.forward = target.transform.position - transform.position;
    }
}
