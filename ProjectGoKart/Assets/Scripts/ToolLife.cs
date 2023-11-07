using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolLife : MonoBehaviour
{
    public int StunTimer;
    //public float hit;
    //public GameObject wall;

    Vector3 scaleChange = new Vector3(-0.01f, -0.01f, -0.01f);

    private void OnEnable()
    {
        StartCoroutine(shrink());
    }
    //private void Update()
    //{

    //    if (StunTimer > 0)
    //    {
    //        StunTimer -= Time.deltaTime;
    //        //return;  // you are stunned, sit still!
    //    }
    //    if (StunTimer == 0) shrink();
    //}
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
        this.transform.localScale += scaleChange;

        yield return new WaitForSeconds(StunTimer);

        Destroy(this.gameObject);
    }
}
