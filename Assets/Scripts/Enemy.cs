using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject[] SpawnObjectsWhenIDie;
    public void DestroyMe()
    {
        for (int i = 0; i < SpawnObjectsWhenIDie.Length; i++)
        {
            Debug.Log("doğdum");
            Instantiate(SpawnObjectsWhenIDie[i]);
        }

        Destroy(gameObject);
    }
}
