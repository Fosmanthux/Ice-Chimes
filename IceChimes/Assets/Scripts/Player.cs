using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Note"))
        {
            GameManager.instance.NoteHit();
        } 


        if (other.gameObject.CompareTag("Coin"))
        {
            other.gameObject.SetActive(false);
            GameManager.instance.CoinGet();
        }

        if (other.gameObject.CompareTag("Hazard"))
        {
            GameManager.instance.NoteMissed();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Note"))
        {
            GameManager.instance.NoteMissed();
        }
    }
}
