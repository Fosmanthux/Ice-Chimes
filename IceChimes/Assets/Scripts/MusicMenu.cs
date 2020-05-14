using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class MusicMenu : MonoBehaviour
{

    public AudioSource theMusic;
    public Toggle music;



    // Start is called before the first frame update
    void Start()
    {
        music = GetComponent<Toggle>();
        music.onValueChanged.AddListener(delegate {
            ToggleValueChanged(music);
        });

        if (music.isOn)
        {
            theMusic.Play();
        }
    }

    void ToggleValueChanged(Toggle change)
    {
        if (!music.isOn)
        {
            theMusic.Stop();
        }
        else theMusic.Play();
    }

}
