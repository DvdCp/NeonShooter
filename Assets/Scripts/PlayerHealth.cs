using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float lifePoints;
    
    void Update() 
    {
        if(lifePoints <= 0)
            Die();
    }
    public void TakeDamage(float damage)
    {
        Debug.Log("damage recorded: "+ damage);
        lifePoints -= damage;
        
        Debug.Log("life points remains: "+lifePoints);
    }

    private void Die()
    {
        Destroy(gameObject);
    }

}
