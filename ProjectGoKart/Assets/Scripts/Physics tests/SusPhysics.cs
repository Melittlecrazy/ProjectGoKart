using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SusPhysics : MonoBehaviour
{
    public float position = 0;
    public float velcoity = 0;

    // Update is called once per frame
    void Update()
    {
        float deltaTime = Time.deltaTime;

        //CalcDampedSimpleHarmonicMotion(ref position, ref velocity, goalPosition, deltaTime), frequency, damping;

        //transform.position = Vector3.right * position;

        OnSpringValue(position);
    }

    public void OnSpringValue(float springValue)
    {

    }
        //if (rayDidHit)
        //{
        //    Vector3 springDir = tireTransform.up;

        //    Vector3 tireWorldVel = carRidgidBody.GetPointVelocity(tireTransform.position);

        //    float offset = suspensionResDist - tireRay.distiance;

        //    float vel = Vector3.Dot(springDir, tireWorldVel);

        //    float force = (offset * spingStrength) - (vel - springDamper);

        //    carRigidBody.AddForceAtPosition(springDir * force, tireTransform.position);
        //}
    

    public static void CalcDampedSimpleHarmonicMotion(
        ref float position, ref float velocity, float equilibriumPostion, float deltaTime, float angularFrequency, float dampingRatio)
    { }
}
