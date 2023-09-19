using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Speed of bullet through the map
    [SerializeField] public float speed = 10f;
    [SerializeField] public EventManager eventManager;

    // Rigid body
    [SerializeField] public Rigidbody bulletShell;


    // Bullet disappears on hit and destroys enemy on hit.
    void OnCollisionEnter(Collision collision)
    {
        Damageable damageable = collision.gameObject.GetComponent<Damageable>();
        if (damageable)
        {
            damageable.Hit();
        }

        // Warn EventManager that bullet is no longer flying
        eventManager.firing = false;
        GameObject.Destroy(gameObject);
    }
 }
