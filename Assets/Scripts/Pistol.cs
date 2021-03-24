using UnityEngine;

public class Pistol : Weapon
{
    public override void Shoot()
    {
        if(ReadyToShoot)
        {
            ReadyToShoot = false;

            var bullet = Instantiate(_bulletPrefab, _weaponMuzzle.position, _weaponMuzzle.rotation);
            bullet.GetComponent<Bullet>().Damage = base.damagePerBullet;
        }
    }
}
