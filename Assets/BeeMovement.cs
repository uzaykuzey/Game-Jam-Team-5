using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeMovement : MonoBehaviour
{

    [SerializeField] private LayerMask antControlLayer;
    [SerializeField] private bool facingUp;
    [SerializeField] private CircleCollider2D circleCollider;
    [SerializeField] private Rigidbody2D rigidbody2D;
    [SerializeField] private float speed;
    public int range;

    private Vector3 inital;
    

    int countdown;


    // Start is called before the first frame update
    void Start()
    {
        facingUp = true;
        countdown = 0;
        inital = transform.position;
    }

    void FixedUpdate()
    {
        if (transform.position.y >=  inital.y + range || transform.position.y <= inital.y - range)
        {
            facingUp = !facingUp;
            countdown = 5;
        }
        if (facingUp)
        {
            rigidbody2D.velocity = new Vector2(0, speed);
        }
        else
        {
            rigidbody2D.velocity = new Vector2(0, -speed);
        }
        countdown = countdown <= 0 ? 0 : countdown - 1;
    }
}
