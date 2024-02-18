using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeeMovement : MonoBehaviour
{

    [SerializeField] private LayerMask antControlLayer;
    [SerializeField] private bool facingUp;
    [SerializeField] private CircleCollider2D circleCollider;
    [SerializeField] private Rigidbody2D rigidbody2Dbee;
    [SerializeField] private float speed;
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private SpriteRenderer spriteRenderer;
    public int range;
    public bool isQueen;

    private Vector3 inital;

    [SerializeField] private int health;

    

    int countdown;


    // Start is called before the first frame update
    void Start()
    {
        facingUp = true;
        countdown = 0;
        inital = transform.position;
        //health = 10;
    }

    private void Update()
    {
        if (!isQueen&&Mathf.Floor(Time.time * 2) % 2 == 0)
        {
            spriteRenderer.sprite = sprites[0];
        }
        else if(!isQueen)
        {
            spriteRenderer.sprite = sprites[1];
        }
    }

    public void TakeDamage (int damage)
    {
        health -= damage;

        if(health <= 0) 
        {
            Die();
        }
    }
    void Die ()
    {
        //Instantiate(deatheEffect);
        if(isQueen)
        {
            SceneManager.LoadScene("Victory!!!");
        }
        Destroy(gameObject);
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
            rigidbody2Dbee.velocity = new Vector2(0, speed);
        }
        else
        {
            rigidbody2Dbee.velocity = new Vector2(0, -speed);
        }
        countdown = countdown <= 0 ? 0 : countdown - 1;
    }
}
