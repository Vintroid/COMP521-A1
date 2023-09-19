using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    // Audio Clips
    [SerializeField] AudioClip shot;
    [SerializeField] EventManager eventManager;

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

        if(shooting && eventManager.firing.Equals(false))
        {   
            // If no bullet is currently flying, fires bullet;
            AudioSource.PlayClipAtPoint(shot,transform.position, 0.3f);

            // Bullet is now considered 
            eventManager.firing = true;
        }
    }
}
