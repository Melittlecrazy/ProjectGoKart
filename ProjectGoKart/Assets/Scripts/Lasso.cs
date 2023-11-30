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

    Transform origin;

    void Start()
    {
        origin = GetComponentInChildren<Transform>();
        camTrans = Camera.main.transform;
        lineRend = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Tier1") == 1)
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

            lineRend.SetPosition(0, transform.position);
            lineRend.SetPosition(1, target.position);
        }
    }


    void AssignLasso()
    {
        if (target)
            return;
        Debug.DrawRay(origin.position, origin.forward * castRange, Color.red,4);
        RaycastHit hit;
        if (Physics.Raycast(origin.position, origin.forward, out hit, castRange,layerMask))
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
        //target.GetComponent<BasicKartMove>().speed = 50;

        lineRend.enabled = false;
        target = null;
    }
}
