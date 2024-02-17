using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlock : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigidBody;
    [SerializeField] bool xaxis;
    [SerializeField] int speed;
    [SerializeField] float range;
    int countdown;
    int lookingPositive;
    Vector2 firstPosition;

    private void Start()
    {
        firstPosition= transform.position;
        lookingPositive = 1;
        countdown= 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(countdown==0&&xaxis)
        {
            if (transform.position.x>=firstPosition.x+range || transform.position.x<=firstPosition.x)
            {
                lookingPositive *= -1;
                countdown = 20;
            }
        }
        else
        {
            if (transform.position.y >= firstPosition.y + range || transform.position.y <= firstPosition.y)
            {
                lookingPositive *= -1;
                countdown = 25;
            }
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
        countdown = countdown<=0 ? 0: countdown-1;
    }
}
