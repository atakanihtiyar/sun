﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject projectilePrefab;

    private float timeAfterLoop = 0;
    public float maxWaitTime;


    void FixedUpdate()
    {
        timeAfterLoop += Time.fixedDeltaTime;

        if (timeAfterLoop >= maxWaitTime)
        {
            Fire();

            timeAfterLoop -= maxWaitTime;
        }
    }

    public void Fire()
    {
        GameObject projectileGO = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        Projectile projectile = projectileGO.GetComponent<Projectile>();
        projectile.FireYourself();
    }
}