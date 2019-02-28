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

    //HP stuff
    private float health;
    private Image HPBar;

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

        HPBar = GameObject.Find("HPBar").GetComponent<Image>();
        health = wasapiiMaxHP;
        UpdateHealthBar(health);

        //init
        timeRemaining = maxTime;
        UpdateTimer(timeRemaining);
    }

    public void UpdateScore(){

        if (!isGameEnd){
            SoundManagerScript.PlaySound("point");
            score++;
            txt.text = score.ToString();
            Debug.Log("Score is " + score);
        }
    }

    public void UpdateHP(){
        if(!isGameEnd){
            health--;
            UpdateHealthBar(health);

            if (health <= 0)
            {
                Debug.Log("Wasapii's HP is gone");
                isGameEnd = true;
                endCanvas.GetComponent<Canvas>().enabled = true;
                GOTxt.text = score.ToString();
                isStartCounting = true;
                countTime = 5.0f;
            }
            Debug.Log("Wasapii's HP is " + health);
        }
    }

    private void UpdateHealthBar(float remainingHP)
    {
        float percent = remainingHP / wasapiiMaxHP;
        HPBar.fillAmount = percent;

        if (HPBar.fillAmount <= 0.3){
            HPBar.color = new Color32(210, 46, 41, 255); //red
        }else if (HPBar.fillAmount <= 0.5) {
            HPBar.color = new Color32(224, 137, 30, 255); //yellow
        }else{
            HPBar.color = new Color32(32, 161, 50, 255); //green
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
