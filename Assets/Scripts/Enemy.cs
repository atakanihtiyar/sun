using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    public Transform goal;
    public float speedMultiplier;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
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
