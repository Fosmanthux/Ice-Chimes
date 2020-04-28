using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int coinValue = 1;
    public int noteScore = 10;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Note"))
        {
            GameController.gameControllerInstance.scores += noteScore;
        }


        if (other.gameObject.CompareTag("Coin"))
        {
            other.gameObject.SetActive(false);
            GameController.gameControllerInstance.coins++;
        }
    }
}
