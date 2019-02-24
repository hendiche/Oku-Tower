using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;

public class Destroy : MonoBehaviour
{
    public Transform explosionPrefab;
    // Start is called before the first frame update

    private GameObject gameManager;
    private GameManager gmScript;
    private bool scoreFlag = false;
    
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        gmScript = gameManager.GetComponent<GameManager>();
    }

    void OnCollisionEnter(Collision collision) {

      ContactPoint contact = collision.contacts[0];
      Vector3 pos = contact.point;

      if(collision.gameObject.tag == "enemy"){

      }else{
        if(collision.gameObject.tag != "tower" && !scoreFlag){
                scoreFlag = true;
                gmScript.updateScore();
                gmScript.updateKillCount();
                Instantiate (explosionPrefab, pos, Quaternion.identity);
                Destroy(this.gameObject);
        }else if(collision.gameObject.tag == "tower"){
                gmScript.updateHP();
                Instantiate (explosionPrefab, pos, Quaternion.identity);
                Destroy(this.gameObject);
        }
      }

    }

    void OnDestroy() {
      Destroy(transform.parent.gameObject);
    }
}
