using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HasBall : MonoBehaviour
{
    public GameObject ball;
    public GameObject trail;
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
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score: " + point;
       if (point == 4) score.text = "WINNER";
    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ball")
        {
            trail.SetActive(true);
            hasBall = true; 
        }

        
        //quadTwo.SetColor()
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Finish" && hasBall == true)
        {
            quadOne.SetColor("_Color", Color.red);
            point = point + 1;

            quadTwo.SetColor("_Color", Color.red);
            //point = point + 1;
            quadThree.SetColor("_Color", Color.red);
            //point = point + 1;
            quadFour.SetColor("_Color", Color.red);
            //point = point + 1;
        }
    }
    
}
