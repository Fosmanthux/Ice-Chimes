﻿using System.Collections;
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
    public int winCondition;
    public int scene;
    public Text winText, loseText;

    [SerializeField] Animator animator;
    public ParticleSystem snow;

   void Awake(){
        instance = this;
    }

    void Update()
    {
        if (isEnd)
        {
            //add !Menu.isInfiniteMode
            if (GameManager.instance.scores >= winCondition || Menu.songs[scene - 1])
            {
                showWin();
                for (int i = 1; i < Menu.songsIndex; i++){
                    if (i == scene){
                        Menu.unlock(i);
                    }
                }
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
            Time.timeScale = 0f;
            snow.Play();
            isEnd = true;
            other.gameObject.SetActive(false);
            pausebutton.SetActive(false);

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
        if (Menu.songs[scene - 1])
        {
            winText.text = "Score: " + GameManager.instance.scores + '\n' + "Crystals: " +
            PlayerPrefs.GetInt("coins");
        }
        else
        {
            winText.text = "Next level unlocked!" + '\n' + '\n' + "Score: " + GameManager.instance.scores + '\n' + "Crystals: " +
            PlayerPrefs.GetInt("coins");
        }
        //sound effect
    }

    void showLose()
    {
        animator.SetBool("lose", true);
        //loseMenu.SetActive(true);

            loseText.text = "Try again to unlock next level!" + '\n' + '\n' + "Score: " + GameManager.instance.scores + '\n' + "Crystals: " +
            PlayerPrefs.GetInt("coins");
           //sound effect
    }
}