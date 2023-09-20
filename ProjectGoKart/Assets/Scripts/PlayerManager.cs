using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    BasicKartMove basicKartMove;

    public enum ControllerTypeConnected { Xbox, Playstation, Other }
    [HideInInspector]
    public ControllerTypeConnected controllerTypeConnected;

    public Image controllerUnpluggedImage;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (new )
    }

    private string getControllerType()
    {
        string joystickName = Input.GetJoystickNames().First();

        if (joystickName.ToLower().Contains("xbox"))
        {
            return "XBOX";
        }
        else if (joystickName.ToLower().Contains("playstation"))
        {
            return "PS";
        }
        else
        {
            return "OTHER";
        }
    }

    private void ControllerConnected(InputDevice inputDevice)
    {
        //controllerUnpluggedImage.gameObject.SetActive(false);

        if (getControllerType() == "XBOX")
        {
            controllerTypeConnected = ControllerTypeConnected.Xbox;
            UnityEngine.Debug.Log("You connected an xbox controller!");
        }
        else if (getControllerType() == "PS")
        {
            controllerTypeConnected = ControllerTypeConnected.Playstation;
            UnityEngine.Debug.Log("You connected a playstation controller!");
        }
        else
        {
            controllerTypeConnected = ControllerTypeConnected.Other;
        }
    }
}
