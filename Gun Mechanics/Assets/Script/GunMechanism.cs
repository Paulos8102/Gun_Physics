using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMechanism : MonoBehaviour
{
    //Gun objects
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    [SerializeField] public float fireRate = 1f;

    [SerializeField] public float bulletSpeed = 10.0f;

    public ParticleSystem muzzleFlash;

    //Firing Check
    private bool isFiring = false;
    private float nextTimeToFire = 0f;

    //Objects to implement reload time
    public int maxAmmo = 2;
    private int currentAmmo;
    public float reloadTime = 2f;
    private bool isReloading = false;

    public Animator anim;

    //Audio effects
    [SerializeField] private AudioSource reloadSound;
    [SerializeField] private AudioSource shootSound; 


    public void Start()
    {
        if(currentAmmo ==-1)
            currentAmmo = maxAmmo;
    }

    public void OnEnbale()
    {
        isReloading = false;
        anim.SetBool("Reloading", false);
    }

    public void Update()
    {
        if ( isReloading )
            return;

        if ( currentAmmo <= 0 )
        {
            StartCoroutine(Reload());
            return;
        }

        if ( Input.GetKeyDown(KeyCode.Space) && !isFiring && Time.time  >= nextTimeToFire )
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            StartCoroutine(FireBullet());
        }
    }

    public IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("Reloading");

        anim.SetBool("Reloading", true);

        reloadSound.Play();

        yield return new WaitForSeconds(reloadTime - .25f);

        anim.SetBool("Reloading", false);

        yield return new WaitForSeconds(.25f);

        currentAmmo = maxAmmo;
        isReloading = false;
    }

    private IEnumerator FireBullet()
    {
        isFiring = true;

        currentAmmo--;

        var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

        bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;

        muzzleFlash.Play();
        shootSound.Play();

        // Get the duration of the muzzle flash
        var muzzleFlashDuration = muzzleFlash.main.duration;

        // Wait for the duration of the muzzle flash
        yield return new WaitForSeconds(muzzleFlashDuration);

        muzzleFlash.Stop();
        isFiring = false;
    }
}
