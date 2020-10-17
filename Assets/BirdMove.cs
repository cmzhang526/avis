using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMove : MonoBehaviour
{
    private int pitch = 0; // 1 is forward, -1 is backwards
    private float rotateSpeed = 100.0f;

    private bool spacebarDown = false;
    
    private Vector3 velocity = new Vector3(0, 0, 0);
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // get player input
        if (Input.GetKey(KeyCode.Space))
        {
            if (!spacebarDown)
            {
                velocity += new Vector3(0, 0.5f, 0);
            }

            spacebarDown = true;
        }
        else spacebarDown = false;
        if (Input.GetKey(KeyCode.W))
        {
            pitch = 1;
            Debug.Log("W");
        }
        else if (Input.GetKey(KeyCode.S))
        {
            pitch = -1;
            Debug.Log("S");
        }
        else
        {
            pitch = 0;
            Debug.Log("none");
        }
        
        // adjust rotation/position
        if (pitch != 0)
        {
            transform.Rotate(Time.deltaTime * pitch * rotateSpeed, 0, 0);
        }

        velocity -= new Vector3(0, Time.deltaTime * 1f, 0);
        transform.position += velocity;
    }
}
