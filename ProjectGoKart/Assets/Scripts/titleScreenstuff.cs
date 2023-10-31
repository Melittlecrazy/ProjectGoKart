using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class titleScreenstuff : MonoBehaviour
{
    public string single,multi;
    public GameObject button, p1,p2,play,play2;

    public GameObject title,singleP,multiP;
    public bool sin,mul;

    void Start()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(button);
    }
    public void StartGame() 
    {
        EventSystem.current.SetSelectedGameObject(p1);
        p1.SetActive(true);
        p2.SetActive(true);
        if (sin == true) 
        if (mul == true) SceneManager.LoadScene(multi);

    }

    public void Single()
    {
        EventSystem.current.SetSelectedGameObject(play);
        title.SetActive(false);
        singleP.SetActive(true);

        sin = true;
    }

    public void Multi()
    {
        EventSystem.current.SetSelectedGameObject(play2);
        title.SetActive(false);
        multiP.SetActive(true);

        mul = true;
    }

    public void Credits()
    {

    }


    public void QuitGame()
    {
        Application.Quit(); 
    }
}
