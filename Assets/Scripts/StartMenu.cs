using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void OnStartClick()
    {
        SceneManager.LoadScene("Game");
    }

    public void OnControlClick()
    {
        SceneManager.LoadScene("Controls", LoadSceneMode.Single);
    }

    public void OnLearnClick()
    {
        SceneManager.LoadScene("HowToPlay", LoadSceneMode.Single);
    }
    
    public void OnExitClick()
    {
        SceneManager.LoadScene("StartMenu", LoadSceneMode.Single);
    }
        
}
