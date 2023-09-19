using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Speed of bullet through the map
    [SerializeField] float speed = 10f;
    [SerializeField] EventManager eventManager;
    [SerializeField] Pistol pistol;

    // Manages how bullet will fly.
    private void Update()
    {
        if (eventManager.firing.Equals(true))
        {
            transform.position += new Vector3(speed * Time.deltaTime, speed * Time.deltaTime, speed * Time.deltaTime);
        }
    }

    // Bullet disappears on hit and destroys enemy on hit.
    void OnCollisionEnter(Collision collision)
    {
        Damageable damageable = GetComponent<Damageable>();
        if (damageable)
        {
            damageable.Hit();
        }

        // Warn EventManager that bullet is no longer flying
        eventManager.CreateNewBullet();
        GameObject.Destroy(gameObject);
    }
 
 }
