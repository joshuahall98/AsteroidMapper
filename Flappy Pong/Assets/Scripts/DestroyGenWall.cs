using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGenWall : MonoBehaviour
{
    public Vector2 rightDist;
    public Vector2 leftDist;
    public Vector2 playerPos;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {

        playerPos = player.transform.position;

        leftDist = playerPos + new Vector2(-40, 0);
        rightDist = playerPos + new Vector2(40, 0);

        if (this.gameObject.transform.position.x > rightDist.x)
        {
            Destroy(this.gameObject);
        }
        else if (this.gameObject.transform.position.x < leftDist.x)
        {
            Destroy(this.gameObject);
        }

    }
}
