using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    // Audio Clips
    [SerializeField] AudioClip enemyDead;

    // Game Objects
    [SerializeField] Bullet bullet;

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

    public void EnemyDown(Enemy enemy)
    {
        AudioSource.PlayClipAtPoint(enemyDead,transform.position);
    }

    public void CreateNewBullet()
    {
        GameObject.Instantiate(bullet, bullet.transform.position, bullet.transform.rotation);
        firing = false;
    }
}
