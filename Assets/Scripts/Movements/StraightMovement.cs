using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightMovement : MonoBehaviour
{
    protected Rigidbody2D rb2D;

    public float speed;

    protected int xDirection;
    protected int yDirection;
    protected Vector2 goal;

    protected virtual void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();

        xDirection = transform.position.x > 0 ? -1 : 1;
        yDirection = NewDirectionY();
        goal = NewGoal();
        rb2D.velocity = NewVelocity();
    }

    protected virtual void Update()
    {
        if ((goal - (Vector2)transform.position).magnitude < 0.2f)
        {
            yDirection = NewDirectionY();
            goal = NewGoal();
            rb2D.velocity = NewVelocity();
        }
    }

    public virtual void OnCreate()
    {
        rb2D = GetComponent<Rigidbody2D>();

        xDirection = transform.position.x > 0 ? -1 : 1;
        yDirection = NewDirectionY();
        goal = NewGoal();
        rb2D.velocity = NewVelocity();
    }

    public virtual int NewDirectionY()
    {
        return 0;
    }

    public virtual Vector2 NewGoal()
    {
        return new Vector2(transform.position.x + xDirection, transform.position.y + yDirection);
    }

    public virtual Vector2 NewVelocity()
    {
        return new Vector2(xDirection, yDirection).normalized * speed;
    }
}
