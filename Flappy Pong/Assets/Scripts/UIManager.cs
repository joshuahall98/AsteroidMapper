using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public enum MenuState { GAMEOVER, PAUSED, PLAY}

public class UIManager : MonoBehaviour
{
    public MenuState state;

    //UI
    public Text scoreTxt;

    public Button againBtn;
    public Button optionsBtn;
    public Button mainMenuBtn;
    public Button playBtn;
    public Button pauseBtn;
    public Button returnBtn;

    public Image backgroundImg;
    public Image pauseImg;
    public Image gameOverImg;
    public Image volumeImg;
    public Image optionsImg;

    public Slider volumeSldr;

    public GameObject gameManager;

    int score = 0;
    public bool doublePoints = false;

    private void Start()
    {
        state = MenuState.PLAY;

        gameManager = GameObject.Find("GameManager");

        gameOverImg.gameObject.SetActive(false);
        pauseImg.gameObject.SetActive(false);
        volumeImg.gameObject.SetActive(false);
        volumeSldr.gameObject.SetActive(false);
        optionsImg.gameObject.SetActive(false);

        againBtn.gameObject.SetActive(false);
        optionsBtn.gameObject.SetActive(false);
        mainMenuBtn.gameObject.SetActive(false);
        playBtn.gameObject.SetActive(false);
        returnBtn.gameObject.SetActive(false);

        backgroundImg.enabled = false;

        /*if (!PlayerPrefs.HasKey("MusicVolume"))
        {
            PlayerPrefs.SetFloat("MusicVolume", 1);
            volumeSldr.GetComponent<SoundOptions>().Load();
        }
        else
        {
            volumeSldr.GetComponent<SoundOptions>().Load();
        }*/

    }

    private void Update()
    {
        doublePoints = GameManager.doublePoints;
    }

    public void GameOver()
    {
        state = MenuState.GAMEOVER;

        gameOverImg.gameObject.SetActive(true);

        againBtn.gameObject.SetActive(true);
        mainMenuBtn.gameObject.SetActive(true);
        optionsBtn.gameObject.SetActive(true);
        pauseBtn.gameObject.SetActive(false);
        backgroundImg.enabled = true;

    }

    public void Score()
    {
        if (doublePoints == true)
        {
            score = score + 2; 
        }
        else
        {
            score++;
        }
        scoreTxt.text = "" + score;

    }

    public void DoublePointsOn()
    {
        scoreTxt.color = Color.magenta;
    }

    public void DoublePointsOff()
    {
        scoreTxt.color = Color.white;
    }

    public void PauseButton()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            state = MenuState.PAUSED;
            Pause();
        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            state = MenuState.PLAY;
            UnPause();
        }
        FindObjectOfType<SoundManager>().Play("Button");
    }

    public void Pause()
    {
        pauseImg.gameObject.SetActive(true);

        backgroundImg.enabled = true;

        optionsBtn.gameObject.SetActive(true);
        mainMenuBtn.gameObject.SetActive(true);
        playBtn.gameObject.SetActive(true);
        pauseBtn.gameObject.SetActive(false);
    }

    public void UnPause()
    {
        pauseImg.gameObject.SetActive(false);

        backgroundImg.enabled = false;

        optionsBtn.gameObject.SetActive(false);
        mainMenuBtn.gameObject.SetActive(false);
        playBtn.gameObject.SetActive(false);
        pauseBtn.gameObject.SetActive(true);
    }

    public void Options()
    {
        volumeImg.gameObject.SetActive(true);
        volumeSldr.gameObject.SetActive(true);
        pauseImg.gameObject.SetActive(false);
        gameOverImg.gameObject.SetActive(false);

        optionsImg.gameObject.SetActive(true);

        returnBtn.gameObject.SetActive(true);
        optionsBtn.gameObject.SetActive(false);
        mainMenuBtn.gameObject.SetActive(false);
        playBtn.gameObject.SetActive(false);
        againBtn.gameObject.SetActive(false);

        FindObjectOfType<SoundManager>().Play("Button");
    }

    public void Return()
    {
        volumeImg.gameObject.SetActive(false);
        volumeSldr.gameObject.SetActive(false);
        
        if(state == MenuState.PAUSED)
        {
            pauseImg.gameObject.SetActive(true);
            playBtn.gameObject.SetActive(true);
        }
        else if(state == MenuState.GAMEOVER)
        {
            gameOverImg.gameObject.SetActive(true);
            againBtn.gameObject.SetActive(true);
        }

        optionsImg.gameObject.SetActive(false);

        returnBtn.gameObject.SetActive(false);
        optionsBtn.gameObject.SetActive(true);
        mainMenuBtn.gameObject.SetActive(true);


        FindObjectOfType<SoundManager>().Play("Button");
    }
   
}
