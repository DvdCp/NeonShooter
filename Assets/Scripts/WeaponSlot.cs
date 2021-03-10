using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSlot : MonoBehaviour
{
    private GameObject _attualWeapon;

    private void Awake() 
    {
        _attualWeapon = GetComponentInChildren<Weapon>().gameObject;
    }

    public void PickWeapon(GameObject newWeapon, out Weapon _playerWeapon)
    {
        _attualWeapon.SetActive(false);
        _attualWeapon.GetComponent<Weapon>().enabled = false;

        newWeapon.transform.parent = transform;
        newWeapon.transform.position = transform.position;
        newWeapon.transform.rotation = transform.rotation;

        newWeapon.SetActive(true);
        newWeapon.GetComponent<Weapon>().enabled = true;
        
        _playerWeapon = newWeapon.GetComponent<Weapon>();

    }

}
