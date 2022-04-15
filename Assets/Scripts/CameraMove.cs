using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject player;

    public float sensitivity;

    private float yaw = 0;

    private float maxYaw = 0;

    // Start is called before the first frame update
    void Start()
    {
        maxYaw = 30 * Mathf.Deg2Rad;
        Debug.Log("MAXYAW = " + maxYaw);
    }

    // LateUpdate is called once per frame, after Update
    void Update()
    {
        
        float rotateHorizontal = Input.GetAxis("Mouse X");
        float rotateVertical = Input.GetAxis("Mouse Y");
        // Debug.Log("x = " + rotateHorizontal + ", y = " + rotateVertical);

        float delta = sensitivity * rotateHorizontal;
        yaw += delta;
        yaw = Mathf.Clamp(yaw, -30, 30);

        Debug.Log("yaw = " + yaw + ", rotation = " + transform.rotation.y);

        // yaw += (player.transform.rotation.y - transform.rotation.y);
        // transform.LookAt(player.transform);

        // Debug.Log(transform.rotation.)
        
        transform.Rotate(0, delta, 0);
        // if (delta < 0 && transform.rotation.y > -maxYaw)
        // {
        //     transform.Rotate(0, delta, 0);
        // }
        // else transform.Rotate(0, -maxYaw - transform.rotation.y, 0);
            
        //     (delta > 0 && transform.rotation.y < maxYaw))
        // {
        //     
        // }

        
        transform.Rotate(0, delta, 0);

        // transform.rotation = Quaternion.Euler(transform.rotation.x, yaw, transform.rotation.z);

        // transform.RotateAround(player.transform.position, Vector3.up, rotateHorizontal * sensitivity); //use transform.Rotate(-transform.up * rotateHorizontal * sensitivity) instead if you dont want the camera to rotate around the player
        // transform.RotateAround(Vector3.zero, transform.right, rotateVertical * sensitivity); // again, use transform.Rotate(transform.right * rotateVertical * sensitivity) if you don't want the camera to rotate around the player

    }
}
