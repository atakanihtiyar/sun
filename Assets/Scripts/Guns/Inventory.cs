using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private Gun gun;

    // TODO: Bu fonksiyon upgrade'i aldığımız zaman aktifleşecek. Upgrade'e dokunma ya da upgrade'e ateş etme gibi. verdiğimiz gameobject Weapon scriptini içermeli
    public void PickupGun(GameObject g)
    {
        if (g == null) return;
        Weapon w = (Weapon)g.GetComponent(typeof(Weapon));
        if (w.pickedUp) return;
        w.pickedUp = true;

        gun = w.GetGun();

        // Belki weapon object destroy edilebilir.
        g.SetActive(false);
    }

    public Gun GetCurrentGun()
    {
        return gun;
    }

    public void ResetInventory()
    {
        gun = null;
    }
}