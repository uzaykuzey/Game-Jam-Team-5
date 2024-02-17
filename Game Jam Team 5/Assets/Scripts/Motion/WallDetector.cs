using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDetector : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] bool isRight;
    [SerializeField] TirtilMotion tirtil;
    [SerializeField] LayerMask wallLayer;

    // Update is called once per frame
    private void OnCollisionStay2D(Collision2D collision)
    {
        print("incollision");
        if(collision.gameObject.layer==wallLayer)
        {
            if(isRight)
            {
                tirtil.touchRightWall(true);
            }
            else
            {
                tirtil.touchLeftWall(true);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        print("exited collision");
        if (collision.gameObject.layer == wallLayer)
        {
            if (isRight)
            {
                tirtil.touchRightWall(false);
            }
            else
            {
                tirtil.touchLeftWall(false);
            }
        }
    }
}
