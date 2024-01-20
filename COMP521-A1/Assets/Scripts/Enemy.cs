using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // We want access to the GameManager functions from this class.
    [SerializeField] GameManager gameManager;

    // Enemy body
    [SerializeField] RigidBody rb;

    // Enemy health
    private int health = 2;
    
    // Movement type
    int movementType = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = new Vector2(-1f,0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Behaviour when the enemy is hit
    public void OnHit()
    {
       if(health>=0){
           health--;
       }
       else
       {
           OnDestroyed();
       }
    }

    // Behaviour when the enemy is destroyed
    private void OnDestroyed()
    {
        gameManager.EnemyDown(this);
        GameObject.Destroy(this);
    }

    private void OnCollisionEnter(Collision collision){
        if(Collision.Collider.gameObject.Layer = "EnemyWall")
        {
            GameObject.Destroy(this);
        }
    }
}
