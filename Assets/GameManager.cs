using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score;

    //Enemy stuff
    public int killLimit = 10;
    private int killCount = 0;

    //UI stuff
    private Text txt;
    private Text GOTxt;
    private bool isGameEnd = false;

    public bool startTextDone = false;

    //public Canvas endCanvas;
    public GameObject endCanvas;
    public GameObject scoreCanvas;

    //Timer Stuff
    public float maxTime = 60f;
    private Text timerUI;
    private float timeRemaining;
    private bool isSpawning = false;

    //Redirect Time
    private Text redirectTxt;
    private float countTime;
    private bool isStartCounting = false;

    //Cheer Text
    private Canvas cheerUI;
    private float cheerTimeOut = 2f;
    private bool cheerFlag = false;

    // Start is called before the first frame update
    void Start()
    {
        score = 0; 
        txt = GameObject.Find("Text").GetComponent<Text>();
        GOTxt = GameObject.Find("GO Score").GetComponent<Text>();
        timerUI = GameObject.Find("Timer").GetComponent<Text>();
        redirectTxt = GameObject.Find("RedirectText").GetComponent<Text>();

        scoreCanvas = GameObject.Find("CanvasGame");
        endCanvas = GameObject.Find("CanvasEnd");

        //init
        timeRemaining = maxTime;
        UpdateTimer(timeRemaining);
        txt.text = "スコア：" + score.ToString();

        cheerUI = GameObject.Find("Cheer").GetComponent<Canvas>();
    }

    public void UpdateScore(){

        if (!isGameEnd){
            SoundManagerScript.PlaySound("point");
            score++;
            txt.text = "スコア：" + score.ToString();
            Debug.Log("Score is " + score);
        }
    }

    public void DecreaseScore(){
        if(!isGameEnd && score > 0){
            score--;
            txt.text = "スコア：" + score.ToString();
            Debug.Log("Score is " + score);
        }

        //cheer!
        cheerUI.enabled = true;
        cheerFlag = true;
        cheerTimeOut = 2f;
    }

    public void UpdateKillCount(){

        if(!isGameEnd){
            killCount++;
            Debug.Log("Kill count " + killCount);
            if (killCount >= killLimit)
            {
                Debug.Log("Number of defeated enemies reached.");
                isGameEnd = true;
                scoreCanvas.GetComponent<Canvas>().enabled = false;
                endCanvas.GetComponent<Canvas>().enabled = true;
                GOTxt.text = score.ToString();
                isStartCounting = true;
                countTime = 5.0f;
            }
        }
    }

    private void UpdateTimer(float time)
    {
        int min = Mathf.FloorToInt(time / 60f);
        int sec = Mathf.FloorToInt(time % 60f);

        timerUI.text = min.ToString("00") + ":" + sec.ToString("00");
    }

    private void Update()
    {        
        if(startTextDone == true) {
            if (isStartCounting && countTime <= 0f) {
                SceneManager.LoadScene("MainMenuScene", LoadSceneMode.Single);
                return;
            }

            if(!isSpawning){
                isSpawning = true;
                GameObject.Find("SpawnManager").GetComponent<SpawnManager>().StartSpawn();
            }

            if(cheerFlag){
                cheerTimeOut -= Time.deltaTime;

                if(cheerTimeOut <= 0f){
                    cheerFlag = false;
                    cheerUI.enabled = false;
                    //cheerTimeOut = 2f;
                }
            }

            timeRemaining -= Time.deltaTime;

            if (isStartCounting) {
                redirectTxt.text = Mathf.RoundToInt(countTime % 60f).ToString() + "秒にメインメニューへ戻る";
                countTime -= Time.deltaTime;
                return;
            }

            if (timeRemaining <= 0f)
            {
                isGameEnd = true;
                scoreCanvas.GetComponent<Canvas>().enabled = false;
                endCanvas.GetComponent<Canvas>().enabled = true;
                GOTxt.text = score.ToString();
                isStartCounting = true;
                countTime = 5.0f;

            }
            else
            {
                UpdateTimer(timeRemaining);
            }
        }
    }

}
