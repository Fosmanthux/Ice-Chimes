﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundEffectsToggle : MonoBehaviour
{
    public static SoundEffectsToggle instance;
    public Toggle soundEffects;
    public static bool isOn = true;

    void Awake(){
        instance = this;
    }

    void Start()
    {
        soundEffects = GetComponent<Toggle>();
        soundEffects.onValueChanged.AddListener(delegate
        {
            ToggleValueChanged(soundEffects);
        });

        if (isOn)
        {
            soundEffects.isOn = true;
        }
        else soundEffects.isOn = false;
    }

    void ToggleValueChanged(Toggle change)
    {
        if (soundEffects.isOn)
        {
            isOn = true;
            Debug.Log("o");
        }
        else isOn = false; Debug.Log("off");
    }
}
