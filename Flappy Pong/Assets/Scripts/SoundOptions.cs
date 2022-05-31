using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundOptions : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider sfxSlider;

    public AudioMixer mixer;

    public void SetMasterLvl(float masterLvl)
    {
        mixer.SetFloat("masterVol", Mathf.Log10(volumeSlider.value <= 0 ? 0.001f : volumeSlider.value) * 40f);
        SaveMaster();
    }

    public void SetMusicLvl(float musicLvl)
    {
        mixer.SetFloat("musicVol", Mathf.Log10(musicSlider.value <= 0 ? 0.001f : musicSlider.value) * 40f);
        SaveMusic();
    }

    public void SetSFXLvl(float sfxLvl)
    {
        mixer.SetFloat("sfxVol", Mathf.Log10(sfxSlider.value <= 0 ? 0.001f : sfxSlider.value) * 40f);
        SaveSFX();
    }

    public void LoadMaster()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("MasterVolume");
    }

    public void LoadMusic()
    {
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
    }

    public void LoadSFX()
    {
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume");
    }

    public void SaveMaster()
    {
        PlayerPrefs.SetFloat("MasterVolume", volumeSlider.value);
    }

    public void SaveMusic()
    {
        PlayerPrefs.SetFloat("MusicVolume", musicSlider.value);
    }

    public void SaveSFX()
    {
        PlayerPrefs.SetFloat("SFXVolume", sfxSlider.value);
    }
}

