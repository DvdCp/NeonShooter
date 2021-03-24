using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponSlot : MonoBehaviour
{
    [SerializeField] private GameObject _defaultWeaponGO;
    private GameObject _attualWeaponGO;
    private Weapon _attualWeaponScript;
    private float _weaponTimer;
    private bool isNewWeaponPicked;
    private bool isPullingTrigger;

    void Awake() 
    {
        // Default weapon at beginning 
        ResetDefaultWeapon();
        isPullingTrigger = false;
    }

    void Update() 
    {
        if(isNewWeaponPicked)
        {
            _weaponTimer -= Time.deltaTime;

             if(_weaponTimer <= 0f)
                ResetDefaultWeapon();
        }   

        if(isPullingTrigger)
            _attualWeaponScript.Shoot();  
    }

    public void PickWeapon(GameObject newWeaponGO)
    {
        if(_attualWeaponScript.IsDefaultWeapon)
        {
            _attualWeaponGO.SetActive(false);
            _attualWeaponScript.enabled = false;
        }
        else
        {
            Destroy(_attualWeaponGO);
        }
        
        newWeaponGO.transform.parent = transform;
        newWeaponGO.transform.position = transform.position;
        newWeaponGO.transform.rotation = transform.rotation;
        //newWeaponGO.SetActive(true);
        //newWeaponGO.GetComponent<Weapon>().enabled = true;

        _attualWeaponGO = newWeaponGO;

        _attualWeaponScript = _attualWeaponGO.GetComponent<Weapon>();
        _attualWeaponScript.IsPicked = true;
        _attualWeaponScript.GetComponent<Collider>().isTrigger = true;

        _weaponTimer = _attualWeaponScript.TimeToLiveOnPlayer;
        isNewWeaponPicked = true;
    }

    private void ResetDefaultWeapon()
    {
        Destroy(_attualWeaponGO);

        _attualWeaponGO = _defaultWeaponGO;
        _attualWeaponGO.SetActive(true);

        _attualWeaponScript = _attualWeaponGO.GetComponent<Weapon>();
        _attualWeaponScript.enabled = true;
        _attualWeaponScript.IsPicked = true;

        isNewWeaponPicked = false;
        _weaponTimer = 0f;
    }

    public void UseWeapon (InputAction.CallbackContext ctx)
    {
        if(ctx.started)
            isPullingTrigger = true;
        if(ctx.canceled)
        {
            isPullingTrigger = false;
            _attualWeaponScript.ResetShoot();
        }  
    }
  
}
