using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniMap : MonoBehaviour
{
    public RectTransform referencePoint1;
    public RectTransform referencePoint2;
    public Transform worldPoint1;
    public Transform worldPoint2;

    public RectTransform miniMap;
    public Transform playerWorld;

    float miniMapRatio;


    void Awake()
    {
        //CalculateMapRatio();
    }

    // Update is called once per frame
    void Update()
    {
        miniMap.anchoredPosition = referencePoint1.anchoredPosition + new Vector2((playerWorld.position.x - worldPoint1.position.x) * miniMapRatio, (playerWorld.position.z - worldPoint1.position.z) * miniMapRatio);
    
    
    }

    public void CalculateMapRatio()
    {
        Vector3 distanceWorldVect = worldPoint1.position - worldPoint2.position;
        distanceWorldVect.y = 0f;
        float distanceWor = distanceWorldVect.magnitude;

        float distanceMiniMap = Mathf.Sqrt(
            Mathf.Pow((referencePoint1.anchoredPosition.x - referencePoint2.anchoredPosition.x),2) + 
            Mathf.Pow((referencePoint1.anchoredPosition.y - referencePoint2.anchoredPosition.y),2));

        miniMapRatio = distanceMiniMap / distanceWor;
    }
}
