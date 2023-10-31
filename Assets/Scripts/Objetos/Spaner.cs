using System.Collections;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject prefabToSpawn; // O prefab que você deseja spawnar
    public BoxCollider spawnArea;    // O BoxCollider que define a área de spawn

    private bool canSpawn = true;
    private Transform spawnParent; // Referência ao objeto pai para verificar se já há objetos filhos

    private void Start()
    {
        spawnParent = transform; // Defina o objeto pai como o objeto atual (onde este script está anexado)
        StartCoroutine(SpawnPrefabPeriodically());
    }

    private IEnumerator SpawnPrefabPeriodically()
    {
        while (true)
        {
            if (canSpawn)
            {
                if (HasNoChildren())
                {
                    Vector3 randomSpawnPoint = GetRandomSpawnPoint();
                    Instantiate(prefabToSpawn, randomSpawnPoint, Quaternion.identity, spawnParent);
                    canSpawn = false;
                    yield return new WaitForSeconds(20f);
                    canSpawn = true;
                }
            }
            yield return null;
        }
    }

    private Vector3 GetRandomSpawnPoint()
    {
        Vector3 min = spawnArea.bounds.min;
        Vector3 max = spawnArea.bounds.max;

        float x = Random.Range(min.x, max.x);
        float y = Random.Range(min.y, max.y);
        float z = Random.Range(min.z, max.z);

        return new Vector3(x, y, z);
    }

    private bool HasNoChildren()
    {
        // Verifique se o objeto pai não tem filhos
        return spawnParent.childCount == 0;
    }
}
