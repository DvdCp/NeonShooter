﻿using UnityEngine;
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
                /*
                float Xoffset = Random.Range(-1f, 1f);
                float Yoffset = Random.Range(-1f, 1f);
                Vector3 appliedOffset = new Vector3( _weaponMuzzle.position.x + Xoffset, _weaponMuzzle.position.y + Yoffset,  _weaponMuzzle.position.z);
                */

                Vector3 appliedOffset = new Vector3(Random.Range(_weaponMuzzle.rect.xMin, _weaponMuzzle.rect.xMax),Random.Range(_weaponMuzzle.rect.yMin, _weaponMuzzle.rect.yMax), 0) + _weaponMuzzle.transform.position;

                var bullet = Instantiate(_bulletPrefab, appliedOffset, _weaponMuzzle.rotation);  
                bullet.GetComponent<Bullet>().Damage = base.damagePerBullet;
            }
        }
    }
    
}
