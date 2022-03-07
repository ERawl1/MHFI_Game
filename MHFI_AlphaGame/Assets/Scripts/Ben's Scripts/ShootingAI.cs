using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingAI : MonoBehaviour
{
    public GameObject projectile;
    private Transform player;

    private float timeBtwShots;
    public float startTimeBtwShots;
    public float stoppingDistance;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        timeBtwShots = startTimeBtwShots;
    }

  
    void Update()
    {
        if(Vector2.Distance(transform.position, player.position) < stoppingDistance)
        {
            if(timeBtwShots <= 0)
            {
                Instantiate(projectile, transform.position, Quaternion.identity);
                timeBtwShots = startTimeBtwShots;
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }
        }
    }
}
