using System;
using System.Collections;
using UnityEngine;

public abstract class Tower : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] protected float towerRange;
    [SerializeField] protected float timeBetweenAttacks;
    protected GameObject bulletPoolParent;
    protected float lastAttackedTime = Mathf.Infinity;
    [SerializeField] protected Transform bulletSpawnTransform;
    private EnemySpawner enemySpawner;
    
    private void Start()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
    }

    private void Update()
    {
        lastAttackedTime += Time.deltaTime;

        if (timeBetweenAttacks < lastAttackedTime)
        {
            lastAttackedTime = 0;
            CalculateDistance();
        }
    }

    private void CalculateDistance()
    {
        foreach (GameObject enemy in enemySpawner.spawnedEnemies)
        {
            if (Vector3.Distance(enemy.transform.position, transform.position) < towerRange)
            {
                Shoot(enemy);
                break;
            }
        }
    }

    protected virtual void Shoot(GameObject enemy) { }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, towerRange);
    }
}
