using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public int scene;

    public void StartMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void nextLevel()
    {
        SceneManager.LoadScene(scene +1);
    }

    public void tryAgain(){
        SceneManager.LoadScene(scene);
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
