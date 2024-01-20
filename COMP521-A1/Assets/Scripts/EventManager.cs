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
    public int powerupRate = 2;
    public int weaponRate = 2;
    public float enemyRate = 0.20f;

    // keep track of if the bullet is flying or not
    public bool firing = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.DeltaTime;
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
