using UnityEngine;

public class GunHolder : MonoBehaviour
{
    private Gun gun;
    public int gunNr;
    public bool pickedUp;

    private void Start()
    {
        gun = GunContainer.GetGun(gunNr);
    }

    public Gun GetGun()
    {
        return gun;
    }
}