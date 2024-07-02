using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] Image healthBar;
    [SerializeField] Transform healthBarParent;
    [SerializeField] private float health;
    private float fullHealth;
    private int valueOfEnemy = 10;

    private void Start()
    {
        fullHealth = health;
    }

    private void Update()
    {
        healthBarParent.LookAt(Camera.main.transform);
        healthBarParent.transform.eulerAngles = new Vector3
        (
            healthBarParent.transform.eulerAngles.x,
            0,
            0
        );
    }

    public void LoseHealth(int damage)
    {
        health = Mathf.Max(health - damage, 0);
        UpdateHealthBar();

        if (health == 0)
        {
            Die();
        }
    }

    public void Die()
    {
        gameObject.SetActive(false);
        FindObjectOfType<EnemySpawner>().spawnedEnemies.Remove(gameObject);

        FindObjectOfType<GoldManager>().EarnGold(valueOfEnemy);
        FindObjectOfType<UIManager>().PrintGold();

        WaveManager waveManager = FindObjectOfType<WaveManager>();
        waveManager.leftEnemiesInCurrentWave--;
    }

    private void UpdateHealthBar()
    {
        healthBar.fillAmount = health / fullHealth;
    }
}
