using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float lifePoints;
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Transform respawnPoint;
    private float remainingLifePoints;

    void Awake() 
    {
        remainingLifePoints = lifePoints;
    }
    
    void Update() 
    {
        if(remainingLifePoints <= 0)
            Die();
    }
    public void TakeDamage(float damage)
    {
        Debug.Log("damage recorded: "+ damage);
        remainingLifePoints -= damage;
        
        Debug.Log("life points remains: "+ remainingLifePoints);
    }

    private void Die()
    {
        //Destroy(gameObject);

        gameObject.SetActive(false);
        StartCoroutine(Respawn());
    }

    private IEnumerator Respawn()
    {
        yield return new WaitForSeconds(3f);
        Instantiate(playerPrefab, respawnPoint.position, Quaternion.identity);
    }
}
