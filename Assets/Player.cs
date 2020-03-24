using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float value = -0.5f;
    GameObject currentLevel;
    GameObject previousLevel;
    int z;

    void Start()
    {
        z = 0;
    }


    void FixedUpdate()
    {
        //transform.position = new Vector3();
        transform.Translate(new Vector3(0, 0, 2) * Time.deltaTime);
        transform.position = new Vector3(value, transform.position.y, transform.position.z);
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if(value == -0.5f)
            {
                
                value = 0.5f;
                
            }
            else 
            {
                return;
            }
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (value == 0.5f)
            {
                value = -0.5f;
            }
            else
            {
                return;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlaneTrigger")
        {
            z += 20;
            previousLevel = currentLevel;
            currentLevel = (GameObject)Instantiate(Resources.Load("Level"), new Vector3(0, 0, z), Quaternion.identity);
        }
    }
}
