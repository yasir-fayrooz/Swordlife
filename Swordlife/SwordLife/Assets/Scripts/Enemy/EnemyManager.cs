using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public PlayerHealth playerHealth;       // Reference to the player's heatlh.
    public GameObject[] enemies;                // The enemy prefab to be spawned.
    public float spawnTime = 7f;            // How long between each spawn.
    public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.
    public bool spawnSide;
    void Start()
    {
        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }


    void Spawn()
    {
        // If the player has no health left...
        if (playerHealth.currentHealth <= 0f)
        {
            // ... exit the function.
            return;
        }

        // Find a random index between zero and one less than the number of spawn points.
        int EnemyType = Random.Range(0, enemies.Length);


        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.

        if (EnemyType == 0) //Saw
        {
            int SawSpawnPointIndex = Random.Range(0, 2);
            if (SawSpawnPointIndex == 0)
            {
                spawnSide = true;
            }
            else if (SawSpawnPointIndex == 1)
            {
                spawnSide = false;
            }
            Instantiate(enemies[EnemyType], spawnPoints[SawSpawnPointIndex].position, spawnPoints[SawSpawnPointIndex].rotation);
        }


        if (EnemyType == 1) //Drone
        {
            int DroneSpawnPointIndex = Random.Range(2, 4);
            if (DroneSpawnPointIndex == 2)
            {
                spawnSide = true;
            }
            else if (DroneSpawnPointIndex == 3)
            {
                spawnSide = false;
            }
            Instantiate(enemies[EnemyType], spawnPoints[DroneSpawnPointIndex].position, spawnPoints[DroneSpawnPointIndex].rotation);
        }

        if (EnemyType == 2) //Laser
        {
            int LaserSpawnPointIndex = Random.Range(4, 6);
            if (LaserSpawnPointIndex == 4)
            {
                spawnSide = true;
            }
            else if (LaserSpawnPointIndex == 5)
            {
                spawnSide = false;
            }
            Instantiate(enemies[EnemyType], spawnPoints[LaserSpawnPointIndex].position, spawnPoints[LaserSpawnPointIndex].rotation);
        }
    }
}