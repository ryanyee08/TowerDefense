using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*<Summary>
 * The Enemy spawner sends out enemies from a fixed spawn postion
 * Enemie objects are loaded into an array and on a fixed interval are deployed
 * </Summary>
 * 
 */
public class EnemySpawner : MonoBehaviour
{   
    // Stores all the enemies to be deployed
    [SerializeField] GameObject[] enemyPool;
    
    // Tracks the progress of moving through the array of Enemy Objects
    [SerializeField] int enemyPoolIndex = 0;

    // Defines the timing and frequency of enemy spawn
    [SerializeField] float startSpawnDelay = 1.0f;
    [SerializeField] float spawnInterval = 1.5f;

    private Vector3 spawnPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        // Set the spawn position to be the location of the enemy spawner object
        spawnPosition = this.transform.position;
        
        // At the start of the scene initiates the spawning of enemies from the enemy pool
        InvokeRepeating("SpawnEnemy", startSpawnDelay, spawnInterval);
    }


    private void SpawnEnemy()
    {
        // Instantiate the next enemy in the pool
        GameObject spawnedEnemy = Instantiate(enemyPool[enemyPoolIndex], spawnPosition, transform.rotation);
            
        // Advance the enemy pool Index by 1
        enemyPoolIndex++;

        // Check to see if the pool has been fully used
        if (enemyPoolIndex == enemyPool.Length)
        {
            // If we have cycled through the full pool then we will stop the InvokeRepeating that is spawning enemies
            CancelInvoke();
        }
    }
}
