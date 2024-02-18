using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GunMechanic : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;
    [SerializeField] private AudioSource bulletSound;

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown("x"))
        {
           
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = bulletSpawnPoint.right   * bulletSpeed;
            bulletSound.Play();
        }

    }

}
