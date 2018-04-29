using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;


public class spawnEnemies : MonoBehaviour {

    public GameObject Bigenemy;                // The enemy prefab to be spawned.
    public GameObject Smallenemy;
    //public float spawnTime = 3f;            // How long between each spawn.
    private List<Vector3> spawnPoints;         // An array of the spawn points this enemy can spawn from.
    public int num_Small_enimes = 0;
    public int num_Big_enimes = 0;

    void Start ()
    {
        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        //InvokeRepeating ("Spawn", spawnTime, spawnTime);
        spawnPoints = new List<Vector3>();
        for (int i = 0; i < num_Big_enimes + num_Small_enimes; i++)
        {
            int x = Random.Range(-30, 30);
            int y = 0;
            int z = Random.Range(-50, -80);
            Vector3 vec = new Vector3(x, y, z);
            spawnPoints.Add(vec);
        }
        Spawn();
    }


    void Spawn ()
    {
        // Find a random index between zero and one less than the number of spawn points.
        int spawnPointIndex = Random.Range(0, spawnPoints.Count);
        for (int i = 0; i < num_Small_enimes; i++)
        {
            spawnPointIndex = Random.Range(0, spawnPoints.Count);
            // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
            Instantiate(Smallenemy, spawnPoints[spawnPointIndex], new Quaternion(0, 0, 0, 0));
        }

        for (int i = 0; i < num_Big_enimes; i++)
        {
            spawnPointIndex = Random.Range(0, spawnPoints.Count);
            // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
            Instantiate(Bigenemy, spawnPoints[spawnPointIndex], new Quaternion(0, 0, 0, 0));
        }
    }
}
