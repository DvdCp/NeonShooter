using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed, timeToLive;
    private float timer, damage;
    public Rigidbody rb;

    public float Damage { get => damage; set => damage = value; }

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

    private void OnTriggerEnter(Collider other) 
    {
        var enemyPlayer = other.GetComponent<PlayerHealth>();

        if(enemyPlayer != null)
        {
            enemyPlayer.TakeDamage(Damage);
            Destroy(gameObject);
        }
    }
    
}
