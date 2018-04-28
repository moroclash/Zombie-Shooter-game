using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enamiesProperties : MonoBehaviour {
    public float health = 100f;
    public float impact = 20f;
    public int score = 10;
    public int coin = 5;
    public playerPropertice player;

    public int waitedTimeToDestroyEnime = 5; 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Shoot(float ShooterImpact)
    {
        health -= ShooterImpact;
        if (health <= 0)
        {
            player.updatePlayerScore(score);
            player.AddPlayerCoin(coin);
            Invoke("Died",7);
        }
    }

    private int counter = 0;
    public void Died()
    {
        Destroy(gameObject);
    }
}
