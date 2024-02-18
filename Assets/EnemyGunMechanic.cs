using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunMechanic : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;




    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("z"))
        {

            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = bulletSpawnPoint.right * bulletSpeed;


        }

    }
}
