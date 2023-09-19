using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    // We want to access Enemy class' methods.
    [field: SerializeField, HideInInspector]
    public Enemy enemy{ get; set; }
    // Method to call when hit with a bullet.
    public void Hit()
    {
        enemy.OnDestroyed();
    }
}
