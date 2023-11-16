using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Lasso : MonoBehaviour
{
    public float speed, duration, stopDistance, castRange;
    public bool keepY;
    public LayerMask layerMask;
    public string[] enemies;

    Transform target, camTrans;
    LineRenderer lineRend;
    Vector3 destanation;
    float timer;


    void Start()
    {
        camTrans = Camera.main.transform;
        lineRend = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            AssignLasso();
        }

        if (target)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else FinishLasso();
        }
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance > stopDistance)
        {
            destanation = transform.position + ((target.position - transform.position).normalized * stopDistance);
            if (keepY)
            {
                destanation.y = target.position.y;
            }
        }
        else
        {
            destanation = transform.position;
        }

        target.position = Vector3.Lerp(target.position,destanation,speed * Time.deltaTime);

        lineRend.SetPosition(1, target.position);
    }


    void AssignLasso()
    {
        if (target)
            return;
        RaycastHit hit;
        if (Physics.Raycast(camTrans.position,camTrans.forward, out hit, castRange,layerMask))
        {
            if (enemies.Contains(hit.transform.tag))
            {
                timer = duration;
                target = hit.transform;
                lineRend.enabled = true;

                hit.transform.GetComponent<BasicKartMove>().speed = 0;
            }
        }
    }

    void FinishLasso()
    {
        target.GetComponent<BasicKartMove>().speed = 50;

        lineRend.enabled = false;
        target = null;
    }
}
