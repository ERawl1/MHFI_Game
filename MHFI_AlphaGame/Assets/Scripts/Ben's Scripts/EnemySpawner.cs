using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    public float spawnRadius = 3, time = 2f;
    public int Enemysnow = 0;
    public int enemyMax = 3;
    private bool maxreached = false; // Bool that stores the Information if the maximum is reached
    
    public GameObject enemies;

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collider)
    {
        StartCoroutine(SpawnEnemy()); //Start the Couroutine 
    }

    IEnumerator SpawnEnemy() // that is the important part
    {
        while (true)
        {
            if (!maxreached)
            {
                Vector2 spawnPos = GameObject.Find("Player").transform.position; //Spawning an enemy near player
                spawnPos.x += Random.Range(-spawnRadius, spawnRadius);

                Instantiate(enemies, spawnPos, Quaternion.identity);
                yield return new WaitForSeconds(time);
                Enemysnow++; // increase the enemy counter
            }
            //yield return null;
            else
            {
                StopCoroutine(SpawnEnemy());
            }
            yield return null;
        }
    }

   /* public void lowerMaxEnemys()
    {
        Enemysnow--; // decrease the enemy counter if an enemy is killed(for other)
    }*/
    public void Update()
    {
        maxreached = Enemysnow >= enemyMax;
        
    }
    public void HigherMaxEnemys(int amount)
    {
        enemyMax += amount;
    }
    public void HigherSpawnRade(float amount)
    {
        time -= amount;
    }
}

