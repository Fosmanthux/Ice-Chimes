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
    public int winCondition = 0;
    public int scene;
    public bool unlocked = false;
    public Text winText, loseText;

    [SerializeField] Animator animator;



    void Awake(){
        instance = this;
    }

    void Update()
    {
        if (isEnd)
        {
            //add !Menu.isInfiniteMode
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

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isEnd = true;
            // Time.timeScale = 0f;
            /*if (Menu.isInfiniteMode)
            {
                yield return new WaitForSeconds(4.0f);
            if (scene < 3)
            {
                SceneManager.LoadScene(scene + 1);
            }*/
        }
    }

    void showWin()
    {
        animator.SetBool("win", true);
        //winMenu.SetActive(true);
        winText.text = "Next level unlocked!" + '\n' + '\n' + "Score: " + GameManager.instance.scores + '\n' + "Crystals: " +
            GameManager.shopScore;
    }

    void showLose()
    {
        animator.SetBool("lose", true);
        //loseMenu.SetActive(true);
        loseText.text = "Try again to unlock next level!" + '\n' + '\n' + "Score: " + GameManager.instance.scores + '\n' + "Crystals: " +
           GameManager.shopScore;
    }
      
}