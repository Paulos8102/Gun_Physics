using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMechanism : MonoBehaviour
{

    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;

    [SerializeField] public float bulletSpeed = 10.0f;

    public ParticleSystem muzzleFlash;

    private bool isFiring = false;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isFiring)
        {
            StartCoroutine(FireBullet());
        }
    }

    private IEnumerator FireBullet()
    {
        isFiring = true;

        var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

        bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;

        muzzleFlash.Play();

        // Get the duration of the muzzle flash
        var muzzleFlashDuration = muzzleFlash.main.duration;

        // Wait for the duration of the muzzle flash
        yield return new WaitForSeconds(muzzleFlashDuration);

        muzzleFlash.Stop();
        isFiring = false;
    }
}
