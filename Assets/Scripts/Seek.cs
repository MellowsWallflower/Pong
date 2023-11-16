using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : MonoBehaviour
{
    // Homework task 1: if the AI has detected the player, shoot at it (1%)!
    // I attached this script to the enemy character and added a player movement script to the player to "get out of range
    // of the enemy"
 public GameObject target;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 5.0f;
    public float fireRate = 1.0f;
    private float nextFireTime = 0.0f;

    float speed = 2.0f;
    bool seeking = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        seeking = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
  {
        seeking = false;
    }

    void Update()
    {
        float dt = Time.deltaTime;

        if (seeking)
        {
            // Move towards the target
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * dt);

            // Shoot at the target if it's time to fire
            if (Time.time >= nextFireTime)
            {
                Shoot();
                nextFireTime = Time.time + 1 / fireRate; // Update the next fire time
            }
        }
    }

    void Shoot()
    {
        // Instantiate a bullet at the fire point
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        
        // Add force to the bullet to make it move
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.velocity = (target.transform.position - transform.position).normalized * bulletSpeed;
    }
}
