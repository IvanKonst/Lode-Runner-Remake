using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void onStartClick()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void onInstructionsClick()
    {
        SceneManager.LoadScene("Instructions");
    }
    public void onQuitClick()
    {
        Application.Quit();
    }
    public void onMainMenuClick()
    {
        SceneManager.LoadScene("Menu");
    }
    public void onRetryClick()
    {
        SceneManager.LoadScene("MainScene");
    }
}
