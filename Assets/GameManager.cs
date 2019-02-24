using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score;
    private Text txt;

    // Start is called before the first frame update
    void Start()
    {
        score = 0; 
        txt = GameObject.Find("Text (1)").GetComponent<Text>();
    }

    public void updateScore(){
        score++;
        txt.text = score.ToString();
        Debug.Log("Score is " + score);
    }
}
