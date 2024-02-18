using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HunterBird : MonoBehaviour
{

    private int counter;

    public int maxCnt = 1000;
    [SerializeField] private float speed;
    [SerializeField] private Transform birdStart;
    [SerializeField] private Transform birdEnd;
    [SerializeField] private Rigidbody2D playerRigidBody;


    // Start is called before the first frame update
    void Start()
    {
        counter = maxCnt;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if(transform.position.x <= birdEnd.position.x)
        {
            playerRigidBody.velocity = new Vector2(0, 0);
        }
        if(counter > 0)
        {
            counter--;
        }
        if(counter <= 0)
        {

            BirdStrike();
            counter = maxCnt;

        }

    }
    void BirdStrike()
    {
        //Move from inital Point to other point
        transform.position = birdStart.position;
        float temp =  birdStart.position.x - birdEnd.position.x;
        if(temp > 0) 
        {
            playerRigidBody.velocity = new Vector2(-speed, playerRigidBody.velocity.y);
        }
        else
        {
            playerRigidBody.velocity = new Vector2(speed, playerRigidBody.velocity.y);
        }
        

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        KelebekMotion butterFly = collision.GetComponent<KelebekMotion>();

        if (butterFly != null)
        {
            Debug.Log("worked bird");
            //Destroy(collision.gameObject);
            SceneManager.LoadScene("Kelebek");
        }
        
    }
}
