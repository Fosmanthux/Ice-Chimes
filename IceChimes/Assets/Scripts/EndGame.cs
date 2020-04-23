using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public GameObject winMenu;
    public GameObject loseMenu;
    bool isEnd = false;
    private int winCondition = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isEnd)
        {
            Time.timeScale = 0.5f;
            if (ScoreManager.finalScore >= winCondition)
            {
                showWin();
            }

            else if (ScoreManager.finalScore < winCondition)
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

    public void showWin()
    {
        winMenu.SetActive(true);
    }

    void showLose()
    {
        loseMenu.SetActive(true);
    }

}
