using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour
{
    public GameObject[] characters1, characters2; 
    public int selectedCharacter1 = 0, selectedCharacter2 = 0;
    string single = "TitleScreen",p1 = "SinglePlayer",p2 = "Track1";

    public void NextCharacter()
    {
        characters1[selectedCharacter1].SetActive(false);
        selectedCharacter1 = (selectedCharacter1 + 1) % characters1.Length ;
        characters1[selectedCharacter1].SetActive(true);
    }

    public void PreviousChar()
    {
        characters1[selectedCharacter1].SetActive(false) ;
        selectedCharacter1--;
        if (selectedCharacter1 < 0)
        selectedCharacter1 = (selectedCharacter1 - 1) % characters1.Length ;
        characters1[selectedCharacter1].SetActive(true);
    }

    public void NextChar()
    {
        characters2[selectedCharacter2].SetActive(false);
        selectedCharacter2 = (selectedCharacter2 + 1) % characters2.Length;
        characters2[selectedCharacter2].SetActive(true);
    }

    public void PrevChar()
    {
        characters2[selectedCharacter2].SetActive(false);
        selectedCharacter2--;
        if (selectedCharacter2 < 0)
            selectedCharacter2 = (selectedCharacter2 - 1) % characters2.Length;
        characters2[selectedCharacter2].SetActive(true);
    }
    public void OnStart()
    {
        PlayerPrefs.SetInt("selectedCharacter", selectedCharacter1);
        SceneManager.LoadScene(p1);
    }

    public void OnMult()
    {
        PlayerPrefs.SetInt("selectedCharacter1", selectedCharacter1);
        PlayerPrefs.SetInt("selectedCharacter2", selectedCharacter2);
        SceneManager.LoadScene(p2);
    }
    public void Back()
    {
        SceneManager.LoadScene(single);
    }
}
