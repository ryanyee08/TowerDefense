using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/* ================
 * Enemy Movement
 * ================
 * <Summary>
 * This script handles the movement of the enemy objects.
 * When the enemy is spawned it will load navigational data from a level manager
 * Then it will proceed to follow the waypoints all the way to the goal
 * </Summary>
 */
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] LevelManager LevelManager;
    [SerializeField] int EnemyMovementSpeed = 1;
    private int waypointIndex = 0;

    private void Awake()
    {
        LevelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
    }

    private void Update()
    {
        // Move the enemy towards the currently targeted waypoint every frame
        transform.position = Vector3.MoveTowards(transform.position, LevelManager.waypoints[waypointIndex].position, EnemyMovementSpeed * Time.deltaTime);
        
        // Check to see if the object has reached a waypoint
        if (transform.position == LevelManager.waypoints[waypointIndex].position)
        {
            // If this is the final waypoint then destroy the object
            if (waypointIndex == LevelManager.waypoints.Length - 1)
            { 
                Destroy(gameObject);
            }

            // If it is not the final waypoint go to the next one
            waypointIndex++;
        }
    }
}
