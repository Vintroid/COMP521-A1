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
    public float enemyTimer = 0f;
    public int powerupRate = 2;
    public int weaponRate = 2;
    public float enemySpawnTimer = 3.33f;

    // keep track of if the bullet is flying or not
    public bool firing = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Updating timers with current game time
        timer += Time.DeltaTime;
        enemyTimer += Time.DeltaTime;

        // Changing enemy spawn timer depending on game timer
        enemySpawnTimer = 0.33 + (3 - (timer/30);

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

    
}
