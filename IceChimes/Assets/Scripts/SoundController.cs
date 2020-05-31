using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Button))]
public class SoundController : MonoBehaviour
{
    public AudioSource theSound;

    private AudioSource source { get { return GetComponent<AudioSource>(); }}
    private Button button { get { return GetComponent<Button>();}}
    // Start is called before the first frame update
    void Start()
    {
        source.playOnAwake = false;

        gameObject.AddComponent<AudioSource>();
       // source.clip = btnSound;

        button.onClick.AddListener(() => PlaySound());
    }

    void PlaySound()
    {
        if (SoundEffectsToggle.isOn == true)
        {
            theSound.pitch = Random.Range(0.5f, 1.5f);
            theSound.Play();
        }
    }
}
