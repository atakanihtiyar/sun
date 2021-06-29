using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretManager : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    public GameObject[] turrets;
    private bool isEnableNewTurret;

    private float passedTimeAfterLoop = 0;
    public float maxWaitTime;

    public Color startColor;
    public Color mainColor;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        isEnableNewTurret = false;
        passedTimeAfterLoop = 0;
        spriteRenderer.color = startColor;
        turrets[0].SetActive(true);
    }

    void FixedUpdate()
    {
        if (passedTimeAfterLoop >= maxWaitTime)
        {
            isEnableNewTurret = true;
        }
        else
        {
            passedTimeAfterLoop += Time.fixedDeltaTime;
            spriteRenderer.color = Color.Lerp(startColor, mainColor, RemapFloat(passedTimeAfterLoop, 0, maxWaitTime, 0, 1));
        }
    }

    private void OnMouseDown()
    {
        if (isEnableNewTurret)
        {
            ActivateNextTurret();
            passedTimeAfterLoop -= maxWaitTime;
            isEnableNewTurret = false;
        }
    }

    public void ActivateNextTurret()
    {
        for (int i = 0; i < turrets.Length; i++)
        {
            if (turrets[i].activeSelf == false)
            {
                turrets[i].SetActive(true);
                return;
            }
        }
    }

    float RemapFloat(float value, float baseRangeFrom, float baseRangeTo, float goalRangeFrom, float goalRangeTo)
    {
        return goalRangeFrom + (value - baseRangeFrom) * (goalRangeTo - goalRangeFrom) / (baseRangeTo - baseRangeFrom);
    }
}
