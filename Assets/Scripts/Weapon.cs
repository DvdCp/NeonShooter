using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected GameObject _bulletPrefab;
    [SerializeField] protected Transform _weaponMuzzle;
    
    public abstract void Shoot();

    public abstract void Reload();
}
