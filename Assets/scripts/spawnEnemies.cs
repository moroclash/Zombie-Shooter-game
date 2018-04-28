using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;


public class spawnEnemies : MonoBehaviour {

    private GameObject Bigenemy;                // The enemy prefab to be spawned.
    private GameObject Smallenemy;
    //public float spawnTime = 3f;            // How long between each spawn.
    public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.
    public int num_Small_enimes = 0;
    public int num_Big_enimes = 0;

    void Start ()
    {
        Bigenemy = GameObject.Find("parasite");
        Smallenemy = GameObject.Find("mutant"); ;
        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        //InvokeRepeating ("Spawn", spawnTime, spawnTime);
        Spawn();
    }


    void Spawn ()
    {
        // Find a random index between zero and one less than the number of spawn points.
        int spawnPointIndex = Random.Range (0, spawnPoints.Length);
        for (int i = 0; i < num_Small_enimes; i++)
        {
            spawnPointIndex = Random.Range(0, spawnPoints.Length);
            // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
            Instantiate(Smallenemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        }

        for (int i = 0; i < num_Big_enimes; i++)
        {
            spawnPointIndex = Random.Range(0, spawnPoints.Length);
            // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
            Instantiate(Smallenemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        }
    }
}
