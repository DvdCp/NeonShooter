using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected GameObject _bulletPrefab;
    [SerializeField] protected Transform _weaponMuzzle;
    [SerializeField] private bool isDefaultWeapon;
    [SerializeField] [Range (0f, 10f)]private float timeToLive;

    /***PROPERTIERS***/
    public bool IsDefaultWeapon { get => isDefaultWeapon; set => isDefaultWeapon = value; }
    public float TimeToLive { get => timeToLive; set => timeToLive = value; }

    public abstract void Shoot();

    public abstract void Reload();
}
