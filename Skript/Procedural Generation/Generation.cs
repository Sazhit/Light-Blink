using UnityEngine;

public class Generation : MonoBehaviour
{
    [SerializeField] private GameObject[] entitiesPrefabs;
    [SerializeField] private Vector3 spawnPosition;
    [SerializeField] private float xMargin;
    [SerializeField] private float spawnTimer;
    [SerializeField] private float spawnTimerMax = 0.5f;

    private void Update()
    {
        if (spawnTimer > 0)
        {
            spawnTimer -= Time.deltaTime;
        }
        else
        {
            spawnTimer = spawnTimerMax;
            SpawnEntity();
        }
    }

    private void SpawnEntity()
    {
        GameObject entityToSpawn = entitiesPrefabs[Random.Range(0, entitiesPrefabs.Length)];
        spawnPosition.x = Random.Range(-xMargin, xMargin);
        

        Instantiate(entityToSpawn, spawnPosition, Quaternion.identity);
    }
}
