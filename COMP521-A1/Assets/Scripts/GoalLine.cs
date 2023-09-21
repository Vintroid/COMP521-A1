using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalLine : MonoBehaviour
{
    [SerializeField] EventManager eventManager;

    // Removal of canyon path once player touches goal line.
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            eventManager.CanyonExited();
        }
    }
}
