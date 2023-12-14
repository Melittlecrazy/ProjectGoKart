using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropball : MonoBehaviour
{
    public Material daball;
    public Rigidbody rb;
    [SerializeField] GameObject bob;
    //public HasBall hasball;

    public GameObject arrow;
    bool tut;

    void Start()
    {
        //hasball = GetComponent<HasBall>();
        tut = false;
    }

    void Update()
    {
        
    }


    private void OnCollisionEnter(Collision col)
    {
        //hasball = col.getcomponant<hasball>().hasball = true;

        if (col.gameObject.tag == "Respawn")
        {
            this.transform.parent = null;
            daball.SetColor("_Color", Color.grey);
            rb.constraints = RigidbodyConstraints.None;
            //hasball.GetComponent<HasBall>().hasBall = false;
        }
        if ((col.gameObject.tag == "Enemy" && tut==false)|| (col.gameObject.tag == "Player" && tut==false))
        {
            //hasball = new GetComponent<HasBall>().hasball = true;
            StartCoroutine(Arrowed());
            tut = true;
        }
    }
    IEnumerator Arrowed()
    {
        arrow.SetActive(true);
        yield return new WaitForSeconds(3);
        arrow.SetActive(false);
    }
}
