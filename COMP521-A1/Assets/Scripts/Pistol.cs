using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    // Audio Clips
    [SerializeField] AudioClip shot;

    // GameObjects
    [SerializeField] EventManager eventManager;

    // Prefabs
    [SerializeField] Bullet bullet;

    // We want to shoot copies of the bullet 
    public Bullet bulletCopy;

    // Bullet cooldown on top of collision check to avoid bullet spam
    float bulletTime = 0f;
    [SerializeField] float cooldown;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Keep looking if player inputted a gunshot.
        Shooting(); 
    }

    void Shooting()
    {
        // Did player input left mouse click?
        bool shooting = Input.GetMouseButton(0);

        // We also check the game time for cooldown
        if(shooting && eventManager.firing.Equals(false) && bulletTime < Time.time)
        {   
            // If no bullet is currently flying, fires bullet;
            AudioSource.PlayClipAtPoint(shot,transform.position, 0.1f);

            // Bullet is now considered 
            eventManager.firing = true;

            // Setting bullet trajectory
            CreateNewBullet(bullet);

            // Adding cooldown
            bulletTime = Time.time + cooldown;
        }
    }

    // We are shooting a new copy of the bullet forward from the player.
    public void CreateNewBullet(Bullet bullet)
    {
        bulletCopy = Instantiate(bullet, transform.position + new Vector3(0f,0.4f,0f), transform.rotation);

        //Setting eventManager as a variable on startup
        bulletCopy.eventManager = eventManager;
        bulletCopy.bulletShell.velocity = transform.TransformDirection(Vector3.forward * bulletCopy.speed);
    }
}
