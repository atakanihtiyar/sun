using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    private float multiplier = 50;

    void FixedUpdate()
    {
        float turnInput = Input.GetAxis("Fire1");
        if (turnInput != 0)
        {
            transform.Rotate(Vector3.back * turnInput * multiplier * Time.fixedDeltaTime);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log(name + " and " + collision.name + " collide");
        }
    }
}
