using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float lifePoints;
    [SerializeField] private RespawnSystem respawnSystem;
    private float remainingLifePoints;

    void Awake() 
    {
        ResetHealth();
    }
    
    public void TakeDamage(float damage)
    {
        remainingLifePoints -= damage;
        
        if(remainingLifePoints <= 0)
            respawnSystem.DieAndRespawn(gameObject);    
    }

    public void ResetHealth()
    {
        remainingLifePoints = lifePoints;
    }
}
