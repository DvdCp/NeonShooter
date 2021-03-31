using UnityEngine;
using Random = UnityEngine.Random;

public class Blaster : Weapon
{
    public int numberOfPelletsPerShot;
    
    public override void Shoot()
    {
        if(ReadyToShoot)
        {
            ReadyToShoot = false;

            for (int i = 0; i < numberOfPelletsPerShot; i++)
            {
                Vector3 appliedOffset = new Vector3(Random.Range(_weaponMuzzle.rect.xMin, _weaponMuzzle.rect.xMax), 
                                                    Random.Range(_weaponMuzzle.rect.yMin, _weaponMuzzle.rect.yMax), 
                                                    0f) + _weaponMuzzle.transform.position;

                var bullet = Instantiate(_bulletPrefab, appliedOffset, _weaponMuzzle.rotation);  
                bullet.GetComponent<Bullet>().Damage = base.damagePerBullet;
            }
        }
    }
    
}
