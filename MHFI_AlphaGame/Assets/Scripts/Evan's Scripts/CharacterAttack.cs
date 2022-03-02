using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public Transform atkPos;
    public LayerMask whatIsEnemies;
    public float atkRadius;
    public int damage;

    void Start()
    {
        
    }

    
    void Update()
    {
        if (timeBtwAttack <= 0)
        {
            //Attack
            if (Input.GetKey(KeyCode.Space))
            {
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(atkPos.position, atkRadius, whatIsEnemies);

                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
                }
            }

            timeBtwAttack = startTimeBtwAttack;
        }
        else{

            timeBtwAttack -= Time.deltaTime;
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(atkPos.position, atkRadius);
    }
}
