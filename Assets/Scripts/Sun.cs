using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    private float multiplier = 50;
    public float speed;

    public float yMin;
    public float yMax;

    public float minRotateAngle;
    public float maxRotateAngle;

    private void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float yDiff = verticalInput * speed * Time.deltaTime;
        if (transform.position.y + yDiff < yMax && transform.position.y + yDiff > yMin)
            transform.Translate(0, yDiff, 0);
    }
    
    void FixedUpdate()
    {
        float turnInput = Input.GetAxis("Fire1");

        if (turnInput != 0)
        {
            transform.Rotate(Vector3.back * turnInput * multiplier * Time.fixedDeltaTime);
            
            Vector3 currentRotation = transform.localEulerAngles;
            currentRotation.z = Mathf.Clamp(currentRotation.z, minRotateAngle, maxRotateAngle);
            transform.localEulerAngles = currentRotation;
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
