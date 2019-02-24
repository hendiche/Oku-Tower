using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;   
    }

    public void updateScore(){
        score++;
        Debug.Log("Score is " + score);
    }
}
