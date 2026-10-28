using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour
{
    public GameObject pause, resumeButton, errorPage;
    public EventSystem eventSystem;

    // Update is called once per frame
    void Update()
    {
        
        //else
        //{
        //    //Time.deltaTime{ 0
        //    errorPage.SetActive(true);
        //} //this should bring up an error
        //if (Gamepad.current.) ;//errorPage = deactive;
    }

    public IEnumerator Pause()
    {
        pause.SetActive(true);
        Time.timeScale = 0f;
        //eventSystem.
        yield return new WaitForSeconds(0);
        //EventSystem.current.SetSelectedGameObject(;
        EventSystem.current.firstSelectedGameObject = resumeButton;
        //current.;
        //errorPage.SetActive(false);
        //EventSystem.current.m_FirstSelected.SetActive(true);
    }

    public void Resume()
    {
        pause.SetActive(false);
        Time.timeScale = 1f;
    }


    public void QuittoTitle()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
}
