using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public int moveSpeed = 5 ;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position = transform.position += transform.right * -moveSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position = transform.position += transform.right * moveSpeed * Time.deltaTime;
        }
    }
}
