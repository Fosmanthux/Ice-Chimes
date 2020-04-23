using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public static int finalScore;
    public Text text;
    int score;
    bool endGame = false;

    public bool getScore()
    {
        return endGame;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    public void ChangeScore(int coinValue)
    {
        score += coinValue;
        text.text = " " + score.ToString();
        finalScore = score;
    }

}

