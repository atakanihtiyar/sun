using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    public float speed;

    public float yMin;
    public float yMax;

    public TurretManager turretManager;
    private float waitTime = 0;
    public float maxWaitTime;

    private SpriteRenderer spriteRenderer;
    public Color startColor;
    public Color mainColor;

    private void Start()
    {
        waitTime = 0;

        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = startColor;
    }

    private void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float yDiff = verticalInput * speed * Time.deltaTime;
        if (transform.position.y + yDiff < yMax && transform.position.y + yDiff > yMin)
            transform.Translate(0, yDiff, 0);

        if (waitTime >= maxWaitTime)
        {
            if (Input.GetKey(KeyCode.Alpha1) || Input.GetKey(KeyCode.Keypad1))
            {
                turretManager.ActivateNextTurret();
                waitTime -= maxWaitTime;
            }
        }
        else
        {
            waitTime += Time.deltaTime;
            spriteRenderer.color = Color.Lerp(startColor, mainColor, RemapFloat(waitTime, 0, maxWaitTime, 0, 1));
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log(name + " and " + collision.name + " collide");
        }
    }

    float RemapFloat(float value, float baseRangeFrom, float baseRangeTo, float goalRangeFrom, float goalRangeTo)
    {
        return goalRangeFrom + (value - baseRangeFrom) * (goalRangeTo - goalRangeFrom) / (baseRangeTo - baseRangeFrom);
    }
}
