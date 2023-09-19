using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // We want access to the eventManager functions from this class.
    [SerializeField] EventManager eventManager;

    // Enemy body
    [SerializeField] GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Behaviour when the enemy is destroyed
    public void OnDestroyed()
    {
        eventManager.EnemyDown();
        GameObject.Destroy(enemy);
    }
}
