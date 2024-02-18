using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    private int enoughEsc;

    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;
    [SerializeField] private Rigidbody2D playerRigidBody;
    [SerializeField] private BoxCollider2D horizontalPlayerBoxCollider;
    [SerializeField] private BoxCollider2D idlePlayerBoxCollider;
    [SerializeField] private BoxCollider2D groundBoxCollider;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private LayerMask wallLayer;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private HealtControl healtControl;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private Transform swingTransform;
    // Start is called before the first frame update
    void Start()
    {
        isImmune = 0;
        cantMove = false;
        wallJumpCooldown = 0;
        horizontal = 0;
        Screen.SetResolution(1920, 1080, true);
        enoughEsc = 0;
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


        if (horizontal == 0)
        {
            spriteRenderer.sprite = sprites[0];
            horizontalPlayerBoxCollider.enabled = false;
            idlePlayerBoxCollider.enabled = true;
            swingTransform.position = new Vector3(swingTransform.position.x, playerRigidBody.position.y - 0.46f , -0.2f);
        }
        else
        {
            horizontalPlayerBoxCollider.enabled = true;
            idlePlayerBoxCollider.enabled = false;
            swingTransform.position = new Vector3(swingTransform.position.x, playerRigidBody.position.y - 1.03f, -0.2f);
            if (Mathf.Floor(Time.time * 2) % 2 == 1)
            {
                spriteRenderer.sprite = sprites[1];
            }
            else
            {
                spriteRenderer.sprite = sprites[2];
            }
        }
        Flip();
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

            playerRigidBody.velocity = new Vector2(horizontal * speed, playerRigidBody.velocity.y);
            
        }
        if(Input.GetKey(KeyCode.Q))
        {
            enoughEsc++;
            if(enoughEsc>150)
            {
                SceneManager.LoadScene("StartMenu");
            }
        }
        else
        {
            enoughEsc = 0;
        }
        if(playerRigidBody.position.x>10.8)
        {
            SceneManager.LoadScene("KozaCutscene");
        }
    }

    private void Flip()
    {
        if (Input.GetKey(KeyCode.LeftArrow) && isFacingRight)
        {
            transform.Rotate(0f, 180f, 0f);
            isFacingRight = false;
        }
        if (Input.GetKey(KeyCode.RightArrow) && !isFacingRight)
        {
            transform.Rotate(0f, 180f, 0f);
            isFacingRight = true;
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
}
