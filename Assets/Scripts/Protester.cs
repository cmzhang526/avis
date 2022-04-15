using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Protester : MonoBehaviour
{
    public GameObject poster;
    public AudioSource poopSplat;
    float runspeed = 0.0f;
    bool poopedOn = false;
    // Update is called once per frame
    void Update()
    {
        if(poopedOn)
        {
            Debug.Log("Running");
            transform.position = new Vector3(transform.position.x + runspeed * Time.deltaTime, transform.position.y, transform.position.z);
        }
    }

    public void Run()
    {
        poopSplat.Play();

        runspeed = 5.0f;
        Debug.Log("Hit");
        if (poster != null)
        {
            poster.GetComponent<Rigidbody>().isKinematic = false;
            poster.transform.parent = null;
            poster = null;
            poopedOn = true;
            Debug.Log("Has Poster");
        }
    }

    public void RunCoroutine()
    {
        poopSplat.Play();

        runspeed = 5.0f;
        Debug.Log("Hit");
        if (poster != null)
        {
            poster.GetComponent<Rigidbody>().isKinematic = false;
            poster.transform.parent = null;
            poster = null;
            poopedOn = true;
            Debug.Log("Has Poster");
        }
    }
}
