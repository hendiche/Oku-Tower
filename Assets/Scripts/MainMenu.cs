using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape")) {
            Application.Quit();
        }
    }

    public void onClick(string btn_name) {
        if (btn_name == "START") {
            SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
        }
        if (btn_name == "QUIT") {
            Application.Quit();
        }
    }
}
