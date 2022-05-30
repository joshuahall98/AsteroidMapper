using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundOptions : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;

    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        Save();

    }

    public void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("MusicVolume");
    }

    public void Save()
    {
        PlayerPrefs.SetFloat("MusicVolume", volumeSlider.value);
    }
}

