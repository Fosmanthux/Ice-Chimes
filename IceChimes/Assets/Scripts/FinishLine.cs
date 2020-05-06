using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public GameObject winMenu;
    public GameObject loseMenu;
    bool isEnd = false;
    public GameObject pausebutton;
    public int winCondition = 100;

    void Update()
    {
        if (isEnd)
        {
            Time.timeScale = 0.5f;
            if (GameManager.instance.scores >= winCondition)
            {
                showWin();
            }

            else if (GameManager.instance.scores < winCondition)
            {
                showLose();
            }

        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isEnd = true;
        }
    }

    void showWin()
    {
        winMenu.SetActive(true);
        pausebutton.SetActive(false);
    }

    void showLose()
    {
        loseMenu.SetActive(true);
        pausebutton.SetActive(false);
    }
}
