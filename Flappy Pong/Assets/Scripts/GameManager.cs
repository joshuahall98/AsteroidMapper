using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    GameObject uiManager;
    public GameObject player;
    public int ballNum = 1;

    public static bool doublePoints = false;
    public static bool ballSpeed = false;
    public static bool shrinker = false;

    public bool gameOver = false;

    public float doublePointsTimer;
    public float speedTimer;
    public float shrinkerTimer;

    private void Start()
    {
        uiManager = GameObject.Find("UI");
        player = GameObject.Find("Player");
  
    }

    private void Update()
    {
        if(gameOver == false)
        {
            if (ballNum <= 0)
            {
                gameOver = true;
                ballNum = 0;
                uiManager.GetComponent<UIManager>().GameOver();
                Time.timeScale = 0;
                FindObjectOfType<SoundManager>().Play("Lose");
            }

        }

        //timers
        doublePointsTimer -= Time.deltaTime;
        speedTimer -= Time.deltaTime;
        shrinkerTimer -= Time.deltaTime;

        //to check if double points is active
        if (doublePointsTimer <= 0)
        {
            StopDoublePoints();
            doublePoints = false;
            doublePointsTimer = 0;
        }
        else if (doublePointsTimer > 0)
        {
            doublePoints = true;
        }

        //to check is speed buff is active
        if (speedTimer <= 0)
        {
            speedTimer = 0;
            ballSpeed = false;
        }
        else if (speedTimer > 0)
        {
            ballSpeed = true;
        }

        //shrink debuff
        if (shrinkerTimer <= 0)
        {
            player.transform.localScale = new Vector3(1, 1, 1);
            shrinkerTimer = 0;
        }
        else if (shrinkerTimer > 0)
        {
            player.transform.localScale = new Vector3(0.5f, 0.5f, 1);
        }

    }

    public void Restart()
    {
        gameOver = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
        ballNum = 1;
        Debug.Log("press");
        FindObjectOfType<SoundManager>().Play("Button");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(sceneBuildIndex: 0);
        FindObjectOfType<SoundManager>().Play("Button");
        FindObjectOfType<SoundManager>().Play("MainMenu");
        FindObjectOfType<SoundManager>().Stop("GameBG");
    }

    //POWERUPS
    public void IncreaseBallCount()
    {
        ballNum = ballNum + 2;
    }

    public void DecreaseBallCount()
    {
        ballNum--;
    }

    public void StartDoublePoints()
    {
        doublePoints = true;
        doublePointsTimer = 15;
        uiManager.GetComponent<UIManager>().DoublePointsOn();
    }

    public void StopDoublePoints()
    {
        doublePoints = false;
        uiManager.GetComponent<UIManager>().DoublePointsOff();
    }

    public void IncreaseBallSpeed()
    {
        ballSpeed = true;
        speedTimer = 10;
    }

    public void DecreaseBallSpeed()
    {
        ballSpeed = false;
    }

    public void IncreasePaddleSize()
    {
        shrinker = false;
    }

    public void DecreasePaddleSize()
    {
        shrinker = true;
        shrinkerTimer = 10;
    }

}
