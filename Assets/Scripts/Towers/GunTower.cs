using UnityEngine;

public class GunTower : Tower
{
    protected override void Shoot(GameObject enemy)
    {
        BulletPool bulletPool = FindObjectOfType<BulletPool>();
        GameObject bulletInstance = bulletPool.GetBullet(1);
        bulletInstance.transform.position = bulletSpawnTransform.position;
        bulletInstance.transform.rotation = Quaternion.LookRotation(enemy.transform.position);
        bulletInstance.GetComponent<Bullet>().target = enemy;
    }
}
