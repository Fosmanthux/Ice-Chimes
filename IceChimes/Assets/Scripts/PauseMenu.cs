using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject pausebutton;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
                GameManager.instance.theMusic.Play();
            }
            else
            {
                Pause();
                GameManager.instance.theMusic.Pause();
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

        SceneManager.LoadScene(0);
    }

    public void LoadLevel1()
    {

        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}

/*for audio
 * if (PauseMenu.GameIsPause){
 * s.source.Play or wtv
 * } */
