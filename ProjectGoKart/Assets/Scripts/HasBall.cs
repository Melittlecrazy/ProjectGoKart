using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class HasBall : MonoBehaviour
{
    public GameObject ball;
    public GameObject trail, quadMan, grab;
    public MeshRenderer quad1,quad2,quad3,quad4;
    public Material quadOne,quadTwo,quadThree,quadFour,daball;
    public Rigidbody rigidbody;

    public int point1,point2;
    public TextMeshProUGUI score1, score2;

    bool particle = false;
    public bool hasBall = false,resetted = false;
    public bool isPlayer1, isPlayer2;


    void Start()
    {
        

        quadOne.SetColor("_Color", Color.white);
        quadTwo.SetColor("_Color", Color.white);
        quadThree.SetColor("_Color", Color.white);
        quadFour.SetColor("_Color", Color.white);
        
        //score1.text = "Score: " + point1;
        //score2.text = "Score: " + point2;
        quadMan.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayer1 == true)
        {
            //score1.text = "Score: " + point1;
            if (point1 == 4)
            {
                score1.text = "Score: 1";
                Reset(); point1 = point1 + 1;

            
            //    score1.text = "WIN";
            //    quadMan.SetActive(false);
            //    score2.text = "LOSE";
        }
            if (point1 == 9) { score1.text = "Score: 2"; Reset(); point1 = point1 + 1; }
            if (point1 == 13) { score1.text = "Winner"; score2.text = "Lose"; trail.SetActive(true); }
        }
        if (isPlayer2 == true)
        {
            //score2.text = "Score: " + point2;
            if (point2 == 4)
            {
                score2.text = "Score: 1";

                //    score2.text = "WIN";
                //    quadMan.SetActive(false);
                //    score1.text = "LOSE";
                Reset();
                point2 = point2 + 1;
            }
            if (point2 == 9) { score2.text = "Score: 2"; Reset(); point2 = point2 + 1; }
            if (point2 == 13) { score2.text = "Winner"; score1.text = "Lose"; trail.SetActive(true); }
        }
    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ball")
        {
            //trail.SetActive(true);
            hasBall = true;
            quad1.enabled = true;
            quad2.enabled = true;
            quad3.enabled = true;
            quad4.enabled = true;
        }
        if (col.gameObject.tag == "Enemy" || col.gameObject.tag == "Player") 
        {
            //trail.SetActive(false);
            Reset();
        }

        //quadTwo.SetColor()
    }
    private void OnTriggerExit(Collider other)
    {
        //Red team
        if (other.gameObject.name == "quad1" && hasBall == true && isPlayer1 == true) { QuadA(); quadOne.SetColor("_Color", Color.red); point1 = point1 + 1; quad1.enabled = true; }
        if (other.gameObject.name == "quad2" && hasBall == true && isPlayer1 == true) { QuadB(); quadTwo.SetColor("_Color", Color.red); point1 = point1 + 1; quad2.enabled = true; }
        if (other.gameObject.name == "quad3" && hasBall == true && isPlayer1 == true) { QuadC(); quadThree.SetColor("_Color", Color.red); point1 = point1 + 1; quad3.enabled = true; }
        if (other.gameObject.name == "quad4" && hasBall == true && isPlayer1 == true) { QuadD(); quadFour.SetColor("_Color", Color.red); point1 = point1 + 1; quad4.enabled = true; }

        //Blue team
        if (other.gameObject.name == "quad1" && hasBall == true && isPlayer2 == true) { QuadA(); quadOne.SetColor("_Color", Color.blue); point2 = point2 + 1; quad1.enabled = true; }
        if (other.gameObject.name == "quad2" && hasBall == true && isPlayer2 == true) { QuadB(); quadTwo.SetColor("_Color", Color.blue); point2 = point2 + 1; quad2.enabled = true; }
        if (other.gameObject.name == "quad3" && hasBall == true && isPlayer2 == true) { QuadC(); quadThree.SetColor("_Color", Color.blue); point2 = point2 + 1; quad3.enabled = true; }
        if (other.gameObject.name == "quad4" && hasBall == true && isPlayer2 == true) { QuadD(); quadFour.SetColor("_Color", Color.blue); point2 = point2 + 1; quad4.enabled = true; }

    }
    void QuadA()
    {
        //quad1.enabled = true;
        quad2.enabled = true;
        quad3.enabled = true;
        quad4.enabled = true;
    }
    void QuadB()
    {
        quad1.enabled = true;
        //quad2.enabled = true;
        quad3.enabled = true;
        quad4.enabled = true;
    }
    void QuadC()
    {
        quad1.enabled = true;
        quad2.enabled = true;
        //quad3.enabled = true;
        quad4.enabled = true;
    }
    void QuadD()
    {
        quad1.enabled = true;
        quad2.enabled = true;
        quad3.enabled = true;
        //quad4.enabled = true;
    }

    public void Reset()
    {
        hasBall = false;
        resetted = false;
        trail.SetActive(false);
        quadOne.SetColor("_Color", Color.white);
        quadTwo.SetColor("_Color", Color.white);
        quadThree.SetColor("_Color", Color.white);
        quadFour.SetColor("_Color", Color.white);

        ball.transform.parent = null;
        daball.SetColor("_Color", Color.grey);
        rigidbody.constraints = RigidbodyConstraints.None;
        ball.transform.position = grab.transform.position;


    }

}
