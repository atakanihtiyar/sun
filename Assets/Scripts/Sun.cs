using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    public float speed;

    public float yMin;
    public float yMax;

    private void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float yDiff = verticalInput * speed * Time.deltaTime;
        if (transform.position.y + yDiff < yMax && transform.position.y + yDiff > yMin)
            transform.Translate(0, yDiff, 0);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log(name + " and " + collision.name + " collide");
        }
    }
}
