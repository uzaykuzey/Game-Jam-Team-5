using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Vector3 offset = new Vector3(3f, 2f, -10f);
    private float smoothTime = 0.25f;
    private Vector3 velocity = Vector3.zero;
    [SerializeField] private Transform target;


    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = target.position + offset;
        targetPosition.y = 0;

        if(targetPosition.x < 0)
        {
            targetPosition.x = 0;
        }
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}


