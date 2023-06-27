using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField] public float maxHealth = 100f;
    private float currentHealth;


    private void Start()
    {
        currentHealth = maxHealth;  // Initialize current health to maximum health
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            DestroyBox();
        }
    }

}
