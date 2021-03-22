using UnityEngine;

public class Pistol : Weapon
{
    public override void Shoot()
    {
        if(ReadyToShoot)
        {
            ReadyToShoot = false;

            Instantiate(_bulletPrefab, _weaponMuzzle.position, _weaponMuzzle.rotation);
        }
    }
}
