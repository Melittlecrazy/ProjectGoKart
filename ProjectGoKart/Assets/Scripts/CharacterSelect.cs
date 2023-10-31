using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour
{
    public GameObject[] characters; 
    public int selectedCharacter = 0;
    string single = "TitleScreen",p1 = "SinglePlayer",p2 = "Track1";

    public void NextCharacter()
    {
        characters[selectedCharacter].SetActive(false);
        selectedCharacter = (selectedCharacter + 1) % characters.Length ;
        characters[selectedCharacter].SetActive(true);
    }

    public void PreviousChar()
    {
        characters[selectedCharacter].SetActive(false) ;
        selectedCharacter--;
        if (selectedCharacter < 0)
        selectedCharacter = (selectedCharacter - 1) % characters.Length ;
        characters[selectedCharacter].SetActive(true);
    }

    public void OnStart()
    {
        PlayerPrefs.SetInt("selectedCharacter", selectedCharacter);
        SceneManager.LoadScene(p1);
    }

    public void OnMult()
    {
        PlayerPrefs.SetInt("selectedCharacter", selectedCharacter);
        SceneManager.LoadScene(p2);
    }
    public void Back()
    {
        SceneManager.LoadScene(single);
    }
}
