using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [HideInInspector] public List<GameObject> spawnedEnemies;
    [SerializeField] private GameObject[] enemyPrefab;
    [SerializeField] private Transform spawnPosition;

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    public IEnumerator SpawnEnemies()
    {
        WaveManager waveManager = FindObjectOfType<WaveManager>();
        Wave wave = waveManager.waves[waveManager.currentWave];
        enemyPrefab = wave.enemyPrefabs;

        for (int i = 0; i < enemyPrefab.Length; i++)
        {
            for (int k = 0; k < wave.enemyCounts[i]; k++)
            {
                GameObject instance = Instantiate(enemyPrefab[i], spawnPosition.position, Quaternion.identity, transform);
                spawnedEnemies.Add(instance);
                yield return new WaitForSeconds(1f);
            }
        }
    }
}
