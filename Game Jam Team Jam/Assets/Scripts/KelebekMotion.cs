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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        playerRigidBody.velocity = new Vector2(horizontal * speed, playerRigidBody.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown("c"))
        {
            playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, jumpPower * Mathf.Sign(playerRigidBody.gravityScale));
        }
    }

    private void Flip()
    {
        if (playerRigidBody.gravityScale < 0 && playerRigidBody.rotation < 1)
        {
            playerRigidBody.rotation = 180;
        }
        else if (playerRigidBody.gravityScale > 0 && playerRigidBody.rotation > 170)
        {
            playerRigidBody.rotation = 0;
        }

        if ((isFacingRight && horizontal < 0f && playerRigidBody.gravityScale > 0) || (!isFacingRight && horizontal > 0f && playerRigidBody.gravityScale > 0) || (isFacingRight && horizontal > 0f && playerRigidBody.gravityScale < 0) || (!isFacingRight && horizontal < 0f && playerRigidBody.gravityScale < 0))
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
