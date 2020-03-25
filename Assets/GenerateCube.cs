using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GenerateCube : MonoBehaviour
{

    

    public GameObject obstacleObj;
    Vector3 pos;
    bool next;
    public float[] posX;
    public float[] posZ;
    int value = 1;
    public int lastPos = 1;
    public Text score;
    public Text gameover;
    


    void Start()
    {
        
    }

    
    void FixedUpdate()
    {
        StartCoroutine(WaitSys());
    }

    IEnumerator WaitSys()
    {
        yield return new WaitForSeconds(2f);
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
        GameObject obstacleClone = Instantiate(obstacleObj, pos, obstacleObj.transform.rotation);
        obstacleClone.GetComponent<ObstacleScript>().myNum = value;
        obstacleClone.transform.SetParent(this.transform);
        value += 1;
        next = false;
    }

    public void Message(int i)
    {
        Debug.Log("Score is :" + i);
        score.text = "Score: " + i;
        gameover.text = "Game Over!!";
        loadNewGame();
        
    }

    void loadNewGame()
    {
        SceneManager.LoadScene("AI Project", LoadSceneMode.Single);
    }
}


