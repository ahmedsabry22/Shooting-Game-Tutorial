using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneAttacking : EnemyAttacking
{
    public GameObject bulletPrefab;
    public Transform fireSpawnPoint;
    public float fireRate = 0.25f;

    private float nextBullet;

    public override void Attack()
    {
        if (Time.time > nextBullet)
        {
            nextBullet = Time.time + fireRate;

            GameObject bullet = Instantiate(bulletPrefab, fireSpawnPoint.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody>().velocity = transform.forward * 25f;

            bullet.GetComponent<Bullet>().targetTag = "Player";
            bullet.GetComponent<Bullet>().target = Bullet.TargetToDestroy.Player;
        }
    }
}