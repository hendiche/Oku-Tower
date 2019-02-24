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
        
    }

    public void onClick(string btn_name) {
        Debug.Log("test click");
        if (btn_name == "START") {
            SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
        }
    }
}
