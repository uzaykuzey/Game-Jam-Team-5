using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlock : MonoBehaviour
{
    [SerializeField] BoxCollider2D boxCollider;
    [SerializeField] Rigidbody2D rigidBody;
    [SerializeField] LayerMask boxController;
    [SerializeField] bool xaxis;
    [SerializeField] int speed;
    int countdown;
    int lookingPositive;

    // Update is called once per frame
    void Update()
    {
        lookingPositive = 1;
        if(countdown==0&&Physics2D.IsTouchingLayers(boxCollider, boxController))
        {
            lookingPositive *= -1;
            countdown = 10;
        }

    }

    private void FixedUpdate()
    {
        if (xaxis)
        {
            rigidBody.velocity = new Vector2(speed * lookingPositive, 0);
        }
        else
        {
            rigidBody.velocity = new Vector2(0, speed * lookingPositive);
        }
        countdown = countdown<=0? 0: countdown-1;
    }
}
