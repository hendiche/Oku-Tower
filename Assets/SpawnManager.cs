using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public int wasapiiHP;
    public GameObject enemy;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;

    public GameObject panel;

    //public int enemyLimit = 10;
    //private int enemiesDefeated = 0;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 boxSize = panel.GetComponent<SpriteRenderer>().bounds.size;
        Debug.Log(boxSize.x);
        Debug.Log(boxSize.y);
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    void Spawn()
    {
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        Vector3 randomPoint = spawnPoints[spawnPointIndex].position;

        switch (spawnPoints[spawnPointIndex].name)
        {
            case "Top":
            case "Bottom":
                randomPoint = randomPoint + new Vector3(Random.Range(-0.73f, 0.73f), 0, 0);
                break;
            case "Left":
            case "Right":
                randomPoint = randomPoint + new Vector3(0, Random.Range(-0.4f, 0.4f), 0);
                break;
        }


        Instantiate(enemy, randomPoint,
                    spawnPoints[spawnPointIndex].rotation);
    }

    public void StopSpawn(){
        CancelInvoke("Spawn");
        Debug.Log("Spawn Cancelled");
    }
}
