using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public GameObject self;
    public float span;
    public Vector3 vroom = new Vector3 ();

    // Update is called once per frame
    void Update()
    {
        self.transform.Rotate(span * vroom * Time.deltaTime);
    }
}
