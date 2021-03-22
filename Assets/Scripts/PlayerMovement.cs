using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform _rotator;
    [SerializeField] private WeaponSlot _weaponSlot;
    private Vector2 movement,rotation;
    public float speed;
    public float rotationSpeed;
    
    private void Update()
    {
        // Do movement
        //movement = movement * Time.deltaTime * speed;
        transform.Translate(movement * Time.deltaTime * speed, Space.World);

        //Look around 
        float angle = Mathf.Atan2(rotation.x, -rotation.y) * Mathf.Rad2Deg;
        _rotator.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
    }

    private void OnTriggerEnter(Collider other) 
    {
        _weaponSlot.PickWeapon(other.gameObject); 
    }

    public void Move (InputAction.CallbackContext ctx)
    {
        var vectorRead = ctx.ReadValue<Vector2>();
        movement = new Vector2(vectorRead.x, vectorRead.y);
    }

    public void Look (InputAction.CallbackContext ctx)
    {
        var vectorRead = ctx.ReadValue<Vector2>();
        rotation = new Vector2(vectorRead.x, vectorRead.y);
        
    }
    
}
