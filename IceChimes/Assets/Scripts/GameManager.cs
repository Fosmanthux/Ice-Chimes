using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public AudioSource theMusic;

    public bool startPlaying;

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

    //public Text comboText;

    void Start()
    {
        Time.timeScale = 1f;
        instance = this;
        scoreText.text = "Score [ 0 ]";
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
        //Debug.Log("Hit");
        scores += noteScore;
        scoreText.text = "Score [ " + scores + " ]";
        if (scores >= FinishLine.winCondition && !Menu.songs[scene-1])
        {
            String text = FinishLine.winCondition.ToString();
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
