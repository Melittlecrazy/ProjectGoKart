using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolLife : MonoBehaviour
{
    public int StunTimer;
    //public float hit;
    //public GameObject wall;
    bool grow;

    Vector3 scaleChange = new Vector3(0.01f, 0.01f, 0.01f);

    private void OnEnable()
    {
        grow = true;
        StartCoroutine(shrink());
    }
    private void Update()
    {
        if (grow == false)
        {
            this.transform.localScale -= scaleChange;
        }
        //    if (StunTimer > 0)
        //    {
        //        StunTimer -= Time.deltaTime;
        //        //return;  // you are stunned, sit still!
        //    }
        //    if (StunTimer == 0) shrink();
    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Respawn")
        {
            //StunTimer += hit;

            //wall.SetActive(false);

            

        }
    }

    public IEnumerator shrink()
    {
        print("OH YEAAAA!");
        yield return new WaitForSeconds(StunTimer);
        grow = false;
        yield return new WaitForSeconds(.25f);
        Destroy(this.gameObject);
    }
}
