using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private GameObject[] bulletPoolPrefabs;
    public GameObject[] bulletPrefabs;
    public int[] poolSizes;
    private List<GameObject>[] bulletPools;


    void Start()
    {
        CreatePools();
    }

    private void CreatePools()
    {
        bulletPools = new List<GameObject>[bulletPrefabs.Length];

        for (int i = 0; i < bulletPrefabs.Length; i++)
        {
            bulletPools[i] = new List<GameObject>();

            for (int j = 0; j < poolSizes[i]; j++)
            {
                GameObject bullet = Instantiate(bulletPrefabs[i], transform);
                bullet.SetActive(false);
                bulletPools[i].Add(bullet);
            }
        }
    }

    public GameObject GetBullet(int bulletType)
    {
        foreach (GameObject bullet in bulletPools[bulletType])
        {
            if (!bullet.activeInHierarchy)
            {
                bullet.SetActive(true);
                return bullet;
            }
        }

        GameObject newBullet = Instantiate(bulletPrefabs[bulletType]);
        bulletPools[bulletType].Add(newBullet);
        return newBullet;
    }

    public void ReturnBullet(GameObject bullet, int bulletType)
    {
        bullet.SetActive(false);
    }
}
