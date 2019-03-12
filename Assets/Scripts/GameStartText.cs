using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartText : MonoBehaviour
{
    public AudioSource bgm;
    private GameManager gm;
    // Start is called before the first frame update
    public void StartGame()
    {
        gm = GameObject.Find ("GameManager").GetComponent<GameManager>();
        gm.startTextDone = true;
        Destroy(this.gameObject);

        //bgm = GameObject.Find("BGM").GetComponent<AudioSource>();
        bgm.Play();
    }

}
