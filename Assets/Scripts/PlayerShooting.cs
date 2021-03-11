using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
     [SerializeField] private WeaponSlot _weaponSlot;
     private PlayerControls _controls;

    // Start is called before the first frame update
    void Awake()
    {   
        _controls = new PlayerControls();

        _controls.Controls.Shoot.started += ctx => Shoot();
        _controls.Controls.Reload.started += ctx => Reload();
    }

    private void Shoot()
    {
        _weaponSlot.UseWeapon();
    }

    private void Reload()
    {
       _weaponSlot.RelaodWeapon(); 
    }

    private void OnEnable()
    {
        _controls.Controls.Enable();
    }

    private void OnDisable()
    {
        _controls.Controls.Disable();
    }
}
