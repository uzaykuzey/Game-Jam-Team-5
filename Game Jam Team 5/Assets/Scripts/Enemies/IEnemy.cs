using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IEnemy : MonoBehaviour
{
    [SerializeField] protected int health;
    [SerializeField] protected int damage;
    [SerializeField] protected BoxCollider2D enemyCollider;
    [SerializeField] protected LayerMask playerLayer;
    [SerializeField] protected TirtilMotion tirtil;
    [SerializeField] protected Rigidbody2D enemyRigidBody;
    [SerializeField] protected LayerMask weaponLayer;
    int immunityCountdown;

    void Update()
    {
        if(Physics2D.IsTouchingLayers(enemyCollider, playerLayer))
        {
            tirtil.TakeDamage(damage);
        }
        if(immunityCountdown==0&&Physics2D.IsTouchingLayers(enemyCollider, weaponLayer))
        {
            health--;
            immunityCountdown = 10;
        }
        if(health<=0)
        {
            Die();
        }
    }

    private void FixedUpdate()
    {
        immunityCountdown=immunityCountdown==0? 0 : immunityCountdown-1;
    }

    public void Die()
    {
        transform.position = new Vector2(1000,0);
    }
}
