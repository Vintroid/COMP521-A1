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

        else{

        }
    }

    public void CombatStart()
    {
        // Teleports player to combat area starting point
        player.transform.position = new Vector3(-10.0f, 0f, 35.0f);
        pistol.gameObject.SetActive(true);
        combatWall1.gameObject.SetActive(true);
        enemy.gameObject.SetActive(true);
        

    }

    // Combat Area can no longer be reached
    public void CanyonEntered()
    {
        combatWall2.gameObject.SetActive(true);
        combatLine2.gameObject.SetActive(true);
    }

    // Removing canyon path once arrived in goal area
    public void CanyonExited()
    {
        GameObject[] path = GameObject.FindGameObjectsWithTag("Canyon");
        foreach(GameObject obj in path)
        {
            Destroy(obj);
        }
    }
}
