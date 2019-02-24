using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;

public class Destroy : MonoBehaviour
{
    public Transform explosionPrefab;
    // Start is called before the first frame update

    public GameObject gameManager;
    private bool scoreFlag = false;
    
    void Start()
    {
        gameManager = GameObject.Find("GameManager");  
    }

    void OnCollisionEnter(Collision collision) {

      ContactPoint contact = collision.contacts[0];
      Vector3 pos = contact.point;

      if(collision.gameObject.tag == "enemy"){

      }else{
        if(collision.gameObject.tag != "tower" && !scoreFlag){
            scoreFlag = true;
            gameManager.GetComponent<GameManager>().updateScore();
            Instantiate (explosionPrefab, pos, Quaternion.identity);
            Destroy(this.gameObject);
            Debug.Log("Score++");
        }else{
          Instantiate (explosionPrefab, pos, Quaternion.identity);
          Destroy(this.gameObject);
        }
      }

    }

    void OnDestroy() {
      Debug.Log("hello");
      Destroy(transform.parent.gameObject);
    }
}
