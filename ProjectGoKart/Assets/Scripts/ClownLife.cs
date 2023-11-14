using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClownLife : MonoBehaviour
{
    public int StunTimer;
    //public float hit;
    //public GameObject wall;
    bool grow;

    Vector3 scaleChange = new Vector3(0.01f, 0.01f, 0.01f);

    private void OnEnable()
    {

    }
    private void Update()
    {
        //if (grow == false)
        //{
        //    this.transform.localScale -= scaleChange;
        //}
        //    if (StunTimer > 0)
        //    {
        //        StunTimer -= Time.deltaTime;
        //        //return;  // you are stunned, sit still!
        //    }
        //    if (StunTimer == 0) shrink();
    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player" || col.gameObject.tag == "Enemy")
        {
            //StunTimer += hit;

            //wall.SetActive(false);


            StartCoroutine(shrink());

        }
    }

    public IEnumerator shrink()
    {
        print("HONK!");
        yield return new WaitForSeconds(StunTimer);
        //grow = true;
        //yield return new WaitForSeconds(.25f);
        //grow = false;
        Destroy(this.gameObject);
    }
}
