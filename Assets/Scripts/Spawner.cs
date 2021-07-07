using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    public float minValue;
    public float maxValue;

    public void Spawn()
    {
        float newY = Random.Range(minValue, maxValue);
        Vector2 newPos = new Vector2(transform.position.x, newY);

        Patrol enemyPatrol = Instantiate(enemyPrefab, newPos, Quaternion.identity).GetComponent<Patrol>();
        enemyPatrol.OnCreate();
    }
}
