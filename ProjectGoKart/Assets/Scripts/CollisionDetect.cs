using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetect : MonoBehaviour
{
    float impactSpeed;
    public Collider col;

    private void OnCollisionEnter(Collision col)
    {
        impactSpeed = col.relativeVelocity.magnitude;
    }
}
