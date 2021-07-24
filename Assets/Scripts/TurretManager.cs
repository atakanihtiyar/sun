using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretManager : MonoBehaviour
{
    public Turret[] turrets;

    private void Start()
    {
        turrets[0].ChangeVisibility(true);
    }
    
    public void ActivateNextTurret()
    {
        for (int i = 0; i < turrets.Length; i++)
        {
            if (turrets[i].GetVisibility() == false)
            {
                turrets[i].ChangeVisibility(true);
                return;
            }
        }
    }
}
