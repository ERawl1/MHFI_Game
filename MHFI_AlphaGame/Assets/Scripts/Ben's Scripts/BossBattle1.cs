using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBattle1 : MonoBehaviour
{
    [SerializeField]
    Transform castPoint;

    [SerializeField]
    Transform player;

    [SerializeField]
    float agroRange;

    public Transform spawnPoint1;
    public Transform spawnPoint2;
    public Transform spawnPoint3;
    public Transform spawnPoint4;

    public GameObject Enemy1;
    public GameObject Enemy2;
    public GameObject Enemy3;
    public GameObject Enemy4;

    public int Enemysnow = 0;
    public int enemyMax = 4;
    private bool maxreached = false;

    



    Rigidbody2D rb2d;

    bool isFacingLeft;

    private bool isAgro = false;
    private bool isSearching;

    public GameObject[] enemies;
    public GameObject[] spawnPoints;


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        maxreached = Enemysnow >= enemyMax;

        if (CanSeePlayer(agroRange) && Enemysnow < enemyMax) 
        {
            isAgro = true;
            
        }
        else
        {
            isAgro = false;
        }
       

        if (isAgro)
        {
            Instantiate(Enemy1, spawnPoint1);
            Enemysnow++;
            Instantiate(Enemy2, spawnPoint2);
            Enemysnow++;
            Instantiate(Enemy3, spawnPoint3);
            Enemysnow++;
            Instantiate(Enemy4, spawnPoint4);
            Enemysnow++;
            
            isAgro = false;

            
        }


    }


    bool CanSeePlayer(float distance)
    {
        bool val = false;
        float castDist = distance;

        if (isFacingLeft)
        {
            castDist = -distance;
        }

        Vector2 endPos = castPoint.position + Vector3.left * castDist;

        RaycastHit2D hit = Physics2D.Linecast(castPoint.position, endPos, 1 << LayerMask.NameToLayer("Action"));

        if (hit.collider != null)
        {

            if (hit.collider.gameObject.CompareTag("Player"))
            {
                val = true;
            }
            else
            {
                val = false;
            }
            Debug.DrawLine(castPoint.position, hit.point, Color.yellow);

        }
        else
        {
            Debug.DrawLine(castPoint.position, endPos, Color.blue);
        }

        return val;

    }

  

    
    

   



}
