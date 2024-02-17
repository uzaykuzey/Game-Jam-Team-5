using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] public Transform[] healthBars;
    [SerializeField] public Transform cameraTransform;
    [SerializeField] public Camera cameraMain;
    private void Update()
    {
        float distanceToCamera = 2f;
        Vector3 offset1 = new Vector3(-7.45119f, 4.396813f, distanceToCamera);
        Vector3 offset2 = new Vector3(-6.250601f, 4.376113f, distanceToCamera);
        Vector3 offset3 = new Vector3(-5.029312f, 4.376113f, distanceToCamera);

        healthBars[0].position = cameraTransform.position + offset1;
        healthBars[1].position = cameraTransform.position + offset2;
        healthBars[2].position = cameraTransform.position + offset3;
    }
}
