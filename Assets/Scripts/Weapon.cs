using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected GameObject _bulletPrefab;
    [SerializeField] protected Transform _weaponMuzzle;
    [SerializeField] private bool isDefaultWeapon;
    [SerializeField] [Range (0f, 10f)]private float timeToLiveOnPlayer, timeToLiveOnGround;
    [SerializeField] protected float damagePerBullet;
    [SerializeField] private bool allowButtonHold;
    private bool isPicked, readyToShoot;
    private float _timer;
    
    /***PROPERTIERS***/
    public bool IsDefaultWeapon { get => isDefaultWeapon; set => isDefaultWeapon = value; }
    public float TimeToLiveOnPlayer { get => timeToLiveOnPlayer; set => timeToLiveOnPlayer = value; }
    public float TimeToLiveOnGround { get => timeToLiveOnGround; set => timeToLiveOnGround = value; }
    public bool IsPicked { get => isPicked; set => isPicked = value; }
    public bool ReadyToShoot { get => readyToShoot; set => readyToShoot = value; }
    public bool AllowButtonHold { get => allowButtonHold; set => allowButtonHold = value; }
    
    void Start() 
    {
        ReadyToShoot = true;
        _timer = 0f;
    }

    void Update() 
    {
        _timer += Time.deltaTime;

        if(!IsPicked)
        {
             HighlightWeapon();

             if(_timer > TimeToLiveOnGround)
                Destroy(gameObject);
        }
           
    }

    public abstract void Shoot();
  
    public void ResetShoot()
    {
        ReadyToShoot = true;
    }

    private void HighlightWeapon()
    {
        gameObject.transform.Rotate(Vector3.right * Time.deltaTime * 100);
        gameObject.transform.Rotate(Vector3.up * Time.deltaTime * 100);
    }
}
