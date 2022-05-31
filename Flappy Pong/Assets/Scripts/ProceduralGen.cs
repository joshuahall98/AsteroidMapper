using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralGen : MonoBehaviour
{
    public int width;
    public float dist;
    public float dist2;
    public Vector2 playerPos;
    public Vector2 playerPos2;
    public Vector2 newPlayerPos;
    public Vector2 obstaclePos;


    public GameObject obstacle;
    public List<GameObject> obstacleList;
    int obstacleNum;

    public GameObject wall;
    public GameObject player;
    public GameObject gameOver;
    public GameObject doubleBallsPU;
    public GameObject speedBallPU;
    public GameObject doublePointsPU;
    public GameObject shrinkerPU;

    int x;
    int y;
    int numberOfBlocks;
    int powerUpChance;

    // Start is called before the first frame update
    void Start()
    {
        Generation();
        
    }

    private void Update()
    {
        newPlayerPos = player.transform.position;

        dist = Vector2.Distance(playerPos, newPlayerPos);
        dist2 = Vector2.Distance(playerPos2, newPlayerPos);

        //spawn all else
        if (dist > 5 && playerPos.x < newPlayerPos.x)
        {
            MovingGenRight();
        }
        else if(dist > 5 && playerPos.x > newPlayerPos.x)
        {
            MovingGenLeft();
        }

    }

    void Generation()
    {
        numberOfBlocks = Random.Range(10, 20);

        powerUpChance = Random.Range(0,10);

        playerPos = player.transform.position;

        for (int i = 0; i < numberOfBlocks; i++)
        {

            x = Random.Range(-15, 15);

            y = Random.Range(2, 8);

            obstaclePos = playerPos + new Vector2(x,y);

            obstacleNum = Random.Range(0, 3);

            Instantiate(obstacleList[obstacleNum], obstaclePos, Quaternion.identity);

        }

        if(powerUpChance == 5)
        {
            Instantiate(doubleBallsPU, playerPos + new Vector2(Random.Range(-15,15), Random.Range(2,8)), Quaternion.identity);

        }
        if (powerUpChance == 3)
        {
            Instantiate(speedBallPU, playerPos + new Vector2(Random.Range(-15, 15), Random.Range(2, 8)), Quaternion.identity);

        }
        if (powerUpChance == 7)
        {
            Instantiate(doublePointsPU, playerPos + new Vector2(Random.Range(-15, 15), Random.Range(2, 8)), Quaternion.identity);

        }
        if (powerUpChance == 1)
        {
            Instantiate(shrinkerPU, playerPos + new Vector2(Random.Range(-15, 15), Random.Range(2, 8)), Quaternion.identity);

        }

        Instantiate(wall, playerPos + new Vector2(0, 9), Quaternion.identity);
        Instantiate(gameOver, playerPos + new Vector2(0, -1), Quaternion.identity);
    }

    void MovingGenRight()
    {
        numberOfBlocks = Random.Range(2, 7);

        powerUpChance = Random.Range(0, 10);

        playerPos = player.transform.position;

        for (int i = 0; i < numberOfBlocks; i++)
        {

            x = Random.Range(15, 20);

            y = Random.Range(2, 8);

            obstaclePos = playerPos + new Vector2(x, y);

            obstacleNum = Random.Range(0, 3);

            Instantiate(obstacleList[obstacleNum], obstaclePos, Quaternion.identity);
        }

        if (powerUpChance == 5)
        {
            Instantiate(doubleBallsPU, playerPos + new Vector2(Random.Range(15, 20), Random.Range(2, 8)), Quaternion.identity);
        }
        if (powerUpChance == 3)
        {
            Instantiate(speedBallPU, playerPos + new Vector2(Random.Range(15, 20), Random.Range(2, 8)), Quaternion.identity);

        }
        if (powerUpChance == 7)
        {
            Instantiate(doublePointsPU, playerPos + new Vector2(Random.Range(15, 20), Random.Range(2, 8)), Quaternion.identity);

        }
        if (powerUpChance == 1)
        {
            Instantiate(shrinkerPU, playerPos + new Vector2(Random.Range(15, 20), Random.Range(2, 8)), Quaternion.identity);

        }

        Instantiate(gameOver, playerPos + new Vector2(0, -1), Quaternion.identity);
        Instantiate(wall, playerPos + new Vector2(35, 9), Quaternion.identity);

    }

    void MovingGenLeft()
    {
        numberOfBlocks = Random.Range(2, 7);

        powerUpChance = Random.Range(0, 10);

        playerPos = player.transform.position;

        for (int i = 0; i < numberOfBlocks; i++)
        {

            x = Random.Range(-15, -20);

            y = Random.Range(2, 8);

            obstaclePos = playerPos + new Vector2(x, y);

            obstacleNum = Random.Range(0, 3);

            Instantiate(obstacleList[obstacleNum], obstaclePos, Quaternion.identity);
        }

        if (powerUpChance == 5)
        {
            Instantiate(doubleBallsPU, playerPos + new Vector2(Random.Range(-15, -20), Random.Range(2, 8)), Quaternion.identity);
        }
        if (powerUpChance == 3)
        {
            Instantiate(speedBallPU, playerPos + new Vector2(Random.Range(-15, -20), Random.Range(2, 8)), Quaternion.identity);

        }
        if (powerUpChance == 7)
        {
            Instantiate(doublePointsPU, playerPos + new Vector2(Random.Range(-15, -20), Random.Range(2, 8)), Quaternion.identity);

        }
        if (powerUpChance == 1)
        {
            Instantiate(shrinkerPU, playerPos + new Vector2(Random.Range(-15, -20), Random.Range(2, 8)), Quaternion.identity);

        }

        Instantiate(gameOver, playerPos + new Vector2(0, -1), Quaternion.identity);
        Instantiate(wall, playerPos + new Vector2(-35, 9), Quaternion.identity);

    }

}
