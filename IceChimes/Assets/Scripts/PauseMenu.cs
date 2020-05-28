using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] Animator animator;
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
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        GameManager.instance.theMusic.Play();
        pausebutton.SetActive(true);
        animator.SetTrigger("pauseOut");

        // pauseMenuUI.SetActive(false);
        GameIsPaused = false;
    }

    public void Pause()
    {

        GameManager.instance.theMusic.Pause();
        pausebutton.SetActive(false);
        animator.SetTrigger("pauseIn");

        //  pauseMenuUI.SetActive(true);
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

