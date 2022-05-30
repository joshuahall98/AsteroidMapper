using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ball : MonoBehaviour
{
    Rigidbody2D rb;
    public int speed = 7;
    public int speedBoost = 9;
    Vector2 ballPos;

    //public float timer1 = 3;
    public float timer2 = 3;
    

    bool isColliding = false;
    bool speedPU = false;
    bool shrinkerPU = false;


    public GameObject uiManager;
    public GameObject gameManager;
    public GameObject newBall;


    public bool ballSpeed;
    public bool doublePoints;

    // Start is called before the first frame update
    void Start()
    {
        uiManager = GameObject.Find("UI");
        gameManager = GameObject.Find("GameManager");

        gameObject.GetComponent<Renderer>().material.color = Color.yellow;

        rb = GetComponent<Rigidbody2D>();
        Movement();
    }

    // Update is called once per frame
    void Update()
    {
        ballSpeed = GameManager.ballSpeed;
        doublePoints = GameManager.doublePoints;

        //ball position
        ballPos = gameObject.transform.position;

        //to stop ball getting stcuk at top or bottom
        /*if (ballPos.y > 3.7)
        {
            timer1 -= Time.deltaTime;
        }*/
        if (ballPos.y < -3.7)
        {
            timer2 -= Time.deltaTime;
        }
        /*if(ballPos.y < 3.7)
        {
            timer1 = 2;
        }*/
        if (ballPos.y > -3.7)
        {
            timer2 = 2;
        }
        /*if (timer1 <= 0)
        {
            float x = Random.Range(0, 2) == 0 ? -1 : 1;
            rb.velocity = new Vector2(speed * x, speed * -1);
        }*/
        if(timer2 <= 0)
        {
            float x = Random.Range(0, 2) == 0 ? -1 : 1;
            rb.velocity = new Vector2(speed * x, speed * 1);
        }

        //double point colours
        if(doublePoints == true)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.magenta;
        }
        else if(doublePoints == false)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.yellow;
        }



        //to check is speed buff is active
        if (ballSpeed == true)
        {
            rb.velocity = speedBoost * (rb.velocity.normalized);
        }
        else if (ballSpeed == false)
        {
            rb.velocity = speed * (rb.velocity.normalized);
            
        }

    }

    private void Movement()
    {
        /*float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;
        rb.velocity = new Vector2(speed * x, speed * y);*/
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        rb.velocity = new Vector2(speed * x, speed * 1);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag != "GameOver")
        {
            FindObjectOfType<SoundManager>().Play("Bounce");
        }

        if (collision.gameObject.tag == "GameOver")
        {
            if (isColliding == false)
            {
                isColliding = true;
                gameManager.GetComponent<GameManager>().DecreaseBallCount();
            }

            Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag == "Obstacle")
        {
            uiManager.GetComponent<UIManager>().Score();

        }
        else if (collision.gameObject.tag == "DoubleBall")
        {
            Instantiate(newBall, ballPos, Quaternion.identity);
            Instantiate(newBall, ballPos, Quaternion.identity);
            gameManager.GetComponent<GameManager>().IncreaseBallCount();
            Destroy(collision.gameObject);
            FindObjectOfType<SoundManager>().Play("PowerUp");
        }
        else if (collision.gameObject.tag == "DoublePoints")
        {
            gameManager.GetComponent<GameManager>().StartDoublePoints();
            Destroy(collision.gameObject);
            FindObjectOfType<SoundManager>().Play("PowerUp");
        }
        else if (collision.gameObject.tag == "SpeedBall")
        {
            gameManager.GetComponent<GameManager>().IncreaseBallSpeed();
            Destroy(collision.gameObject);
            FindObjectOfType<SoundManager>().Play("PowerUp");
        }
        else if(collision.gameObject.tag == "Shrinker")
        {
            gameManager.GetComponent<GameManager>().DecreasePaddleSize();
            Destroy(collision.gameObject);
            FindObjectOfType<SoundManager>().Play("PowerUp");
        }

    }

}
