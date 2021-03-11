﻿using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform _rotator;
    [SerializeField] private WeaponSlot _weaponSlot;
    private PlayerControls _controls;
    private Vector2 _leftStickValue;
    private Vector2 _rightStickValue;
    public float speed;
    public float rotationSpeed;

    private void Awake()
    {      
        _controls = new PlayerControls();

        _controls.Controls.Move.performed += ctx => _leftStickValue = ctx.ReadValue<Vector2>();
        _controls.Controls.Move.canceled += ctx => _leftStickValue = Vector2.zero;
        
        _controls.Controls.Rotate.performed += ctx => _rightStickValue = ctx.ReadValue<Vector2>();
        //_controls.Controls.Rotate.canceled += ctx => _rightStickValue = Vector2.zero;
        
    }

    private void Update()
    {
        Vector2 movement = new Vector2(_leftStickValue.x, _leftStickValue.y) * Time.deltaTime * speed;
        transform.Translate(movement, Space.World);
        
        Vector2 rotation = new Vector2(_rightStickValue.x, _rightStickValue.y) * Time.deltaTime * rotationSpeed;
        float angle = Mathf.Atan2(_rightStickValue.x, -_rightStickValue.y) * Mathf.Rad2Deg;
        _rotator.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
    }

    private void OnTriggerEnter(Collider other) 
    {
        _weaponSlot.PickWeapon(other.gameObject); 
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