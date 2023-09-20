using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HasBall : MonoBehaviour
{
    public GameObject ball;
    public GameObject trail, quadMan;
    public MeshRenderer quad1,quad2,quad3,quad4;
    public Material quadOne,quadTwo,quadThree,quadFour;
    public int point = 0;
    public TextMeshProUGUI score;

    bool particle = false;
    bool hasBall = false;



    void Start()
    {
        score = FindObjectOfType<TextMeshProUGUI>();
     
        quadOne.SetColor("_Color", Color.white);
        quadTwo.SetColor("_Color", Color.white);
        quadThree.SetColor("_Color", Color.white);
        quadFour.SetColor("_Color", Color.white);
        
        score.text = "Score: " + point;
        quadMan.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score: " + point;
        if (point == 4)
        {
            score.text = "WINNER";
            quadMan.SetActive(false);
        }
    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ball")
        {
            trail.SetActive(true);
            hasBall = true; 
        }
        if (col.gameObject.tag == "Enemy")
        {
            trail.SetActive(false);
            hasBall = false;
        }


        //quadTwo.SetColor()
    }
    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.name == "quad1" && hasBall == true) { QuadA(); quadOne.SetColor("_Color", Color.red); point = point + 1; quad1.enabled = true; }
        if (other.gameObject.name == "quad2" && hasBall == true) { QuadB(); quadTwo.SetColor("_Color", Color.red); point = point + 1; quad2.enabled = true; }
        if (other.gameObject.name == "quad3" && hasBall == true) { QuadC(); quadThree.SetColor("_Color", Color.red); point = point + 1; quad3.enabled = true; }
        if (other.gameObject.name == "quad4" && hasBall == true) { QuadD(); quadFour.SetColor("_Color", Color.red); point = point + 1; quad4.enabled = true; }

    }
    void QuadA()
    {
        //quad1.enabled= true;
        //quad2.enabled = true;
        //quad3.enabled = true;
        quad4.enabled= true;
    }
    void QuadB()
    {
        quad1.enabled= true;
        //quad2.enabled= true;
        //quad3.enabled= true;
        //quad4.enabled= true;
    }
    void QuadC()
    {
        //quad1.enabled= true;
        quad2.enabled= true;
        //quad3.enabled= true;
        //quad4.enabled= true;
    }
    void QuadD()
    {
        //quad1.enabled= true;
        //quad2.enabled= true;
        quad3.enabled= true;
        //quad4.enabled= true;
    }
}
