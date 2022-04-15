using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerLine : MonoBehaviour
{
    private string orientation;

    public BirdMovement bird;
    
    // Start is called before the first frame update
    void Start()
    {
        if (transform.localScale.x > transform.localScale.z)
        {
            orientation = "z";
        }
        else orientation = "x";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool IsXCentered()
    {
        return (orientation == "x");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == bird.gameObject)
        {
            // sit on power line
            bird.SetStateCharging();
            bird.isCharging = true;
            float height = gameObject.transform.position.y + 1;

            /*if (IsXCentered())
            {
                other.gameObject.transform.position = new Vector3(gameObject.transform.position.x, height, other.gameObject.transform.position.z);
            }
            else other.gameObject.transform.position = new Vector3(other.gameObject.transform.position.x, height, gameObject.transform.position.z);
            */
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            // sit on power line
            bird.RestoreState();
            bird.isCharging = false;
            /*float height = 5;

            /*if (IsXCentered())
            {
                other.gameObject.transform.position = new Vector3(gameObject.transform.position.x, height, other.gameObject.transform.position.z);
            }
            else other.gameObject.transform.position = new Vector3(other.gameObject.transform.position.x, height, gameObject.transform.position.z);
            */
        }
    }
}
