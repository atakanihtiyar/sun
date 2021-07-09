using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;

    public float minValue;
    public float maxValue;

    public void Spawn()
    {
        float newY = Random.Range(minValue, maxValue);
        Vector2 newPos = new Vector2(transform.position.x, newY);

        int randomEnemy = Random.Range(0, enemyPrefabs.Length);
        StraightMovement straightMovement = Instantiate(enemyPrefabs[randomEnemy], newPos, Quaternion.identity).GetComponent<StraightMovement>();
        straightMovement.OnCreate();
    }
}
