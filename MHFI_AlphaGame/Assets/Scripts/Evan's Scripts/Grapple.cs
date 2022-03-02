using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple : MonoBehaviour
{
    public Camera cam;
    public LineRenderer lr;

    //Determines what we can grapple onto
    public LayerMask grappleMask;
    public float grappleSpeed = 2;
    public float grappleLength = 10;

    public int maxPoints = 1;

    private Rigidbody2D rb2D;
    private List<Vector2> points = new List<Vector2>();

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        lr.positionCount = 0;
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = (mousePos - (Vector2)transform.position).normalized;

            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, grappleLength, grappleMask);

            if(hit.collider != null)
            {
                Vector2 hitPoint = hit.point;
                    points.Add(hitPoint);

                if(points.Count > maxPoints)
                {
                    points.RemoveAt(0);
                }
            }
        }
        if (points.Count > 0)
        {
            Vector2 moveTo = centroid(points.ToArray());

            rb2D.MovePosition(Vector2.MoveTowards(transform.position, moveTo, Time.deltaTime * grappleSpeed));

            lr.positionCount = 0;
            lr.positionCount = points.Count * 2;

            for(int n=0, j=0; n < points.Count *2; n+=2, j++)
            {
                lr.SetPosition(n, transform.position);
                lr.SetPosition(n + 1, points[j]);
            }
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            Detach();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Detach();
        }
    }

    void Detach()
    {
        lr.positionCount = 0;
        points.Clear();
    }

   Vector2 centroid(Vector2[] points)
    {
        Vector2 center = Vector2.zero;
        foreach(Vector2 point in points)
        {
            center += point;
        }
        center /= points.Length;
        return center;
    } 
}
