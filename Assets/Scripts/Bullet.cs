using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed;
    public Rigidbody2D rb;
    void Start()
    {
        Debug.Log("Transform.up:"+transform.up);
        rb.velocity = transform.up * bulletSpeed;
        
        
    }
    
}
