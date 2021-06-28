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
        float newX = Random.Range(minValue, maxValue);
        Vector2 newPos = new Vector2(newX, transform.position.y);
        Enemy enemy = Instantiate(enemyPrefab, newPos, Quaternion.identity).GetComponent<Enemy>();
    }
}
