using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public Wave[] waves;
    public int currentWave;
    public int leftEnemiesInCurrentWave;

    private void Start()
    {
        GetTotalEnemiesInCurrentWave();
    }

    private void Update()
    {
        if (leftEnemiesInCurrentWave == 0)
        {
            if (currentWave < waves.Length)
                currentWave++;

            GetTotalEnemiesInCurrentWave();
            StartCoroutine(FindObjectOfType<EnemySpawner>().SpawnEnemies());
        }
    }

    private void GetTotalEnemiesInCurrentWave()
    {
        for (int k = 0; k < waves[currentWave].enemyCounts.Length; k++)
        {
            leftEnemiesInCurrentWave += waves[currentWave].enemyCounts[k];
        }
    }
}
