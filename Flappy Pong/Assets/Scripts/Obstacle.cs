using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private float curveAmount =0;
    private float rotateSpeed;

    int num;

    private void Start()
    {
        num = Random.Range(0, 2);
        rotateSpeed = Random.Range(50, 200);
    }

    private void Update()
    {

        if(num == 0)
        {
            //curveAmount++;
            //this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, Quaternion.Euler(0.0f, 0.0f, -curveAmount), rotateSpeed * Time.deltaTime);
            curveAmount += Time.deltaTime * rotateSpeed;
        }
        else if (num == 1)
        {
            curveAmount += -Time.deltaTime * rotateSpeed;
            //curveAmount++;
            //this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, Quaternion.Euler(0.0f, 0.0f, curveAmount), rotateSpeed * Time.deltaTime);
        }
        transform.rotation = Quaternion.Euler(0, 0, curveAmount);
        
    }
}
