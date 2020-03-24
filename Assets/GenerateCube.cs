using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GenerateCube : MonoBehaviour
{

    

    public GameObject coinObj;
    Vector3 pos;
    bool next;
    public float[] posX;
    public float[] posZ;
    public float[] posY;
    int value = 1;
    public int lastPos = 1;
   /* public Text scoreboard;
    public Text gameover;
    private int score = 0;*/


    void Start()
    {
        /*score = 0;
        gameover.text = "";*/
    }

    void FixedUpdate()
    {
        StartCoroutine(WaitSys());
    }

    IEnumerator WaitSys()
    {
        yield return new WaitForSeconds(1f);
        next = true;
        Generate();
    }

    void Generate()
    {
        if (!next)
            return;
        int i = Random.Range(0, 2);
        pos.x = posX[i];
        pos.z += posZ[i];
        pos.y = 0.35f;
        GameObject cubeClone = Instantiate(coinObj, pos, coinObj.transform.rotation);
        cubeClone.GetComponent<CubeScript>().myNum = value;
        cubeClone.transform.SetParent(this.transform);
        value += 1;
        next = false;
    }

    public void Message(int i)
    {
        if (lastPos == i)
        {
            lastPos += 1;
            
            Debug.Log("Found");
        }
        else
        {
            Debug.Log("Not Found");
            SceneManager.LoadScene("AI Project",LoadSceneMode.Single);
        }

    }
}


