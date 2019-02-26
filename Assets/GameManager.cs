using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score;
    public int wasapiiMaxHP = 10;

    //Enemy stuff
    public int killLimit = 10;
    private int killCount = 0;
    private float health;

    //UI stuff
    private Text txt;
    private Text GOTxt;
    private bool isGameEnd = false;

    //public Canvas endCanvas;
    public GameObject endCanvas;
    public GameObject scoreCanvas;

    // Start is called before the first frame update
    void Start()
    {
        score = 0; 
        txt = GameObject.Find("Text (1)").GetComponent<Text>();
        GOTxt = GameObject.Find("GO Score").GetComponent<Text>();

        scoreCanvas = GameObject.Find("CanvasGame");
        endCanvas = GameObject.Find("CanvasEnd");

        health = wasapiiMaxHP;
    }

    public void UpdateScore(){

        if (!isGameEnd){
            score++;
            txt.text = score.ToString();
            Debug.Log("Score is " + score);
        }
    }

    public void UpdateHP(){
        if(!isGameEnd){
            health--;

            if (health <= 0)
            {
                Debug.Log("Wasapii's HP is gone");
                isGameEnd = true;
                endCanvas.GetComponent<Canvas>().enabled = true;
                GOTxt.text = "スコア："+ score.ToString();
            }
            Debug.Log("Wasapii's HP is " + health);
        }
    }

    public void UpdateKillCount(){

        if(!isGameEnd){
            killCount++;
            Debug.Log("Kill count " + killCount);
            if (killCount >= killLimit)
            {
                Debug.Log("Number of defeated enemies reached.");
                isGameEnd = true;
                endCanvas.GetComponent<Canvas>().enabled = true;
                GOTxt.text = "スコア：" + score.ToString();
            }
        }
    }

}
