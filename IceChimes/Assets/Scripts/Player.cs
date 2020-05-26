using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Animator animator;
    public ParticleSystem particles1, particles10;

    private IEnumerator OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Note"))
        {
            animator.SetTrigger("+10");
            GameManager.instance.NoteHit();
            yield return new WaitForSeconds(0.3f);
            particles10.Play();
        } 


        if (other.gameObject.CompareTag("Coin"))
        {
            animator.SetTrigger("+1");
            other.gameObject.SetActive(false);
            GameManager.instance.CoinGet();
            yield return new WaitForSeconds(0.7f);
           particles1.Play();
        }

        if (other.gameObject.CompareTag("Hazard"))
        {
            animator.SetTrigger("-5");
            GameManager.instance.NoteMissed();
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
