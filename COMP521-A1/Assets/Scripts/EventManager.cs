using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    // Audio Clips

    // Game Objects

    // Game Fields
    public float timer = 0f;
    public int difficulty = 0;
    public float waveTimer = 0;
    public float waveRate = 8f;
    public int powerupRate = 2;
    public int weaponRate = 2;

    // Enemy fields
    public float wrenchSpawnTimer = 3.33f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Updating fields with current game time
        timer += Time.DeltaTime;
        waveTimer += Time.DeltaTime;
        difficulty = timer/15;
        waveRate = 1 + (7 - difficulty);

        WaveSelector();

        // Looking if an enemy should be spawned
        if(enemyTimer >= enemySpawnTimer){
            // Getting a random movement type integer
            int mvmtType = Random.NextInt(0,2);
            enemyTimer = 0f;
            
        }
    }

    public void EnemyDown()
    {
        // Enemies can drop weapons
        int randomIntWpn = Random.NextInt(1,11);

        // Weapons roll first
        if(randomIntWpn <= weaponRate)
        {
            // Spawn weapon
        }

        // Enemies can spawn powerups
        else{
            int randomIntPwrUp = Random.NextInt(1,11);

            // Powerup roll 
            if(randomIntPwrUp <= powerupRate){
                // Spawn powerup
            }
            
        }
    }

    
    private String WaveSelector(){
        string waveType;
        int rng = Random.NextInt(0,100);

        // Defining wave odds
        waveType = "wrench";

        return waveType;
    }

    
}
