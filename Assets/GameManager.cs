using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public int wasapiiHP = 10;
    public int killLimit = 10;
    private int killCount = 0;

    public void updateScore(){
        score++;
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
