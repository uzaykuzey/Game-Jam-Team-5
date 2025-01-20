using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private LayerMask spikes;
    private int enoughEsc;
    // Start is called before the first frame update
    private bool hasHoney;
    private int honeyCounter;
    void Start()
    {
        hasHoney = false;
        enoughEsc = 0;
    }
    public void gotShotByHoney()
    {
        hasHoney=true;
        honeyCounter = 75;
    }

    private void FixedUpdate()
    {
        playerRigidBody.velocity = new Vector2(horizontal * speed, playerRigidBody.velocity.y);

        if(hasHoney)
        {
            
            speed = 2;

            if (honeyCounter > 0)
            {
                honeyCounter--;
            }
            if (honeyCounter <= 0)
            {
                speed = 4;
                honeyCounter = 0;
                hasHoney = false;
            }
        }
        if (Input.GetKey(KeyCode.Q))
        {
            enoughEsc++;
            if (enoughEsc > 20)
            {
                SceneManager.LoadScene("StartMenu");
            }
        }
        else
        {
            enoughEsc = 0;
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
        if(Mathf.Floor(Time.time*2)%2==0)
        {
            spriteRenderer.sprite = sprites[0];
        }
        else
        {
            spriteRenderer.sprite = sprites[1];
        }
        if(Physics2D.IsTouchingLayers(boxCollider, spikes))
        {
            SceneManager.LoadScene("Kelebek");
        }
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
