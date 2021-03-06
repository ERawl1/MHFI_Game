using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowAi : MonoBehaviour
{
    public float speed;
    public Transform target;
    public float minimumDistance;


    // Update is called once per frame
    private void Update()
    {
       if(Vector2.Distance(transform.position, target.position) > minimumDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else
        {
            //Attack
        }
    }
}
