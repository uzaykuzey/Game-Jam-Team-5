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
<<<<<<< HEAD
    private int wallJumpCooldown;
    private int attackCooldown;
=======
>>>>>>> parent of a24296a (Merge branch 'main' of https://github.com/uzaykuzey/Game-Jam-Team-5)


    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;
    [SerializeField] private Rigidbody2D playerRigidBody;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private HealtControl healtControl;
<<<<<<< HEAD
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite[] sprites; //0: idle, 1: walk1, 2: walk2, 3: attacc
=======
>>>>>>> parent of a24296a (Merge branch 'main' of https://github.com/uzaykuzey/Game-Jam-Team-5)
    // Start is called before the first frame update
    void Start()
    {
        isImmune = 0;
        cantMove = false;
    }

    // Update is called once per frame
    void Update()
    {
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
        if(Input.GetKeyDown("x"))
        {
            spriteRenderer.sprite = sprites[3];
            attackCooldown = 50;
        }
        else if(attackCooldown==0)
        {
            if (horizontal == 0)
            {
                spriteRenderer.sprite = sprites[0];
            }
            else
            {
                if (Mathf.Floor(Time.time * 2) % 2 == 1)
                {
                    spriteRenderer.sprite = sprites[1];
                }
                else
                {
                    spriteRenderer.sprite = sprites[2];
                }
            }
        }
    }

    private void FixedUpdate()
    {
        isImmune = isImmune <= 0 ? 0 : isImmune - 1;
<<<<<<< HEAD
        wallJumpCooldown = wallJumpCooldown <= 0 ? 0 : wallJumpCooldown - 1;
        attackCooldown = attackCooldown <= 0 ? 0 : attackCooldown - 1;
        if ((!Physics2D.IsTouchingLayers(boxCollider, wallLayer)) &&!cantMove && wallJumpCooldown==0)
=======
        if(!cantMove)
>>>>>>> parent of a24296a (Merge branch 'main' of https://github.com/uzaykuzey/Game-Jam-Team-5)
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
    }

}
