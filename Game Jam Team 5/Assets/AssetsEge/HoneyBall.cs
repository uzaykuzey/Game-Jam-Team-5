using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoneyBall : MonoBehaviour
{
    public float life = 3;

    void Awake()
    {
        Destroy(gameObject, life);
    }



    void OnTriggerEnter2D(Collider2D collision)
    {
        //Destroy(collision.gameObject);

        KelebekMotion butterFly = collision.GetComponent<KelebekMotion>();
        
        if (butterFly != null)
        {
            Debug.Log("worked honeyball");
            butterFly.gotShotByHoney();
        }
        Destroy(gameObject);
    }
}
