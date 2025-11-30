using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour
{
    public GameObject pause;
    public GameObject resumeButton;
    public GameObject errorPage;

    // Update is called once per frame
    void Update()
    {
        if (Gamepad.current.startButton.isPressed)
        {
            pause.SetActive(true);
            Time.timeScale = 0f;
            EventSystem.current.SetSelectedGameObject(resumeButton);
            //errorPage.SetActive(false);
        }
        //else
        //{
        //    //Time.deltaTime{ 0
        //    errorPage.SetActive(true);
        //} //this should bring up an error
        //if (Gamepad.current.) ;//errorPage = deactive;
    }

    public void Resume()
    {
        pause.SetActive(false);
        Time.timeScale = 1f;
    }


    public void QuittoTitle()
    {
        SceneManager.LoadScene(0);
    }
}
