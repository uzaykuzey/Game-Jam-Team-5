using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float life = 3;

    void Awake()
    {
        Destroy(gameObject, life);
    }



    void OnTriggerEnter2D(Collider2D collision)
    {
        BeeMovement bee = collision.GetComponent<BeeMovement>();
        if(bee != null) 
        {
            Debug.Log("worked bullet");
            bee.TakeDamage(10);
        }
    }
}
