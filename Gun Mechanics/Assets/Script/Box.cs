using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Box : MonoBehaviour
{
    [SerializeField] public float maxHealth = 100f;
    private float currentHealth;

    public Slider healthBar;

    public void Update()
    {
        healthBar.value = currentHealth;
    }


    private void Start()
    {
        Debug.Log("Touched 5");
        currentHealth = maxHealth;  // Initialize current health to maximum health
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        Debug.Log("Touched 6 , currentHealth " + currentHealth);

        if (currentHealth <= 0)
        {
            DestroyBox();
        }
    }

    public void DestroyBox()
    {

        Debug.Log("Touched 7");

        Destroy(gameObject);
    }
}
