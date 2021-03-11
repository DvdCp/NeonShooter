using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Smg : Weapon
{
   
    private void Awake() 
    {
        base.TimeToLive = 5f;
    }

    public override void Shoot()
    {
         Instantiate(_bulletPrefab, _weaponMuzzle.position, _weaponMuzzle.rotation);  
    }

    public override void Reload()
    {
        Debug.Log("Reloading...");
    }
}
