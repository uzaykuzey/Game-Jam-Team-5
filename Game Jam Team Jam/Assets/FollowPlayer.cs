using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform target;


    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = target.poisiton + offset;
        transform.position = Vector3.SmoothDamn(transform.position, targetPosition, ref velocity,smoothTime);
    }
}
