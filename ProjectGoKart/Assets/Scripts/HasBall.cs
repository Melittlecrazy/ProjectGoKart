using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class HasBall : MonoBehaviour
{
    public GameObject ball; 
    public Rigidbody rigidball;

    public GameObject trail, quadMan, spawn;
    //public MeshRenderer quad1,quad2,quad3,quad4;
    public Renderer daball;

    private teamcolor color;

    public GameObject checkpoints;

    public int point1=1,point2=1;
    public TextMeshProUGUI score1, score2;

    bool particle = false;
    public bool hasBall = false,resetted = false, stayed=false;
    public bool isPlayer1, isPlayer2,endlessMode=true;

    string credits = "Credits";

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
            if (checkpoints.GetComponent<Scoring>().player1score == 17)
            {
                score1.text = "Score: " + point1;
                Reset(); 
                point1 = point1 + 1;

            }

            if (endlessMode == false)
            {
                if (point1 == 5)
                {
                    score1.text = "WIN";

                    score2.text = "LOSE";
                    StartCoroutine(Credits());
                }
            }
            //    
            //    quadMan.SetActive(false);
            //    
            
            //if (checkpoints.GetComponent<Scoring>().player1score == 9) { score1.text = "Score: 2"; Reset(); point1 = point1 + 1; }
            //if (checkpoints.GetComponent<Scoring>().player1score == 14) { score1.text = "Winner"; score2.text = "Lose"; trail.SetActive(true); }
        }
        if (isPlayer2 == true)
        {
            //score2.text = "Score: " + point2;
            if (checkpoints.GetComponent<Scoring>().player2score == 17)
            {
                score2.text = "Score: " + point2;

                //    score2.text = "WIN";
                //    quadMan.SetActive(false);
                //    score1.text = "LOSE";
                Reset();
                point2 = point2 + 1;
            }
            if (endlessMode == false)
            {
                if (point2 == 5)
                {
                    score2.text = "WIN";

                    score1.text = "LOSE";
                    StartCoroutine(Credits());
                }
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


    public void Reset()
    {
        hasBall = false;
        resetted = false;
        trail.SetActive(false);

        //teamcolor color = gameObject.GetComponent<teamcolor>();
        
        //color.Gray();


        ball.transform.parent = null;
        daball.material.color = Color.white;
        rigidball.constraints = RigidbodyConstraints.None;
        ball.transform.position = spawn.transform.position;

        checkpoints.GetComponent<Scoring>().player1score = 0;
        checkpoints.GetComponent<Scoring>().player2score = 0;
    }
    public void Drop()
    {
        ball.transform.parent = null;
        daball.material.color = Color.white;
        rigidball.constraints = RigidbodyConstraints.None;
        hasBall = false;
    }

    public void EndlessOn()
    {
        endlessMode = true;
    }
    public void EndlessOff()
    {
        endlessMode = false;
    }

    IEnumerator Credits()
    {

        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(credits);
    }
}
