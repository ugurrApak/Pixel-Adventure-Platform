using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] List<Transform> waypoints;
    int currentWaypointIndex = 0;
    float speed = 2.3f;
    private void Update()
    {
        if (Vector2.Distance(waypoints[currentWaypointIndex].position,transform.position) < .1f)
        {
            currentWaypointIndex++;
            transform.localScale = new Vector3(transform.localScale.x * -1,transform.localScale.y,transform.localScale.z);
            if(currentWaypointIndex >= waypoints.Count)
            {
                currentWaypointIndex= 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].position, speed * Time.deltaTime);
    }
}
