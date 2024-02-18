using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KelebekMotion : MonoBehaviour
{
    private float horizontal;
    private bool isFacingRight = true;
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;
    [SerializeField] private Rigidbody2D playerRigidBody;
    [SerializeField] private CircleCollider2D boxCollider;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Transform bulletStart;
    // Start is called before the first frame update
    private bool hasHoney;
    private int honeyCounter;
    void Start()
    {
        hasHoney = false;
    }
    public void gotShotByHoney()
    {
        hasHoney=true;
    }

    private void FixedUpdate()
    {
        playerRigidBody.velocity = new Vector2(horizontal * speed, playerRigidBody.velocity.y);

        if(hasHoney)
        {
            honeyCounter = 75;
            speed /= 2;

            if (honeyCounter > 0)
            {
                honeyCounter--;
            }
            if (honeyCounter <= 0)
            {
                speed *= 2;
                honeyCounter = 0;
                hasHoney = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if (Input.GetKey("c"))
        {
            playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, jumpPower);
        }
        Flip();
    }

    private void Flip()
    {

        if(Input.GetKey(KeyCode.LeftArrow) && isFacingRight)
        {
            transform.Rotate(0f, 180f, 0f);
            isFacingRight = false;
        }
        if(Input.GetKey(KeyCode.RightArrow) && !isFacingRight)
        {
            transform.Rotate(0f, 180f, 0f);
            isFacingRight = true;
        }

    }
}
