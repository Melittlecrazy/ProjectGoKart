using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
//using System;
using UnityEngine.TextCore.Text;

public class HasBall : MonoBehaviour
{
    public GameObject ball; 
    public Rigidbody rigidball;

    public GameObject trail, quadMan;
    //public MeshRenderer quad1,quad2,quad3,quad4;
    public Renderer daball;

    private teamcolor color;

    public GameObject points,checkpoints,checkpoints2,checkpoints3;
    public GameObject[] spawns;
    public GameObject ring1, ring2, ring3;

    int selectedCharacter;
    public int point1=1,point2=1;
    public TextMeshProUGUI score1, score2;

    bool particle = false;
    public bool hasBall = false,resetted = false, stayed=false;
    public bool isPlayer1, isPlayer2,endlessMode=true, first,bob;

    string credits = "Credits";

    Vector3 scaleChange;

    void Start()
    {
        points.GetComponent<Scoring>();
        Respawn();
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
            if (points.GetComponent<Scoring>().player1score == 17)
            {
                score1.text = "Score: " + point1;
                point1 = point1 + 1;
                Reset(); 

            }

            if (endlessMode == false)
            {
                if (point1 == 4)
                {
                    score1.text = "WIN";
                    ring3.GetComponent<Renderer>().material.color = Color.red;
                    score2.text = "LOSE";

                    StartCoroutine(Credits());
                }
            }


            //if (checkpoints.GetComponent<Scoring>().player1score == 9) { score1.text = "Score: 2"; Reset(); point1 = point1 + 1; }
            //if (checkpoints.GetComponent<Scoring>().player1score == 14) { score1.text = "Winner"; score2.text = "Lose"; trail.SetActive(true); }
        }
        if (isPlayer2 == true)
        {
            //score2.text = "Score: " + point2;
            if (points.GetComponent<Scoring>().player2score == 17)
            {
                score2.text = "Score: " + point2;

                //    score2.text = "WIN";
                //    quadMan.SetActive(false);
                //    score1.text = "LOSE";
                point2 = point2 + 1;
                Reset();
            }
            if (endlessMode == false)
            {
                if (point2 == 4)
                {
                    score2.text = "WIN";
                    ring3.GetComponent<Renderer>().material.color = Color.blue;
                    score1.text = "LOSE";
                    StartCoroutine(Credits());
                }
            }
            //if (point2 == 9) { score2.text = "Score: 2"; Reset(); point2 = point2 + 1; }
            //if (point2 == 14) { score2.text = "Winner"; score1.text = "Lose"; trail.SetActive(true); }
        }

        if (isPlayer1 = true && points.GetComponent<Scoring>().player1score == 17  && bob == false)
        {
            checkpoints2.SetActive(true);
            first = false;
            bob = true;
            point1 = point1 + 1;
        }
        if (isPlayer2 = true && points.GetComponent<Scoring>().player2score == 17 && bob == false)
        {
            checkpoints3.SetActive(true);
            first = true;
            bob = true;
            point2 = point2 + 1;
        }

        if (!first) // for if player 1 is winning
        {
            if (point1 == 2)
            { //FFF308 original yellow of rings
                scaleChange = new Vector3(1.4f, 1, 1.4f);
                checkpoints2.transform.localScale = scaleChange;
                ring1.GetComponent<Renderer>().material.color = Color.red;
                ring2.SetActive(true);
            }
            if (point1 == 3)
            {
                scaleChange = new Vector3(2f, 1, 2f);
                checkpoints2.transform.localScale = scaleChange;
                ring2.GetComponent<Renderer>().material.color = Color.red;
                ring3.SetActive(true);
            }
            if (point2 == 2)
            { //FFF308 original yellow of rings
                scaleChange = new Vector3(1.4f, 1, 1.4f);
                checkpoints.transform.localScale = scaleChange;
                ring1.GetComponent<Renderer>().material.color = Color.blue;
                ring2.SetActive(true);
            }
            if (point2 == 3)
            {
                scaleChange = new Vector3(2f, 1, 2f);
                checkpoints.transform.localScale = scaleChange;
                ring2.GetComponent<Renderer>().material.color = Color.blue;
                ring3.SetActive(true);
            }

            if (point1 == 2 && point2 == 2)
            {
                checkpoints2.SetActive(false);
                bob = false;
            }
            if (point1 == 3 && point2 == 3)
            {
                checkpoints2.SetActive(false);
                bob = false;
            }
        }
        if (first) //for if player 2 is winning
        {
            if (point1 == 2)
            { //FFF308 original yellow of rings
                scaleChange = new Vector3(1.4f, 1, 1.4f);
                checkpoints.transform.localScale = scaleChange;
                ring1.GetComponent<Renderer>().material.color = Color.red;
                ring2.SetActive(true);
            }
            if (point1 == 3)
            {
                scaleChange = new Vector3(2f, 1, 2f);
                checkpoints.transform.localScale = scaleChange;
                ring2.GetComponent<Renderer>().material.color = Color.red;
                ring3.SetActive(true);
            }
            if (point2 == 2)
            { //FFF308 original yellow of rings
                scaleChange = new Vector3(1.4f, 1, 1.4f);
                checkpoints3.transform.localScale = scaleChange;
                ring1.GetComponent<Renderer>().material.color = Color.blue;
                ring2.SetActive(true);
            }
            if (point2 == 3)
            {
                scaleChange = new Vector3(2f, 1, 2f);
                checkpoints3.transform.localScale = scaleChange;
                ring2.GetComponent<Renderer>().material.color = Color.blue;
                ring3.SetActive(true);
            }
            if (point1 == 2 && point2 == 2)
            {
                checkpoints3.SetActive(false);
                bob = false;
            }
            if (point1 == 3 && point2 == 3)
            {
                checkpoints3.SetActive(false);
                bob = false;
            }
        }
    }
        private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ball")
        {
            //trail.SetActive(true);
            hasBall = true;
            points.SetActive(true);
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
        //ball.transform.position = spawn.transform.position;
        Respawn();
        points.GetComponent<Scoring>().player1score = 0;
        points.GetComponent<Scoring>().player2score = 0;
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
    public void Respawn()
    {
            selectedCharacter = Random.Range(0, spawns.Length);
            ball.transform.position = spawns[selectedCharacter].transform.position;
    }
}
