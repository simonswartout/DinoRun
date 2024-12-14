using UnityEngine;

public class PlantSpawnManager : MonoBehaviour
{
    [Header("Plant Spawning Settings")]
    public GameObject plantPrefab; // Assign the plant prefab in the Inspector
    public int numberOfPlants = 10; // Total number of plants to spawn
    public Vector3 spawnAreaSize = new Vector3(10f, 0f, 10f); // Size of the spawn area
    public Transform spawnAreaCenter; // Center of the spawn area

    [Header("Spawn Timing (Optional)")]
    public bool spawnOverTime = false; // Spawn continuously over time
    public float spawnInterval = 1f; // Interval between spawns if spawnOverTime is true

    private int spawnedPlantsCount = 0;

    private void Start()
    {
        if (!spawnOverTime)
        {
            SpawnAllPlants();
        }
        else
        {
            StartCoroutine(SpawnPlantsOverTime());
        }
    }

    private void SpawnAllPlants()
    {
        for (int i = 0; i < numberOfPlants; i++)
        {
            SpawnPlant();
        }
    }

    private System.Collections.IEnumerator SpawnPlantsOverTime()
    {
        while (spawnedPlantsCount < numberOfPlants)
        {
            SpawnPlant();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnPlant()
    {
        if (plantPrefab == null)
        {
            Debug.LogWarning("Plant prefab not assigned!");
            return;
        }

        Vector3 randomPosition = GetRandomPositionWithinBounds();
        Instantiate(plantPrefab, randomPosition, Quaternion.identity);
        spawnedPlantsCount++;
    }

    private Vector3 GetRandomPositionWithinBounds()
    {
        Vector3 offset = new Vector3(
            Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2),
            Random.Range(-spawnAreaSize.y / 2, spawnAreaSize.y / 2),
            Random.Range(-spawnAreaSize.z / 2, spawnAreaSize.z / 2)
        );

        return spawnAreaCenter != null ? spawnAreaCenter.position + offset : offset;
    }

    private void OnDrawGizmosSelected()
    {
        // Visualize the spawn area in the Scene view
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(spawnAreaCenter != null ? spawnAreaCenter.position : Vector3.zero, spawnAreaSize);
    }
}

