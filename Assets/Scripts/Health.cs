using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public GameObject SpawnObjectWhenIDie;

    public float health;

    public void DecreaseHealth()
    {
        if (--health <= 0)
        {
            Instantiate(SpawnObjectWhenIDie, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }
    }
}
