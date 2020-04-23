using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Note : MonoBehaviour
{
    public int score = 10;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().finalScore += score;
            Debug.Log(other.GetComponent<Player>().finalScore);
        }
    }

}
