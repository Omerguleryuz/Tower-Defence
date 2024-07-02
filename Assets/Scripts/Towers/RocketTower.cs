using UnityEngine;
using Random = UnityEngine.Random;

public class RocketTower : Tower
{
    private int launchPower = 4;
    private Vector3 launchDirection;

    protected override void Shoot(GameObject enemy)
    {
        BulletPool bulletPool = FindObjectOfType<BulletPool>();
        GameObject bulletInstance = bulletPool.GetBullet(0);

        //Launch bullet to air
        SetLaunchTransform(bulletInstance);

        bulletInstance.GetComponent<Rigidbody>().AddForce(GetLaunchPower(), ForceMode.Impulse);
        bulletInstance.transform.rotation = Quaternion.LookRotation(launchDirection);
        bulletInstance.GetComponent<RocketBullet>().tempTarget = enemy;
        bulletInstance.GetComponent<RocketBullet>().rocketTower = this;
    }

    private Vector3 GetLaunchDirection()
    {
        float xDirection = Random.Range(-0.6f, 0.6f);
        float yDirection = 1.5f;
        float zDirection = Random.Range(-0.6f, 0.6f);

        launchDirection = new Vector3(xDirection, yDirection, zDirection);
        return launchDirection;
    }

    private Vector3 GetLaunchPower()
    {
        launchDirection = GetLaunchDirection();
        launchDirection *= launchPower;
        return launchDirection;
    }

    private void SetLaunchTransform(GameObject bulletInstance)
    {
        bulletInstance.transform.position = bulletSpawnTransform.position;
        bulletInstance.transform.eulerAngles = new Vector3(-90, 0, 0);
    }
}
