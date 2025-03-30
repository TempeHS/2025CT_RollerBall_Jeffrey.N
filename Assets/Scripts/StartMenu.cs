using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class StartMenu : MonoBehaviour
{
    public GameObject howtoplayOpenButton, startgameOpenButton, controlsOpenButton, closeButton;

    public void Start()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(startgameOpenButton);
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1) && startgameOpenButton)
        {
            OnStartClick();
        }

        if (Input.GetKeyDown(KeyCode.Keypad2) && howtoplayOpenButton)
        {
            OnLearnClick();
        }

        if (Input.GetKeyDown(KeyCode.Keypad3) && controlsOpenButton)
        {
            OnControlClick();
        }

        if (Input.GetKeyDown(KeyCode.Space) && closeButton)
        {
            OnExitClick();
        }
    }

    public void OnStartClick()
    {
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }

    public void OnControlClick()
    {
        SceneManager.LoadScene("Controls", LoadSceneMode.Single);
        EventSystem.current.SetSelectedGameObject(closeButton);
    }

    public void OnLearnClick()
    {
        SceneManager.LoadScene("HowToPlay", LoadSceneMode.Single);
        EventSystem.current.SetSelectedGameObject(closeButton);
    }
    
    public void OnExitClick()
    {
        SceneManager.LoadScene("StartMenu", LoadSceneMode.Single);
        EventSystem.current.SetSelectedGameObject(startgameOpenButton);
    }
        
}
