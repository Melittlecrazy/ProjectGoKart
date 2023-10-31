using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadChar : MonoBehaviour
{
    public GameObject[] charaPref;
    //public Transform spawn;


    private void Start()
    {
        int selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");
        GameObject prefab = charaPref[selectedCharacter];
        if (selectedCharacter == 0) charaPref[0].SetActive(true);
        if (selectedCharacter == 1) charaPref[1].SetActive(true);
        if (selectedCharacter == 2) charaPref[2].SetActive(true);
    }
}
