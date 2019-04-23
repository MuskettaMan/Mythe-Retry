using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Geschreven door Erik, aangepast door Sed.
public class CameraController : MonoBehaviour
{
    private Transform target;

    // Array of all the cameras.
    public GameObject[] cameras;
    [HideInInspector] public static int currentCamera; // This is the only active camera.

    // Speed at which the camera follows the player.
    private float smoothSpeed = 5f;

    // Camera angle.
    private float cameraAngle = 20f;
    private float angleClose = 10f;

    // Camera rotation.
    private Transform fromRot;
    private Transform toRot;
    private float rotCountClose = 0.0f;
    private float rotCountNormal = 0.0f;

    // Distance from player to camera.
    private float yOffset = 2f;
    private float yClose = 1f;
    private float yNormal = 2f;

    private float zOffset = 1f;
    private float zClose = 3.5f;
    private float zNormal = 5f;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;

        // Starts game with main camera.
        currentCamera = 0;

        zOffset = PickupInteraction.isInteracting ? zClose : zNormal;
        yOffset = PickupInteraction.isInteracting ? yClose : yNormal;
    }

    private void Update()
    {

    }

    private void FixedUpdate()
    {
        Follow();
    }

    private void Follow() // Handles camera movement.
    {
        // Position.
        Vector3 cameraPos = new Vector3(target.position.x, target.position.y + yOffset, target.transform.position.z - zOffset);

        // Rotation.
        Vector3 cameraRot = new Vector3(cameraAngle, 0, 0);
        Quaternion cameraCloseRot = new Quaternion(angleClose, 0, 0, 0);


        for (int i = 0; i < cameras.Length; i++)
        {
            //cameraPos.z = initialCameraLocation[i].z;
            cameras[i].transform.eulerAngles = cameraRot;
            cameras[i].SetActive(false);

            if (i == currentCamera)
            {
                cameras[i].SetActive(true);
                cameras[i].transform.position = Vector3.Lerp(cameras[i].transform.position, cameraPos, smoothSpeed * Time.deltaTime);
                
            }
        }
    }

}
