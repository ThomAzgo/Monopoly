using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowThePath : MonoBehaviour
{
    public Transform[] waypoints;

    [SerializeField]
    private float moveSpeed = 1f;

    [HideInInspector]
    public int waypointIndex;

    public bool moveAllowed = false;

    // Start is called before the first frame update
    private void Start()
    {
        transform.position = waypoints[waypointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveAllowed)
            Move();
    }

    private void Move()
    {
        if (waypointIndex >= waypoints.Length) return;
        
        Transform waypoint = waypoints[waypointIndex];

        transform.position = Vector2.MoveTowards(transform.position,
        waypoint.transform.position,
        moveSpeed * Time.deltaTime);

        if (transform.position == waypoint.transform.position) waypointIndex ++;
        
    }
}
