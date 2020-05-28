using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class MusicMenu : MonoBehaviour
{

    public AudioSource theMusic;
    public Toggle music;
    public static bool isMusic = true;

    void Awake(){
        isMusic = (PlayerPrefs.GetInt("isMusic") != 0);
    }


    // Start is called before the first frame update
    void Start()
    {
        music = GetComponent<Toggle>();
        music.onValueChanged.AddListener(delegate {
            ToggleValueChanged(music);
        });

        if (isMusic)
        {
            theMusic.Play();
            music.isOn = true;
        }

        else music.isOn = false;
    }

    void ToggleValueChanged(Toggle change)
    {
        if (!music.isOn)
        {
            isMusic = false;
            theMusic.Stop();
        }
        else {
            theMusic.Play();
            isMusic = true; }
        PlayerPrefs.SetInt("isMusic", isMusic ? 1 : 0);
    }
}
