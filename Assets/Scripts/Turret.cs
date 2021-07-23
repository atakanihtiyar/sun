using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Gun gun;

    public void Fire()
    {
        GameObject projectileGO = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        Projectile projectile = projectileGO.GetComponent<Projectile>();
        
        Vector2 direction = new Vector2(transform.position.x - transform.parent.position.x, 0);
        projectile.FireYourself(direction);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            gameObject.SetActive(false);
        }
    }
}
