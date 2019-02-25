using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score;
    public int wasapiiHP = 10;
    public int killLimit = 10;
    private int killCount = 0;
    private Text txt;
    private Text GOTxt;
    private Text endTxt;
    private bool isGameEnd = false;
    //public Canvas endCanvas;
    public GameObject endCanvas;
    //public static GameObject scoreCanvas;

    // Start is called before the first frame update
    void Start()
    {
        score = 0; 
        txt = GameObject.Find("Text (1)").GetComponent<Text>();
        GOTxt = GameObject.Find("GO Score").GetComponent<Text>();
        endTxt = GameObject.Find("endText").GetComponent<Text>();
        endTxt.text = "";
        //endCanvas = GameObject.Find("CanvasEnd").GetComponent<Canvas>();

        endCanvas = GameObject.Find("CanvasEnd");
        //endCanvas = GetComponent<Canvas>();

        //Debug.Log("end is active " + endCanvas.activeInHierarchy);
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
            wasapiiHP--;

            if (wasapiiHP <= 0)
            {
                Debug.Log("Wasapii's HP is gone");
                isGameEnd = true;
                //GOTxt.text = score.ToString();
                //endTxt.text = "お疲れ様です！";
                endCanvas.GetComponent<Canvas>().enabled = true;
                GOTxt.text = "スコア："+ score.ToString();
                //GameObject.Find("SpawnManager").GetComponent<SpawnManager>().StopSpawn();
                //ChangeScreen();
                //endCanvas.enabled = true;
                //endCanvas.gameObject.SetActive(true);
            }
            Debug.Log("Wasapii's HP is " + wasapiiHP);
        }
    }

    public void UpdateKillCount(){

        if(isGameEnd){
            killCount++;
            Debug.Log("Kill count " + killCount);
            if (killCount >= killLimit)
            {
                Debug.Log("Number of defeated enemies reached.");
                isGameEnd = true;
                //changeScreen();
            }
        }
    }

    //private void ChangeScreen(){
    //    Debug.Log("changing screens");
    //    //SceneManager.LoadScene(screen, LoadSceneMode.Single);
    //    scoreCanvas.SetActive(false);
    //    endCanvas.SetActive(true);

    //    Debug.Log("end is active " + endCanvas.activeInHierarchy);
    //}
}
