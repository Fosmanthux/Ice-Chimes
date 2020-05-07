﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public AudioSource theMusic;

    public bool startPlaying;

    public BeatsScroller theBS;

    public static GameManager instance;

    public GameObject ReadyToPlay;

    public int scores;
    public int noteScore;

    public int coins;
    public int coinValue;

    public static int finalScore;
    public static int shopScore = 0;

    /* public int combos;
    public int comboTracker;
    public int[] comboThresholds; */

    public Text scoreText;
    public Text coinText;
    
    //public Text comboText;

    void Start()
    {
        instance = this;

        scoreText.text = "[ 0 ]";
    }

    // Update is called once per frame
    void Update()
    {
        if (!startPlaying)
        {
            if (Input.anyKeyDown)
            {
                ReadyToPlay.SetActive(false);
                startPlaying = true;
                theBS.hasStarted = true;

                theMusic.Play();
            }
        }
    }

    public void LoadLevel(int levelToLoad)
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void NoteHit()
    {
        Debug.Log("Hit");

        scores += noteScore;
        scoreText.text = "[ " + scores + " ]";
    }

    public void NoteMissed()
    {
        Debug.Log("Miss");

        scores -= noteScore / 2;
        scoreText.text = "[ " + scores + " ]";
    }

    public void CoinGet()
    {
        Debug.Log("Coin");

        coins += coinValue;
        coinText.text = "Coins: " + coins;
        shopScore++;
    }

}
