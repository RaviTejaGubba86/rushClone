using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    public int myNum;
    private GenerateCube generate;
    private Renderer rend;

    void Start()
    {
        generate = GetComponentInParent<GenerateCube>();
        rend = GetComponent<Renderer>();

    }
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            generate.Message(myNum);
            //rend.material.color = Color.green;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}


