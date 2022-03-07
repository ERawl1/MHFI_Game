using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBattle2 : MonoBehaviour
{

    public bool insideSpawn = false;
    public GameObject[] spawnPoints;
    public GameObject bossEnemies;
    
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Instantiate(bossEnemies, transform.position, Quaternion.identity);


    }
        void Update()
    {
        
    }
}
