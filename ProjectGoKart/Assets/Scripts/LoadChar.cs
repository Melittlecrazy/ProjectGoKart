using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadChar : MonoBehaviour
{
    public GameObject[] charaPref,player2;
    //public Transform spawn;


    private void Start()
    {
        int selectedCharacter = PlayerPrefs.GetInt("selectedCharacter1");
        //GameObject prefab = charaPref[selectedCharacter];
        if (selectedCharacter == 0) charaPref[0].SetActive(true);
        if (selectedCharacter == 1) charaPref[1].SetActive(true);
        if (selectedCharacter == 2) charaPref[2].SetActive(true);

        int selectedCharacter2 = PlayerPrefs.GetInt("selectedCharacter2");
        //GameObject prefab2 = player2[selectedCharacter2];
        if (selectedCharacter2 == 0) player2[0].SetActive(true);
        if (selectedCharacter2 == 1) player2[1].SetActive(true);
        if (selectedCharacter2 == 2) player2[2].SetActive(true);
    }
}
