using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected GameObject _bulletPrefab;
    [SerializeField] protected Transform _weaponMuzzle;
    [SerializeField] private bool isDefaultWeapon;
    [SerializeField] [Range (0f, 10f)]private float timeToLive;
    private bool isPicked;

    /***PROPERTIERS***/
    public bool IsDefaultWeapon { get => isDefaultWeapon; set => isDefaultWeapon = value; }
    public float TimeToLive { get => timeToLive; set => timeToLive = value; }
    public bool IsPicked { get => isPicked; set => isPicked = value; }

    private void Update() 
    {
        if(!IsPicked)
            HighlightWeapon();
    }

    public abstract void Shoot();

    public abstract void Reload();

    private void HighlightWeapon()
    {
        gameObject.transform.Rotate(Vector3.right * Time.deltaTime * 100);
        gameObject.transform.Rotate(Vector3.up * Time.deltaTime * 100);
    }

}
