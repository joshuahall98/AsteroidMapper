using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Image mainMenuImg;
    public Image optionsMenuImg;
    public Image volumeImg;
    public Image musicImg;
    public Image sfxImg;

    public Button playBtn;
    public Button optionsBtn;
    public Button exitBtn;
    public Button retrunBtn;

    public Slider volumeSldr;
    public Slider musicSldr;
    public Slider sfxSldr;

    private void Start()
    {
        optionsMenuImg.gameObject.SetActive(false);
        volumeImg.gameObject.SetActive(false);
        musicImg.gameObject.SetActive(false);
        sfxImg.gameObject.SetActive(false);

        retrunBtn.gameObject.SetActive(false);

        volumeSldr.gameObject.SetActive(false);
        musicSldr.gameObject.SetActive(false);
        sfxSldr.gameObject.SetActive(false);

        if (!PlayerPrefs.HasKey("MasterVolume"))
        {
            PlayerPrefs.SetFloat("MasterVolume", 1);
            GetComponent<SoundOptions>().LoadMaster();
        }
        else
        {
            GetComponent<SoundOptions>().LoadMaster();
        }

        if (!PlayerPrefs.HasKey("MusicVolume"))
        {
            PlayerPrefs.SetFloat("MusicVolume", 1);
            GetComponent<SoundOptions>().LoadMusic();
            Debug.Log("music");
        }
        else
        {
            GetComponent<SoundOptions>().LoadMusic();
        }

        if (!PlayerPrefs.HasKey("SFXVolume"))
        {
            PlayerPrefs.SetFloat("SFXVolume", 1);
            GetComponent<SoundOptions>().LoadSFX();
            Debug.Log("sfx");
        }
        else
        {
            GetComponent<SoundOptions>().LoadSFX();
        }


    }

    public void Play()
    {
        SceneManager.LoadScene(sceneBuildIndex:1);
        FindObjectOfType<SoundManager>().Play("Button");
        FindObjectOfType<SoundManager>().Play("GameBG");
        FindObjectOfType<SoundManager>().Stop("MainMenu");

        Time.timeScale = 1;
    } 

    public void Exit()
    {
        Application.Quit();
        FindObjectOfType<SoundManager>().Play("Button");
    }

    public void Options()
    {

        mainMenuImg.gameObject.SetActive(false);
        optionsMenuImg.gameObject.SetActive(true);
        volumeImg.gameObject.SetActive(true);
        musicImg.gameObject.SetActive(true);
        sfxImg.gameObject.SetActive(true);

        playBtn.gameObject.SetActive(false);
        optionsBtn.gameObject.SetActive(false);
        exitBtn.gameObject.SetActive(false);
        retrunBtn.gameObject.SetActive(true);

        volumeSldr.gameObject.SetActive(true);
        musicSldr.gameObject.SetActive(true);
        sfxSldr.gameObject.SetActive(true);

        FindObjectOfType<SoundManager>().Play("Button");
    }

    public void Return()
    {
        mainMenuImg.gameObject.SetActive(true);
        optionsMenuImg.gameObject.SetActive(false);
        volumeImg.gameObject.SetActive(false);
        musicImg.gameObject.SetActive(false);
        sfxImg.gameObject.SetActive(false);

        playBtn.gameObject.SetActive(true);
        optionsBtn.gameObject.SetActive(true);
        exitBtn.gameObject.SetActive(true);
        retrunBtn.gameObject.SetActive(false);

        volumeSldr.gameObject.SetActive(false);
        musicSldr.gameObject.SetActive(false);
        sfxSldr.gameObject.SetActive(false);

        FindObjectOfType<SoundManager>().Play("Button");
    }
}
