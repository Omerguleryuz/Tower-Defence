using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Mover : MonoBehaviour
{
    private List<Transform> waypoints = new List<Transform>();
    private int currentWaypoint;
    private float speed = 5;

    private void Start()
    {
        FillWaypointsList();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 currentTarget = Vector3.MoveTowards(transform.position, waypoints[currentWaypoint].position, 
            speed * Time.deltaTime);
        transform.position = currentTarget;

        if (Vector3.Distance(waypoints[currentWaypoint].position, transform.position) < 1)
        {
            currentWaypoint++;
            if (currentWaypoint == waypoints.Count)
            {
                FindObjectOfType<EnemySpawner>().spawnedEnemies.Remove(gameObject);
                Destroy(gameObject);
                //Damage the base
            }
        }
    }

    private void FillWaypointsList()
    {
        WaypointParent waypointParent = FindObjectOfType<WaypointParent>();

        for (int i = 0; i < waypointParent.transform.childCount; i++)
        {
            waypoints.Add(waypointParent.transform.GetChild(i));
        }
    }
}
