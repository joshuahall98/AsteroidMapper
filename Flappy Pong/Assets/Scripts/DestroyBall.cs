using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBall : MonoBehaviour
{
    public Vector2 rightDist;
    public Vector2 leftDist;
    public Vector2 playerPos;
    public GameObject player;
    public GameObject gameManager;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = player.transform.position;

        leftDist = playerPos + new Vector2(-25, 0);
        rightDist = playerPos + new Vector2(25, 0);

        if (this.gameObject.transform.position.x > rightDist.x)
        {
            gameManager.GetComponent<GameManager>().DecreaseBallCount();
            Destroy(this.gameObject);
        }
        else if (this.gameObject.transform.position.x < leftDist.x)
        {
            gameManager.GetComponent<GameManager>().DecreaseBallCount();
            Destroy(this.gameObject);
        }

    }
}
