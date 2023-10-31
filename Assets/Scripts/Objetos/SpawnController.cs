using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public BoxCollider spawnArea;
    public float spawnInterval = 20.0f;

    private float timeSinceLastSpawn = 0.0f;

    private void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= spawnInterval)
        {
            SpawnPrefab();
            timeSinceLastSpawn = 0.0f;
        }
    }

    private void SpawnPrefab()
    {
        Vector3 randomPosition = GetRandomSpawnPosition();

        // Check if there are no objects within the BoxCollider
        Collider[] colliders = Physics.OverlapBox(randomPosition, spawnArea.size / 2);

        if (colliders.Length == 0)
        {
            Instantiate(prefabToSpawn, randomPosition, Quaternion.identity);
        }
    }

    private Vector3 GetRandomSpawnPosition()
    {
        Vector3 center = spawnArea.transform.position + spawnArea.center;
        Vector3 size = spawnArea.size / 2;

        float randomX = Random.Range(-size.x, size.x);
        float randomY = Random.Range(-size.y, size.y);
        float randomZ = Random.Range(-size.z, size.z);

        return center + new Vector3(randomX, randomY, randomZ);
    }
}
