using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void StartMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Level1()
    {
        SceneManager.LoadScene(1);
    }

    public void Pause()
    {
        PauseMenu.GameIsPaused = true;
    }

    public void Resume()
    {
        PauseMenu.GameIsPaused = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
