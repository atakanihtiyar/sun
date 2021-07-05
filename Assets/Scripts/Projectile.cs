using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speedMultiplier = 1;

    public void FireYourself(Vector2 direction)
    {
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = direction * speedMultiplier;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);

            Health enemyHealth = collision.GetComponent<Health>();
            enemyHealth.DecreaseHealth();
        }
    }

    public void DestroyMe()
    {
        Destroy(gameObject);
    }
}
