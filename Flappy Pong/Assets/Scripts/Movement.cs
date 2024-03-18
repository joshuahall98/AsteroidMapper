using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public int moveSpeed = 5 ;
    public int rotationSpeed = 30;

    public GameObject leftBooster;
    public GameObject rightBooster;

    public GameObject ship;

    bool sfx = false;

    private void Start()
    {
        rightBooster = GameObject.Find("RightBooster");
        leftBooster = GameObject.Find("LeftBooster");
        ship = GameObject.Find("SpaceShipJack");
    }

    // Update is called once per frame
    void Update()
    {

        if(Time.timeScale != 0)
        {
            if (Input.GetKey(KeyCode.A))
            {
                transform.position = transform.position += transform.right * -moveSpeed * Time.deltaTime;
                rightBooster.gameObject.SetActive(true);

                if (ship.transform.localRotation.z < 0.05f)
                {
                    ship.transform.Rotate(new Vector3(0, 0, rotationSpeed) * Time.deltaTime);
                }

                if (sfx == false)
                {
                    FindObjectOfType<SoundManager>().Play("Thruster");
                    sfx = true;
                }
                

            }
            else
            {
                rightBooster.gameObject.SetActive(false);

                if (ship.transform.localRotation.z > 0)
                {
                    ship.transform.Rotate(new Vector3(0, 0, -rotationSpeed) * Time.deltaTime);
                }

                
            }

            if (Input.GetKey(KeyCode.D))
            {
                transform.position = transform.position += transform.right * moveSpeed * Time.deltaTime;
                leftBooster.gameObject.SetActive(true);

                if (ship.transform.localRotation.z > -0.05f)
                {
                    ship.transform.Rotate(new Vector3(0, 0, -rotationSpeed) * Time.deltaTime);
                }

                if (sfx == false)
                {
                    FindObjectOfType<SoundManager>().Play("Thruster");
                    sfx = true;
                }
            }
            else
            {
                leftBooster.gameObject.SetActive(false);

                if (ship.transform.localRotation.z < 0)
                {
                    ship.transform.Rotate(new Vector3(0, 0, rotationSpeed) * Time.deltaTime);
                }

            }

            if(!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
            {
                if (sfx == true)
                {
                    FindObjectOfType<SoundManager>().Stop("Thruster");
                    sfx = false;
                }
            }
            
        }
 
    }

}
