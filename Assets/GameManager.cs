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

    public void updateHP(){
        wasapiiHP--;

        if(wasapiiHP <= 0){
            //changeScreen();
        }
        Debug.Log("Wasapii's HP is " + wasapiiHP);
    }

    public void updateKillCount(){

        killCount++;
        Debug.Log("Kill count " + killCount);
        if(killCount >= killLimit){
            Debug.Log("Number of defeated enemies reached.");
            //changeScreen();
        }
    }

    //private void changeScreen(screen){
    //    SceneManager.LoadScene(screen, LoadSceneMode.Single);
    //}
}
