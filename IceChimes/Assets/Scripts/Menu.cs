using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    System.Random rnd;
    public static Menu instance { set; get; }

    /*public GameObject characterPane;
    public GameObject shopPane;
    public GameObject playPane;
    public GameObject settings;
    public GameObject stageMode;
    public GameObject randomMode;
    public GameObject infiniteMode;*/

    public Button play;
    public Button song2, song3;

    private int levelToLoad;
    public static int songsIndex = 3;

    public Text coinText;

    public static bool isbear, isfox;

    public GameObject particles;
    private Vector2 touch;
    public static bool song2Unlock, song3Unlock;
    public static bool[] songs = {song2Unlock, song3Unlock}; 
    //public static bool isInfiniteMode = false;

    void Start()
    {
        instance = this;
        rnd = new System.Random();
        Time.timeScale = 1f;
        isbear = (PlayerPrefs.GetInt("isbear") != 0);
        isfox = (PlayerPrefs.GetInt("isfox") != 0);
        songs[0] = (PlayerPrefs.GetInt("song2") != 0);
        songs[1] = (PlayerPrefs.GetInt("song3") != 0);
    }


    void Update()
    {
        if (songs[0]){
            song2.interactable = true;
        }

        if (songs[1]){
            song3.interactable = true;
        }
    }

    public static void unlock(int scene){
        songs[scene - 1] = true;
        PlayerPrefs.SetInt("song"+ (scene+1), songs[scene-1] ? 1 : 0);
    }

    public void showShop()
    {    
        coinText.text = "Crystals: " + PlayerPrefs.GetInt("coins");
    }


    public void showStage()
    {
        levelToLoad = 0;
        if (levelToLoad == 0){
            play.interactable = false;
        }
    }

    public void setLevel(int level){
        levelToLoad = level;
        play.interactable = true;
    }

    public void showRandom()
   {
       levelToLoad = rnd.Next(1, 3);
   }

    public void LoadLevel()
    {
       if (levelToLoad > 0 && levelToLoad <= songsIndex)
       {
            SceneManager.LoadScene(levelToLoad);
        }
    }

    public void setFox()
    {
        isbear = false;
        PlayerPrefs.SetInt("isbear", isbear ? 1 : 0);
        isfox = true;
        PlayerPrefs.SetInt("isfox", isfox ? 1 : 0);
    }

        public void setBear()
    {
        isfox = false;
        PlayerPrefs.SetInt("isfox", isfox ? 1 : 0);
        isbear = true;
        PlayerPrefs.SetInt("isbear", isbear ? 1 : 0);

    }

    public void QuitGame()
    {
        Application.Quit();
    }



    /*
     public void LoadMenu()
     {
         SceneManager.LoadScene(0);
     }

     public void showPlay()
     {
         shopPane.SetActive(false);
         characterPane.SetActive(false);
         playPane.SetActive(true);
     }

     public void showInfinite()
     {
         infiniteMode.SetActive(true);
     }

     public void showSetting()
     {
         settings.SetActive(true);
     }

     public void hideSetting()
     {
         settings.SetActive(false);
     }

     public void goBack()
     {
         infiniteMode.SetActive(false);
         stageMode.SetActive(false);
         / randomMode.SetActive(false);
         playPane.SetActive(true);
     }

     //public void playInfinite(){
     //  isInfiniteMode = true;
     //    SceneManager.LoadScene(1);}
     */

}