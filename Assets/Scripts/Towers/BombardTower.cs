using UnityEngine;

public class BombardTower : Tower
{
    protected override void Shoot(GameObject enemy)
    {
        BulletPool bulletPool = FindObjectOfType<BulletPool>();
        GameObject bulletInstance = bulletPool.GetBullet(2);

        bulletInstance.transform.position = bulletSpawnTransform.position;
        bulletInstance.GetComponent<Rigidbody>().velocity = GetShootVelocity(enemy.transform.position, transform.position, 1f);
    }

    private Vector3 GetShootVelocity(Vector3 target, Vector3 origin, float time)
    {
        Vector3 distance = target - origin;

        Vector3 distanceXZ = distance;
        distanceXZ.y = 0;

        float XZ = distance.magnitude;
        float Y = distance.y;

        float Vxz = XZ / time;
        float Vy0 = Y / time + 1 / 2 * Mathf.Abs(Physics.gravity.y) * time;

        Vector3 shootVelocity = distanceXZ.normalized;

        shootVelocity *= Vxz;
        shootVelocity.y = Vy0;

        return shootVelocity;
    }
}
