using UnityEngine;

public class RespawnSystem : MonoBehaviour
{
    [SerializeField] private RectTransform[] respawnAreas;

    public void DieAndRespawn(GameObject playerToRespawn)
    {
        //Diying
         playerToRespawn.SetActive(false);

        //Respawing
        playerToRespawn.GetComponent<PlayerHealth>().ResetHealth();

        RectTransform randomRespawnArea = respawnAreas[ Random.Range(0, respawnAreas.Length) ];

        Vector3 randomPositionInsideRespawnArea = new Vector3(  Random.Range(randomRespawnArea.rect.xMin, randomRespawnArea.rect.xMax),
                                                                Random.Range(randomRespawnArea.rect.yMin, randomRespawnArea.rect.yMax),
                                                                0f) + randomRespawnArea.position;

        playerToRespawn.transform.position = randomPositionInsideRespawnArea;
        playerToRespawn.SetActive(true);
    }


}
