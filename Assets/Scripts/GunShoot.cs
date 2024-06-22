using UnityEngine;
using System.Collections;

public class GunShoot : MonoBehaviour
{
    public Camera fpsCam;
    public AudioSource gunShotSFX;
    public AudioSource gunReloadSFX;
    public Animator animator;

    public float damage = 10f;
    public float range = 100f;
    public float impactForce = 50f;
    public float fireRate = 15f;
    public float reloadTime = 1f;
    public int maxAmmo = 10;
    
    private int currentAmmo;
    private bool isReloading = false;
    private float nextTimeToFire = 0f;


    void OnEnable()
    {
        isReloading = false;
        animator.SetBool("Reloading", false);
    }



    // Start is called before the first frame update
    void Start()
    {
        currentAmmo = maxAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        
        // Returns from Update() when Reloading is already being played
        if (isReloading)
        {
            return;
        }
        
        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload()); 
            return;
        }


        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + (1f / fireRate);
            Shoot();
        }

    }



    IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("Reloading...");

        animator.SetBool("Reloading", true);

        yield return new WaitForSeconds(reloadTime - 0.25f);
        currentAmmo = maxAmmo;
        gunReloadSFX.Play();
        yield return new WaitForSeconds(0.25f); // Prevents shooting while reload animation is still being played

        animator.SetBool("Reloading", false);

        isReloading = false;
    }

    void Shoot()
    {
        
        gunShotSFX.Play();
        currentAmmo--;
        
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            HealthEnemy enemyHealth = hit.transform.GetComponent<HealthEnemy>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage); // If class instance of HealthBase Script is present, then call the TakeDamage() function
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce); // Knockback effect
            }

        }


    }
}
