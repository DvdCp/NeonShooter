using System.Collections;
using UnityEngine;

public class WeaponSlot : MonoBehaviour
{
    [SerializeField] private GameObject _defaultWeaponGO;
    private GameObject _attualWeaponGO;
    private Weapon _attualWeaponScript;
    private float _weaponTimer;
    private bool isNewWeaponPicked;

    void Awake() 
    {
        // Default weapon at beginning 
        _attualWeaponGO = _defaultWeaponGO;
        _attualWeaponScript = _attualWeaponGO.GetComponent<Weapon>();
        isNewWeaponPicked = false;
    }

    void Update() 
    {
        if(isNewWeaponPicked)
        {
            _weaponTimer -= Time.deltaTime;

             if(_weaponTimer <= 0f)
                ResetDefaultWeapon();
        }
            
        
       
    }

    public void UseWeapon()
    {
        _attualWeaponScript.Shoot();
    }

    public void RelaodWeapon()
    {
        _attualWeaponScript.Reload();
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

        _weaponTimer = _attualWeaponScript.TimeToLive;
        isNewWeaponPicked = true;
    }

    private void ResetDefaultWeapon()
    {
        Destroy(_attualWeaponGO);
        
        _attualWeaponGO = _defaultWeaponGO;
        _attualWeaponGO.SetActive(true);
        _attualWeaponScript = _attualWeaponGO.GetComponent<Weapon>();
        isNewWeaponPicked = false;

    }
  
}
