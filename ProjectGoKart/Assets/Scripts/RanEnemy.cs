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
        characters[selectedCharacter].SetActive(true);

    }
}
