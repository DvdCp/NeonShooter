using UnityEngine;

public class Pistol : Weapon
{
    public override void Shoot()
    {
        Instantiate(_bulletPrefab, _weaponMuzzle.position, _weaponMuzzle.rotation);
    }

    public override void Reload()
    {
        Debug.Log("Reloading...");
    }
}
