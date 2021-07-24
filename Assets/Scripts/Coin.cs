using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private Rigidbody2D rigidbody2d;

    public int coin;

    private float speed = 0;

    private void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        GameObject sun = GameObject.FindGameObjectWithTag("Sun");

        speed += Time.fixedDeltaTime * 3;
        rigidbody2d.velocity = (sun.transform.position - transform.position).normalized * speed;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Sun"))
        {
            CoinManager.OnEarnScore(coin);
            Destroy(gameObject);
        }
    }
}
