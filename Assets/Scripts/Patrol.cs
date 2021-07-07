using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    private Rigidbody2D rb2D;

    public float speed;
    public float minY;
    public float maxY;

    public int xDirection;
    public Vector2 goal;

    void Update()
    {
        if ((goal - (Vector2)transform.position).magnitude < 0.2f)
        {
            rb2D.velocity = NewVelocity();
        }
    }

    public void OnCreate()
    {
        rb2D = GetComponent<Rigidbody2D>();

        xDirection = transform.position.x > 0 ? -1 : 1;

        goal = transform.position;
        rb2D.velocity = NewVelocity();
    }

    public Vector2 NewVelocity()
    {
        int yDirection = Random.Range(-1, 2);
        yDirection = goal.y + yDirection > minY && goal.y + yDirection < maxY ? yDirection : 0;

        goal += new Vector2Int(xDirection, yDirection);
        return (goal - (Vector2)transform.position).normalized * speed;
    }
}
