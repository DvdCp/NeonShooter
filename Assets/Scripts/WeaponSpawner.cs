using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] weapons;
    [SerializeField] private float minTimeToSpawn, maxTimeToSpawn;
     private float _timer, randomTimeToSpawn;
    private Camera _mainCamera;
    private float _distanceFromCamera;
    
    void Start()
    {
        _mainCamera = FindObjectOfType<Camera>();
        _distanceFromCamera = Vector3.Distance(_mainCamera.transform.position, transform.position);
        
        randomTimeToSpawn = Random.Range(minTimeToSpawn, maxTimeToSpawn);

        _timer = 0f;
    }

    void Update()
    {
        _timer += Time.deltaTime;

        if(_timer > randomTimeToSpawn)
        {
            var randomIndex = Random.Range(0, weapons.Length);
            
            Vector3 pos = new Vector3(Random.value, Random.value, _distanceFromCamera);
            pos = _mainCamera.ViewportToWorldPoint(pos);
            Instantiate(weapons[randomIndex],pos,Quaternion.identity);

            randomTimeToSpawn = Random.Range(minTimeToSpawn, maxTimeToSpawn);
            
            _timer = 0f;
        }
    }
}
