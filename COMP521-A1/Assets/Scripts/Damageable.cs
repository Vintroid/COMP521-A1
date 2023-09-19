using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    // We want to access Enemy class' methods.
    [SerializeField] Enemy enemy;

    // Method to call when hit with a bullet.
    public void Hit()
    {
        enemy.OnDestroyed();
    }
}
