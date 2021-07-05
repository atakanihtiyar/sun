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

            Enemy enemy = collision.GetComponent<Enemy>();
            enemy.health--;
            if (enemy.health <= 0)
                Destroy(enemy.gameObject);
        }
    }

    public void DestroyMe()
    {
        Destroy(gameObject);
    }
}
