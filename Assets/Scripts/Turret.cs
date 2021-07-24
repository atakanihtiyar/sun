using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private float waitTime = 0;
    public float maxWaitTime;

    public GameObject projectilePrefab;
    public Gun gun;

    public Vector3[] positionArray;
    public int activePositionIndex = 0;

    private void Update()
    {
        if (waitTime >= maxWaitTime)
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                activePositionIndex = ++activePositionIndex % 2;
                waitTime %= maxWaitTime;
            }
        }
        else
        {
            waitTime += Time.deltaTime;
            transform.localPosition = Vector3.Lerp(positionArray[Mathf.Abs(activePositionIndex - 1) % 2], positionArray[activePositionIndex], RemapFloat(waitTime, 0, maxWaitTime, 0, 1));
        }
    }

    public void Fire()
    {
        GameObject projectileGO = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        Projectile projectile = projectileGO.GetComponent<Projectile>();
        
        projectile.FireYourself(Vector2.right);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            ChangeVisibility(false);
        }
    }

    public void ChangeVisibility(bool visible)
    {
        GetComponent<SpriteRenderer>().enabled = visible;
        GetComponent<PolygonCollider2D>().enabled = visible;
        GetComponent<Timer>().enabled = visible;
    }

    public bool GetVisibility()
    {
        return GetComponent<SpriteRenderer>().enabled;
    }

    float RemapFloat(float value, float baseRangeFrom, float baseRangeTo, float goalRangeFrom, float goalRangeTo)
    {
        return goalRangeFrom + (value - baseRangeFrom) * (goalRangeTo - goalRangeFrom) / (baseRangeTo - baseRangeFrom);
    }
}
