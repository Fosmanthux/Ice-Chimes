using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject characterPane;
    public GameObject shopPane;
    public GameObject playPane;
    public GameObject settings;
    public GameObject stageMode;
    public GameObject randomMode;
    public GameObject infiniteMode;
    public Button song2, song3;
    private int levelToLoad;
    System.Random rnd;

    public Text coinText;

    public static bool isbear, isfox;

    void Start()
    {
        rnd = new System.Random();
        Time.timeScale = 1f;
    }

    void Update()
    {
        if (FinishLine.instance != null && FinishLine.instance.scene == 1 && FinishLine.instance.unlocked)
        {
            song2.interactable = true;
        }
        else if (FinishLine.instance != null && FinishLine.instance.scene == 2 && FinishLine.instance.unlocked)
        {
            song3.interactable = true;
        }
    }


    public void showCharacter()
    {
        shopPane.SetActive(false);
        playPane.SetActive(false);
        characterPane.SetActive(true);

    }

    public void showShop()
    {
        coinText.text = "Coins: " + GameManager.shopScore.ToString();
        playPane.SetActive(false);
        characterPane.SetActive(false);
        shopPane.SetActive(true);
    }

    public void showPlay()
    {
        shopPane.SetActive(false);
        characterPane.SetActive(false);
        playPane.SetActive(true);
    }

    public void showSetting()
    {
        settings.SetActive(true);
    }

    public void hideSetting()
    {
        settings.SetActive(false);
    }

    public void showStage()
    {
        levelToLoad = 0;
        stageMode.SetActive(true);
    }

    public void showRandom()
    {
        levelToLoad = rnd.Next(1, 4);
        Debug.Log(levelToLoad);
        randomMode.SetActive(true);
    }

    public void showInfinite()
    {
        infiniteMode.SetActive(true);
    }

    public void setLevel1(){
        levelToLoad = 1;
    }

    public void setLevel2()
    {
        levelToLoad = 2;
    }

    public void LoadLevel()
    {
        if (levelToLoad != 0)
        {
            SceneManager.LoadScene(levelToLoad);
        }


    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void setFox()
    {
        isbear = false;
        isfox = true;
    }

    public void setBear()
    {
        isfox = false;
        isbear = true;
    }

}