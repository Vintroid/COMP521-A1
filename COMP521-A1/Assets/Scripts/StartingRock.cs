using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingRock : MonoBehaviour
{
    [SerializeField] EventManager eventManager;

    // To avoid the starting rock to keep checking calling CanyonEntered on contact with player.
    bool activated = false;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player" && !activated)
        {
            eventManager.CanyonEntered();
            activated = true;
        }
    }
}
