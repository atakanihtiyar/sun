using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private Transform goal;

    public float health;
    public float speedMultiplier;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        goal = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void FixedUpdate()
    {
        Vector3 diff = goal.position - transform.position;
        rigidBody.velocity = diff.normalized * speedMultiplier;
    }

    public void DestroyMe()
    {
        Destroy(gameObject);
    }
}
