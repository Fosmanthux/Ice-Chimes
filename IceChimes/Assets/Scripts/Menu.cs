using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{


    public static Menu instance;
    public GameObject characterPane;
    public GameObject shopPane;
    public GameObject playPane;
    public GameObject settings;
    public GameObject stageMode;
    public GameObject randomMode;
    public GameObject infiniteMode;

    public Text coinText;

    public static bool isbear, isfox;

    private bool songUnlocked2 = false;
    private bool songUnlocked3 = false;

    void Start()
    {
        instance = this;

        Time.timeScale = 1f;
        if (instance == null)
        {
            instance = this;
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
        stageMode.SetActive(true);
    }

    public void showRandom()
    {
        randomMode.SetActive(true);
    }

    public void showInfinite()
    {
        infiniteMode.SetActive(true);
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void setFox(){
        isbear = false;
        isfox = true;
    }

    public void setBear()
    {
        isfox = false;
        isbear = true;
    }

    public void unlockSong(string name){
        if(name == "Song 1"){
            songUnlocked2 = true;
            Debug.Log("unlocked");
        }

        if (name == "Song 2")
        {
            songUnlocked3 = true;
        }
    }

}