using System.Collections;
using UnityEngine;

public class WeaponSlot : MonoBehaviour
{
    [SerializeField] private GameObject _defaultWeaponGO;
    private GameObject _attualWeaponGO;
    private float _weaponTimer;
    private bool isPicked;

    private void Awake() 
    {
        // Default weapon at beginning 
        _attualWeaponGO = _defaultWeaponGO;
        isPicked = false;
    }

    private Update() 
    {
        if(isPicked)
            _weaponTimer -= Time.deltaTime;

        if(_weaponTimer <= 0f)
            ResetDefaultWeapon();

    }

    public void PickWeapon(GameObject newWeaponGO, out Weapon _playerWeapon)
    {
        var attualWeaponScript = _attualWeaponGO.GetComponent<Weapon>();

        if(attualWeaponScript.IsDefaultWeapon)
        {
            _attualWeaponGO.SetActive(false);
            attualWeaponScript.enabled = false;
        }
        else
        {
            Destroy(_attualWeaponGO);
        }
        
        newWeaponGO.transform.parent = transform;
        newWeaponGO.transform.position = transform.position;
        newWeaponGO.transform.rotation = transform.rotation;

        newWeaponGO.SetActive(true);
        newWeaponGO.GetComponent<Weapon>().enabled = true;

        _attualWeaponGO = newWeaponGO;
        _playerWeapon = _attualWeaponGO.GetComponent<Weapon>();

        isPicked = true;
        _weaponTimer = _playerWeapon.TimeToLive;


    }
  
}
