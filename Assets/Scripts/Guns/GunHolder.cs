using System.Collections.Generic;
using UnityEngine;

public class GunHolder : MonoBehaviour
{
    private Gun gun;
    public int gunNr;
    public bool pickedUp;

    private void OnEnable()
    {
        gun = GunContainer.GetGun(gunNr);
    }

    public Gun GetGun()
    {
        return gun;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            GameObject[] turretGOs = GameObject.FindGameObjectsWithTag("Turret");
            List<Turret> turrets = new List<Turret>();
            for (int i = 0; i < turretGOs.Length; i++)
            {
                turrets.Add(turretGOs[i].GetComponent<Turret>());
                turrets[i].gun = gun;
            }
        }
    }
}