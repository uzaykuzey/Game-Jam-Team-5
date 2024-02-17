using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TirtilMotion : MonoBehaviour
{
    private float horizontal;
    private bool isFacingRight = true;
    private int isImmune; //0=not immune
    private readonly int maxImmunityTime = 150;
    private bool cantMove;
    private int wallJumpCooldown;
    private int attackCooldown;
    private float prevHorizontal;
    private bool touchingRightWall;
    private bool touchingLeftWall;

    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;
    [SerializeField] private Rigidbody2D playerRigidBody;
    [SerializeField] private BoxCollider2D playerBoxCollider;
    [SerializeField] private BoxCollider2D groundBoxCollider;
    [SerializeField] private BoxCollider2D rightCollider;
    [SerializeField] private Transform rightColliderTransform;
    [SerializeField] private BoxCollider2D leftCollider;
    [SerializeField] private Transform leftColliderTransform;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private LayerMask wallLayer;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private HealtControl healtControl;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private ParticleSystem particleSystemAttacc;
    [SerializeField] private Transform particleSystemTransform;
    // Start is called before the first frame update
    void Start()
    {
        isImmune = 0;
        cantMove = false;
        wallJumpCooldown = 0;
        horizontal = 0;
        Screen.SetResolution(1920, 1080, true);
    }

    // Update is called once per frame
    void Update()
    {
        if (wallJumpCooldown <= 80)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                horizontal = 1;
                wallJumpCooldown = 0;
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                horizontal = -1;
                wallJumpCooldown = 0;
            }
            else
            {
                prevHorizontal = horizontal == 0 ? prevHorizontal : horizontal;
                horizontal = 0;
            }
        }
        if (Physics2D.IsTouchingLayers(groundBoxCollider, groundLayer))
        {
            cantMove = false;
            wallJumpCooldown = 0;
            if (Input.GetKeyDown("c"))
            {
                playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, jumpPower);
            }
        }
        /*if (wallJumpCooldown < 80 && Physics2D.IsTouchingLayers(boxCollider, wallLayer))
        {
            wallJumpCooldown = 100;
            playerRigidBody.velocity = new Vector2(-Mathf.Sign(playerRigidBody.velocity.x) * speed, jumpPower * 0.35f);
        }*/

        if (attackCooldown == 0 && Input.GetKeyDown("x"))
        {
            particleSystemAttacc.Play();
            attackCooldown = 100;
        }
        if(!Physics2D.IsTouchingLayers(groundBoxCollider, groundLayer) && Physics2D.IsTouchingLayers(rightCollider, wallLayer))
        {
            spriteRenderer.sprite = sprites[3];
        }
        else if(!Physics2D.IsTouchingLayers(groundBoxCollider, groundLayer) && Physics2D.IsTouchingLayers(leftCollider, wallLayer))
        {
            spriteRenderer.sprite = sprites[4];
        }
        else if (horizontal == 0)
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
            Flip();
        }
        rightColliderTransform.position = new Vector3(playerRigidBody.position.x + 1.196f, playerRigidBody.position.y - 0.93f, -0.2f);
        leftColliderTransform.position = new Vector3(playerRigidBody.position.x - 1.837f, playerRigidBody.position.y - 0.93f, -0.2f);
    }

    private void FixedUpdate()
    {
        if (isImmune > 0)
        {
            if (Mathf.Floor(Time.time * 10) % 3 == 1)
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
            cantMove = false;
        }
        isImmune = isImmune <= 0 ? 0 : isImmune - 1;
        wallJumpCooldown = wallJumpCooldown <= 0 ? 0 : wallJumpCooldown - 1;
        attackCooldown = attackCooldown <= 0 ? 0 : attackCooldown - 1;
        if (!cantMove)
        {
            if((touchingRightWall && horizontal==-1)||(touchingLeftWall && horizontal == 1)||(!touchingLeftWall&& !touchingRightWall))
            {
                playerRigidBody.velocity = new Vector2(horizontal * speed, playerRigidBody.velocity.y);
            }
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
        if (isImmune != 0)
        {
            return;
        }
        healtControl.IncreaseHealth(-amount);
        isImmune = maxImmunityTime;
        cantMove = true;
        playerRigidBody.velocity = new Vector2(-horizontal * 6, 6);
    }

    public void touchRightWall(bool boolean)
    {
        touchingRightWall=boolean;
    }

    public void touchLeftWall(bool boolean)
    {
        touchingLeftWall=boolean;
    }

}
