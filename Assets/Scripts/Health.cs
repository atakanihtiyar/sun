using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public List<UnityEvent> toDosWhenIDie;
    public List<GameObject> SpawnObjectsWhenIDie;

    public float health;

    public void DecreaseHealth()
    {
        --health;
        if (health <= 0)
        {
            toDosWhenIDie.ForEach(toDo => { toDo?.Invoke(); });
            SpawnObjectsWhenIDie.ForEach(spawnObject => 
            { 
                StraightMovement straightMovement = Instantiate(spawnObject, transform.position, Quaternion.identity).GetComponent<StraightMovement>();
                straightMovement.OnCreate();

            });
            Destroy(gameObject);
        }
    }
}
