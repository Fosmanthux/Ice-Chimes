﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public AudioSource theMusic;  // Blurred Signs
    public AudioSource theMusic2; // Burning out
    public AudioSource theMusic3;  // Mist
    public bool startPlaying;
    public bool musicStart;

    public BeatScroller2 theBS;

    public static GameManager instance;

    public GameObject ReadyToPlay;

    public int scores;
    public int noteScore;

    public int coins;
    public int coinValue;

    public static int finalScore;
    /* public int combos;
    public int comboTracker;
    public int[] comboThresholds; */

    public Text scoreText;
    public Text coinText;

    [SerializeField] Animator animator;
    public Text winScore;
    public int scene;
    public int selectedSong;
    //public Text comboText;

    void Start()
    {
        Time.timeScale = 1f;
        instance = this;
        scoreText.text = "Score [ 0 ]";
        selectedSong = theBS.getSelectedSong();
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
            }

            if (musicStart) 
            { 
                switch (selectedSong)
                {
                    case 0: theMusic.Play();
                        UnityEngine.Debug.Log(selectedSong.ToString());
                        break;
                    case 1: theMusic.Play();
                        break;
                    case 2: theMusic2.Play();
                        break;
                    case 3: theMusic3.Play();
                        break;
                    default: theMusic.Play();
                        break;
                }
            }
        }
    }

    public void LoadLevel(int levelToLoad)
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void NoteHit()
    {
        //Debug.Log("Hit");
        scores += noteScore;
        scoreText.text = "Score [ " + scores + " ]";
        if (scores >= FinishLine.instance.winCondition && !Menu.songs[scene-1])
        {
            String text = FinishLine.instance.winCondition.ToString();
            winScore.text = "Score [ " + text + " ]";
            animator.SetTrigger("complete");
            //Sound effect
        }
    }

    public void NoteMissed()
    {
        //Debug.Log("Miss");
        scores -= noteScore / 2;
        scoreText.text = "Score [ " + scores + " ]";
    }

    public void CoinGet()
    {
        //Debug.Log("Coin");
        coins += coinValue;
        coinText.text = "Crystals " + coins;
        int previousCoins = PlayerPrefs.GetInt("coins");
        previousCoins ++;
        PlayerPrefs.SetInt("coins", previousCoins);
    }
}
