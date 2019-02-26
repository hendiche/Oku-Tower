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

    //Timer Stuff
    public float maxTime = 60f;
    private Text timerUI;
    private float timeRemaining;

    // Start is called before the first frame update
    void Start()
    {
        score = 0; 
        txt = GameObject.Find("Text (1)").GetComponent<Text>();
        GOTxt = GameObject.Find("GO Score").GetComponent<Text>();
        timerUI = GameObject.Find("Timer").GetComponent<Text>();

        scoreCanvas = GameObject.Find("CanvasGame");
        endCanvas = GameObject.Find("CanvasEnd");

        health = wasapiiMaxHP;

        //init
        timeRemaining = maxTime;
        UpdateTimer(timeRemaining);
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

    private void UpdateTimer(float time)
    {
        int min = Mathf.FloorToInt(time / 60f);
        int sec = Mathf.RoundToInt(time % 60f);

        timerUI.text = min.ToString("00") + ":" + sec.ToString("00");
    }

    private void Update()
    {
        timeRemaining -= Time.deltaTime;

        if(timeRemaining <= 0f){
            Debug.Log("Time is up.");
            isGameEnd = true;
            endCanvas.GetComponent<Canvas>().enabled = true;
            GOTxt.text = "スコア：" + score.ToString();
        }
        else{
            UpdateTimer(timeRemaining);
        }
    }

}
