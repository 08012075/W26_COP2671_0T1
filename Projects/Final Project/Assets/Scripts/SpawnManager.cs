using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour
{
    // Variables
    public GameObject enemyPrefab;
    public GameObject currentTimeline;
    private float spawnRange = 9.0f;
    public int enemyCount;
    public int waveNumber = 2;
    private float platformX = -1.3706f;
    private float platformZ = -4.565f;
    private bool isEnemySpawn;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        
        // Starts coroutine
        isEnemySpawn = true;
        StartCoroutine(EnemySpawnCountdownRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Coroutine for enemy spawn countdown
    IEnumerator EnemySpawnCountdownRoutine()
    {
        // While loop for enemy spawning
        while (isEnemySpawn)
        {
            // So only enemys with tag enemy are spawned randomly
            enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

            if (enemyCount == 0)
            {
                yield return new WaitForSeconds(3);
                SpawnEnemyWave(waveNumber);
            }
            // If there still are enemies
            yield return null;
        }
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation, currentTimeline.transform);
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        // Adds platform postion
        spawnPosX += platformX;
        spawnPosZ += platformZ;

        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);

        return randomPos;
    }
}
