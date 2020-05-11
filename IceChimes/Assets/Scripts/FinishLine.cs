using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    public static FinishLine instance { set; get; }
    public GameObject winMenu;
    public GameObject loseMenu;
    bool isEnd = false;
    public GameObject pausebutton;
    public int winCondition = 2;
    public int scene;
    public bool unlocked = false;

    void Awake(){
        instance = this;
    }

    void Update()
    {
        if (isEnd)
        {
        
            Time.timeScale = 0.5f;
            if (GameManager.instance.scores >= winCondition)
            {
                showWin();
                unlocked = true;
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
