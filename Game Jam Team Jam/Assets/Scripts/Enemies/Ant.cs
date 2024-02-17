using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ant : IEnemy
{
    [SerializeField] private LayerMask antControlLayer;
    [SerializeField] private bool facingRight;
    [SerializeField] private CircleCollider2D circleCollider;
    [SerializeField] private float speed;
    int countdown;

    // Start is called before the first frame update
    void Start()
    {
        facingRight = true;
        countdown = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (countdown<=0&&Physics2D.IsTouchingLayers(circleCollider, antControlLayer))
        {
            facingRight = !facingRight;
            countdown = 5;
        }
        if(facingRight)
        {
            enemyRigidBody.velocity = new Vector2(speed, 0);
        }
        else
        {
            enemyRigidBody.velocity = new Vector2(-speed, 0);
        }
        countdown= countdown<=0 ? 0: countdown-1;
    }
}
