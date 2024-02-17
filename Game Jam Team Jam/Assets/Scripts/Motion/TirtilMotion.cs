using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class TirtilMotion : MonoBehaviour
{
    private float horizontal;
    private bool isFacingRight = true;
    private int isImmune; //0=not immune
    private readonly int maxImmunityTime = 150;
    private bool cantMove;


    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;
    [SerializeField] private Rigidbody2D playerRigidBody;
    [SerializeField] private CircleCollider2D boxCollider;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private HealtControl healtControl;
    [SerializeField] private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        isImmune = 0;
        cantMove = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.RightArrow))
        {
            horizontal = 1;
        }
        else if(Input.GetKey(KeyCode.LeftArrow))
        {
            horizontal = -1;
        }
        else
        {
            horizontal = 0;
        }
        horizontal = Input.GetAxisRaw("Horizontal");
        if(Physics2D.IsTouchingLayers(boxCollider, groundLayer))
        {
            cantMove = false;
            if (Input.GetKeyDown("c"))
            {
                playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, jumpPower * Mathf.Sign(playerRigidBody.gravityScale));
            }
        }
        Flip();
    }

    private void FixedUpdate()
    {
        if(isImmune>0)
        {
            if(Mathf.Floor(Time.time*10)%3==1)
            {
                spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0);
            }
            else
            {
                spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 255);
            }
        }
        else
        {
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 255);
        }
        isImmune = isImmune <= 0 ? 0 : isImmune - 1;
        if(!cantMove)
        {
            playerRigidBody.velocity = new Vector2(horizontal * speed, playerRigidBody.velocity.y);
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

    public void TakeDamage(int amount)
    {
        if(isImmune!=0)
        { 
            return; 
        }
        healtControl.IncreaseHealth(-amount);
        isImmune = maxImmunityTime;
        cantMove = true;
        playerRigidBody.velocity = new Vector2(-horizontal * 4, 4);
    }

}
