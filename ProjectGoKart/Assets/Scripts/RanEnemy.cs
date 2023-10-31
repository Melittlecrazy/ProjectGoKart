using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RanEnemy : MonoBehaviour
{
    public GameObject[] characters;
    [SerializeField]
    int selectedCharacter;


    private void Awake()
    {
        selectedCharacter = Random.Range(0, characters.Length);
        if (selectedCharacter == 0) characters[0].SetActive(true); ;

        if (selectedCharacter == 1) characters[1].SetActive(true); ;

        if (selectedCharacter == 2) characters[2].SetActive(true); ;
    }
}
