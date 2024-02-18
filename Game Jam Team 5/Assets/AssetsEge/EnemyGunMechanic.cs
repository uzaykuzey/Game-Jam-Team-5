using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunMechanic : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;
    public double bulletFrequency = 10;
    private double curTime;


    private void Start()
    {
        curTime = bulletFrequency * 50;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("z"))
        {

            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = bulletSpawnPoint.right * bulletSpeed;


        }

    }
    private void FixedUpdate()
    {
        if (curTime == 0)
        {
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = bulletSpawnPoint.right * bulletSpeed;
            curTime = bulletFrequency * 50;
        }
        else
        {
            curTime--;
        }


    }
}