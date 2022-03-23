using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;
    public GameObject projectilePrefab;
    public Transform projectileSpawnPoint;
    public Transform projectileSpawnPoint1;
    public Transform projectileSpawnPoint2;

    public float acceleration;
    public float maxSpeed;
    public int maxArmor;
    public float fireRate;
    public float projectileSpeed;

    [HideInInspector] public float currentSpeed;
    [HideInInspector] public int currentArmor;

    [HideInInspector] public bool canShoot;

    [HideInInspector] ParticleSystem thrustParticles;

    public AudioSource fireSound;
    public AudioSource getHitSound;

    private void Awake()
    {
        currentArmor = maxArmor;
        canShoot = true;
        thrustParticles = GetComponentInChildren<ParticleSystem>();
    }

    private void FixedUpdate()
    {
        if (rigidbody2D.velocity.magnitude > maxSpeed)
        {
            rigidbody2D.velocity = rigidbody2D.velocity.normalized * maxSpeed;
        }
    }

    public void Thrust()
    {
        rigidbody2D.AddForce(transform.up * acceleration);
        thrustParticles.Emit(1);
    }
    public void FireProjectile()
    {
        GameObject projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, transform.rotation);
        projectile.GetComponent<Rigidbody2D>().AddForce(transform.up * projectileSpeed);
        projectile.GetComponent<Projectile>().GetFired(gameObject);
        Destroy(projectile, 4);
        StartCoroutine(FireRateBuffer());

        fireSound.Play();
    }

    public void FireProjectile1()
    {
        GameObject projectile = Instantiate(projectilePrefab, projectileSpawnPoint1.position, transform.rotation);
        projectile.GetComponent<Rigidbody2D>().AddForce(transform.up * projectileSpeed);
        projectile.GetComponent<Projectile>().GetFired(gameObject);
        Destroy(projectile, 4);
        StartCoroutine(FireRateBuffer());

        fireSound.Play();
    }

    public void FireProjectile2()
    {
        GameObject projectile = Instantiate(projectilePrefab, projectileSpawnPoint2.position, transform.rotation);
        projectile.GetComponent<Rigidbody2D>().AddForce(transform.up * projectileSpeed);
        projectile.GetComponent<Projectile>().GetFired(gameObject);
        Destroy(projectile, 4);
        StartCoroutine(FireRateBuffer());

    }

    private IEnumerator FireRateBuffer()
    {
        canShoot = false;
        yield return new WaitForSeconds(fireRate);
        canShoot = true;
    }

    public void TakeDamage(int damageToGive)
    {
        //TODO: Add damageTick sound
        currentArmor -= damageToGive;
        if(currentArmor <= 0)
        {
            Explode();
        }

        if (GetComponent<PlayerShip>())
        {
            HUD.Instance.DisplayHealth(currentArmor, maxArmor);
        }

        getHitSound.Play();
    }

    public void Explode()
    {
        //TODO Create explosion particles
        ScreenShaker.Instance.ShakeScreen();
        Instantiate(Resources.Load("Explosion"), transform.position, transform.rotation);

        if(GetComponent<PlayerShip>())
        {
            SessionManager.Instance.HandlePlayerDestroyed();
        }

        Destroy(gameObject);

        FindObjectOfType<EnemyShipSpawner>().CountEnemyShips();
    }
}
