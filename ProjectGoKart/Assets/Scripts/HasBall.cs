using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;

public class HasBall : MonoBehaviour
{
    public GameObject ball; 
    public Rigidbody rigidball;

    public GameObject trail, quadMan, spawn;
    //public MeshRenderer quad1,quad2,quad3,quad4;
    public Material daball;

    private teamcolor color;

    public GameObject checkpoints;

    public int point1=1,point2=1;
    public TextMeshProUGUI score1, score2;

    bool particle = false;
    public bool hasBall = false,resetted = false, stayed=false;
    public bool isPlayer1, isPlayer2;


    void Start()
    {
        checkpoints.GetComponent<Scoring>();

        //teamcolor color = gameObject.GetComponent<teamcolor>();
        
        //color.Gray();
        
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
            if (checkpoints.GetComponent<Scoring>().player1score == 16)
            {
                score1.text = "Score: " + point1;
                Reset(); 
                point1 = point1 + 1;

            
            //    score1.text = "WIN";
            //    quadMan.SetActive(false);
            //    score2.text = "LOSE";
            }
            //if (checkpoints.GetComponent<Scoring>().player1score == 9) { score1.text = "Score: 2"; Reset(); point1 = point1 + 1; }
            //if (checkpoints.GetComponent<Scoring>().player1score == 14) { score1.text = "Winner"; score2.text = "Lose"; trail.SetActive(true); }
        }
        if (isPlayer2 == true)
        {
            //score2.text = "Score: " + point2;
            if (checkpoints.GetComponent<Scoring>().player2score == 16)
            {
                score2.text = "Score: " + point2;

                //    score2.text = "WIN";
                //    quadMan.SetActive(false);
                //    score1.text = "LOSE";
                Reset();
                point2 = point2 + 1;
            }
            //if (point2 == 9) { score2.text = "Score: 2"; Reset(); point2 = point2 + 1; }
            //if (point2 == 14) { score2.text = "Winner"; score1.text = "Lose"; trail.SetActive(true); }
        }

        //timer
    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ball")
        {
            //trail.SetActive(true);
            hasBall = true;
            
            quadMan.SetActive(true);
        }
        if (col.gameObject.tag == "Enemy" || col.gameObject.tag == "Player") 
        {
            //trail.SetActive(false);
            Drop();
        }

        //quadTwo.SetColor()
    }
//    private void OnTriggerExit(Collider other)
//    {

        
//        ////Red team
//        //if (other.gameObject.name == "quad1" && hasBall == true && isPlayer1 == true) { QuadA(); quadOne.SetColor("_Color", Color.red); point1 = point1 + 1; quad1.enabled = true; }
//        //if (other.gameObject.name == "quad2" && hasBall == true && isPlayer1 == true) { QuadB(); quadTwo.SetColor("_Color", Color.red); point1 = point1 + 1; quad2.enabled = true; }
//        //if (other.gameObject.name == "quad3" && hasBall == true && isPlayer1 == true) { QuadC(); quadThree.SetColor("_Color", Color.red); point1 = point1 + 1; quad3.enabled = true; }
//        //if (other.gameObject.name == "quad4" && hasBall == true && isPlayer1 == true) { QuadD(); quadFour.SetColor("_Color", Color.red); point1 = point1 + 1; quad4.enabled = true; }

//        ////Blue team
//        //if (other.gameObject.name == "quad1" && hasBall == true && isPlayer2 == true) { QuadA(); quadOne.SetColor("_Color", Color.blue); point2 = point2 + 1; quad1.enabled = true; }
//        //if (other.gameObject.name == "quad2" && hasBall == true && isPlayer2 == true) { QuadB(); quadTwo.SetColor("_Color", Color.blue); point2 = point2 + 1; quad2.enabled = true; }
//        //if (other.gameObject.name == "quad3" && hasBall == true && isPlayer2 == true) { QuadC(); quadThree.SetColor("_Color", Color.blue); point2 = point2 + 1; quad3.enabled = true; }
//        //if (other.gameObject.name == "quad4" && hasBall == true && isPlayer2 == true) { QuadD(); quadFour.SetColor("_Color", Color.blue); point2 = point2 + 1; quad4.enabled = true; }
    
        
//}
//    void QuadA()
//    {
//        //quad1.enabled = true;
//        quad2.enabled = true;
//        quad3.enabled = true;
//        quad4.enabled = true;
//    }
//    void QuadB()
//    {
//        quad1.enabled = true;
//        //quad2.enabled = true;
//        quad3.enabled = true;
//        quad4.enabled = true;
//    }
//    void QuadC()
//    {
//        quad1.enabled = true;
//        quad2.enabled = true;
//        //quad3.enabled = true;
//        quad4.enabled = true;
//    }
//    void QuadD()
//    {
//        quad1.enabled = true;
//        quad2.enabled = true;
//        quad3.enabled = true;
//        //quad4.enabled = true;
//    }

    public void Reset()
    {
        hasBall = false;
        resetted = false;
        trail.SetActive(false);

        //teamcolor color = gameObject.GetComponent<teamcolor>();
        
        //color.Gray();


        ball.transform.parent = null;
        daball.SetColor("_Color", Color.grey);
        rigidball.constraints = RigidbodyConstraints.None;
        ball.transform.position = spawn.transform.position;

        checkpoints.GetComponent<Scoring>().player1score = 0;
        checkpoints.GetComponent<Scoring>().player2score = 0;
    }
    public void Drop()
    {
        ball.transform.parent = null;
        daball.SetColor("_Color", Color.grey);
        rigidball.constraints = RigidbodyConstraints.None;
        hasBall = false;
    }
}
