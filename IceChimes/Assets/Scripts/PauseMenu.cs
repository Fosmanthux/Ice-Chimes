using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject winMenu;
    public GameObject loseMenu;
    public GameObject pauseMenuUI;
    public GameObject pausebutton;
    bool endGame, win, lose;



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

        if (endGame)
        {
            if (win)
            {
                showWin();
            }

            else if (lose)
            {
                showLose();
            }

        }
    }

    public void Resume()
    {
        pausebutton.SetActive(true);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;

    }

    public void Pause()
    {
        pausebutton.SetActive(false);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {

        //SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void showWin()
    {
        winMenu.SetActive(true);
    }

    void showLose()
    {
        loseMenu.SetActive(true);
    }

}

/*for audio
 * if (PauseMenu.GameIsPause){
 * s.source.Play or wtv
 * } */
