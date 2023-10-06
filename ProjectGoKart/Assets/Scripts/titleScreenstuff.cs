using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class titleScreenstuff : MonoBehaviour
{
    public string newGame;

    public void StartGame()
    {
        SceneManager.LoadScene(newGame);
    }

    public void QuitGame()
    {
        Application.Quit(); 
    }
}
