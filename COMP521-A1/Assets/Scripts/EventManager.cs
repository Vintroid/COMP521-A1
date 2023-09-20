using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    // Audio Clips
    [SerializeField] AudioClip enemyDead;
    [SerializeField] AudioClip enemyDownWin;

    // Game Objects
    [SerializeField] Pistol pistol;
    [SerializeField] PlayerController player;
    [SerializeField] GameObject combatWall1;
    [SerializeField] GameObject combatWall2;
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject combatLine1;
    [SerializeField] GameObject combatLine2;

    // Booleans

    // keep track of if the bullet is flying or not
    public bool firing = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnemyDown()
    {
        AudioSource.PlayClipAtPoint(enemyDead,transform.position);
        player.transform.position = new Vector3(-60.0f, 0f, 35.0f);
        pistol.gameObject.SetActive(false);
        combatWall2.gameObject.SetActive(false);
        combatWall1.gameObject.SetActive(false);
        combatLine1.gameObject.SetActive(false);
        combatLine2.gameObject.SetActive(false);
        AudioSource.PlayClipAtPoint(enemyDownWin,transform.position);
        
    }

    public void CombatStart()
    {
        // Teleports player to combat area starting point
        player.transform.position = new Vector3(-10.0f, 0f, 35.0f);
        pistol.gameObject.SetActive(true);
        combatWall1.gameObject.SetActive(true);
        enemy.gameObject.SetActive(true);

    }

}
