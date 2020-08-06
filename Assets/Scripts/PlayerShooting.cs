using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform fireSpawnPoint;
    public float fireRate = 0.25f;

    private PlayerMovement playerMovement;
    private Animator playerAnimator;
    private float nextBullet;

    private void Awake()
    {
        playerAnimator = GetComponentInChildren<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        //Code for firing.
        if (Input.GetMouseButton(0))
        {
            playerMovement.isShooting = true;

            playerAnimator.SetBool("Fire", true);

            if (Time.time > nextBullet)
            {
                nextBullet = Time.time + fireRate;

                GameObject bullet = Instantiate(bulletPrefab, fireSpawnPoint.position, Quaternion.identity);
                bullet.GetComponent<Rigidbody>().velocity = transform.forward * 20;

                bullet.GetComponent<Bullet>().targetTag = "Enemy";
                bullet.GetComponent<Bullet>().target = Bullet.TargetToDestroy.Enemy;
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            playerMovement.isShooting = false;
            playerAnimator.SetBool("Fire", false);
        }
    }
}