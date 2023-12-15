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

    // Update is called once per frame
    void Update()
    {
        if (Gamepad.current.startButton.isPressed)
        {
            pause.SetActive(true);
            EventSystem.current.SetSelectedGameObject(resumeButton);
        }
    }

    public void Resume()
    {
        pause.SetActive(false);
    }


    public void QuittoTitle()
    {
        SceneManager.LoadScene(0);
    }
}
