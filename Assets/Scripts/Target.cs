using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Target Class is added to any object that could be hit by a waterball
/// </summary>
public class Target : MonoBehaviour
{
    [SerializeField] private float health = 50f;

    /// <summary>
    /// Performs damage on the target object
    /// </summary>
    /// <param name="damageAmount">Amount of damage the waterball does on the target object</param>
    public void Damage(float damageAmount)
    {
        //checks that the damage input is not a negative number
        if (damageAmount <= 0f)
        {
            Debug.Log("Invalid damage amount: " + damageAmount);
            return;
        }

        //removes the damage from the health
        health -= damageAmount;

        //destroys object if health is below zero
        if (health <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
