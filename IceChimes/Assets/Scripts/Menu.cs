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


    public void showCharacter(){
        shopPane.SetActive(false);
        playPane.SetActive(false);
        characterPane.SetActive(true);

    }

    public void showShop(){
        playPane.SetActive(false);
        characterPane.SetActive(false);
        shopPane.SetActive(true);
    }

    public void showPlay(){
        shopPane.SetActive(false);
        characterPane.SetActive(false);
        playPane.SetActive(true);
    }

    public void showSetting(){
      settings.SetActive(true);
    }

    public void hideSetting(){
      settings.SetActive(false);
    }

    public void showStage(){
        stageMode.SetActive(true);
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadMenu()
    {

        SceneManager.LoadScene(0);
    }
}
