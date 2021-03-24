using UnityEngine;

public class Smg : Weapon
{
    [SerializeField] private float rateoOfFire;

    public override void Shoot()
    {
        if(ReadyToShoot)
        {
            ReadyToShoot = false;

            var bullet = Instantiate(_bulletPrefab, _weaponMuzzle.position, _weaponMuzzle.rotation);
            bullet.GetComponent<Bullet>().Damage = base.damagePerBullet;

            if(AllowButtonHold)
                Invoke("ResetShoot", 1/rateoOfFire);

            //(bulletToShoot > 0) // per la raffica
                //Invoke("Shoot",0.3f);
        }
    }

}
