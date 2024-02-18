using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] public Transform[] healthBars;
    [SerializeField] public Transform cameraTransform;
    [SerializeField] public Camera cameraMain;
    [SerializeField] public Transform player;
    private void Update()
    {
        float distanceToCamera = 2f;
        Vector3 offset1 = new Vector3(-7.45119f, 4.321f, distanceToCamera);
        Vector3 offset2 = new Vector3(-6.250601f, 4.321f, distanceToCamera);
        Vector3 offset3 = new Vector3(-5.029312f, 4.321f, distanceToCamera);

        healthBars[0].position = cameraTransform.position + offset1;
        healthBars[1].position = cameraTransform.position + offset2;
        healthBars[2].position = cameraTransform.position + offset3;

        if (player.position.y > 1.2f)
        {
            transform.position = new Vector3(transform.position.x, player.position.y , transform.position.z);
        }
    }

}
