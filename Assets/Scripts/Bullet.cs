using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed;
    public float timeToLive;
    public Rigidbody2D rb;
    private float timer;
    void Start()
    {
        rb.velocity = transform.up * bulletSpeed; 
        timer= 0f;      
    }

    void Update() 
    {
        timer += Time.deltaTime;

        if(timer >= timeToLive)
            Destroy(gameObject);
    }
    
}
