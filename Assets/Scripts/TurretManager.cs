using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretManager : MonoBehaviour
{
    public GameObject[] turrets;

    private void Start()
    {
        turrets[0].SetActive(true);
    }

    private void Update()
    {

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
}
