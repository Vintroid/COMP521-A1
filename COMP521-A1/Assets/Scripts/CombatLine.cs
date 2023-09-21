using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatLine : MonoBehaviour
{
    [SerializeField] public EventManager eventManager;

    // Looking if the CombatLine touches player
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Player")
        {
            eventManager.CombatStart();
        }
    }
}
