using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class titleScreenstuff : MonoBehaviour
{
    public string newGame;
    public GameObject button;

    void Start()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(button);
    }
    public void StartGame()
    {
        SceneManager.LoadScene(newGame);
    }

    public void QuitGame()
    {
        Application.Quit(); 
    }
}
