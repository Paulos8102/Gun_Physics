//PaulJabez_GunMechanism
//The working of the Bullet Object

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float bulletDamage = 10f; // Amount of damage the bullet deals
    public GameObject explosionPrefab; // Prefab of the explosion effect

    public void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Touched 1");
        if (other.CompareTag("Box"))
        {
            //Debug.Log("Touched 2");
            Box box = other.GetComponent<Box>();
            if (box != null)
            {
                box.TakeDamage(bulletDamage);
                DestroyBullet();
                //Debug.Log("Touched 3");
            }
        }
    }

    public void DestroyBullet()
    {
        //Debug.Log("Touched 4");
        if (explosionPrefab != null)
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
   
