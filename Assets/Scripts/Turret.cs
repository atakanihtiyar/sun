using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject projectilePrefab;

    public void Fire()
    {
        GameObject projectileGO = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        Projectile projectile = projectileGO.GetComponent<Projectile>();
        
        Vector2 direction = transform.position - transform.parent.position;
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
