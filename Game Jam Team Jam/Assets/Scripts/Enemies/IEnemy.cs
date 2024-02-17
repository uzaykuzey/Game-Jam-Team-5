using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IEnemy : MonoBehaviour
{
    [SerializeField] protected int health;
    [SerializeField] protected int damage;
    [SerializeField] protected CircleCollider2D enemyCollider;
    [SerializeField] protected LayerMask playerLayer;
    [SerializeField] protected TirtilMotion tirtil;
    [SerializeField] protected Rigidbody2D enemyRigidBody;

    void Update()
    {
        if(Physics2D.IsTouchingLayers(enemyCollider, playerLayer))
        {
            tirtil.TakeDamage(damage);
        }
    }
}
