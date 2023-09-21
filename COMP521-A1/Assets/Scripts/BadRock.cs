using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadRock : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameObject.Destroy(gameObject);
        }
    }
}
