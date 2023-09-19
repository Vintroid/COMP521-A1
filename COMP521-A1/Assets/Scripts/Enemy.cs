using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // We want access to the eventManager functions from this class.
    [field: SerializeField, HideInInspector] 
    public EventManager eventManager { get; set; }

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
        eventManager.EnemyDown(this);
        GameObject.Destroy(gameObject);
    }
}
