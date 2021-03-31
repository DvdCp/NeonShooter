using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed, timeToLive;
    private float timer, damage;
    public Rigidbody rigidBody;
    public MeshRenderer meshRenderer;

    public float Damage { get => damage; set => damage = value; }

    void Start()
    {
        rigidBody.velocity = transform.up * bulletSpeed; 
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
        var target = other.GetComponent<PlayerHealth>();

        if(target != null)
        {
            target.TakeDamage(Damage);
            Destroy(gameObject);
        }
        else if( other.gameObject.tag.Equals("Shield"))
        {
            enabled = false;
            meshRenderer.enabled = false;
            Destroy(gameObject);
        }
            
    }
    
}
