using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController gameControllerInstance;
    public Text coinText;
    public Text scoreText;

    [HideInInspector]
    public int coins;
    [HideInInspector]
    public int scores;

    // Start is called before the first frame update
    void Start()
    {
        gameControllerInstance = this;
        coins = 0;
        scores = 0;
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = "Coins: " + coins;
        scoreText.text = "Scores: " + scores;
    }
}
