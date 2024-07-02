using UnityEngine;

public class RocketBullet : Bullet
{
    [HideInInspector] public RocketTower rocketTower;
    [HideInInspector] public GameObject tempTarget;
    private float targetAssignTimer, assignTime = 0.2f;


    protected override void Update()
    {
        targetAssignTimer += Time.deltaTime;
        if (targetAssignTimer > assignTime)
        {
            target = tempTarget;
        }

        if (target == null) return;

        base.Update();
    }

    private void OnDisable()
    {
        target = null;
        targetAssignTimer = 0;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}
