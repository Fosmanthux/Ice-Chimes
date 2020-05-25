using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Animator animator;
    public ParticleSystem particles;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Note"))
        {
            animator.SetTrigger("+10");
            GameManager.instance.NoteHit();
            particles.Play();
        } 


        if (other.gameObject.CompareTag("Coin"))
        {
            animator.SetTrigger("+1");
            other.gameObject.SetActive(false);
            GameManager.instance.CoinGet();
            particles.Play();
        }

        if (other.gameObject.CompareTag("Hazard"))
        {
            animator.SetTrigger("-5");
            GameManager.instance.NoteMissed();
            particles.Play();
        }
    }

    /*    private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Note"))
            {
                GameManager.instance.NoteMissed();
            }
        }  */
}
