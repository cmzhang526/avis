using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public GameObject myHands; //reference to your hands/the position where you want your object to go
    bool canpickup; //a bool to see if you can or cant pick up the item
    GameObject ObjectIwantToPickUp; // the gameobject onwhich you collided with
    bool hasItem; // a bool to see if you have an item in your hand
    // Start is called before the first frame update
    bool justReleased = false;
    public AudioSource pickupSounds;
    void Start()
    {
        canpickup = false;    //setting both to false
        hasItem = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") && hasItem)
        {
            ObjectIwantToPickUp.GetComponent<Rigidbody>().isKinematic = false;

            ObjectIwantToPickUp.transform.parent = null;
            ObjectIwantToPickUp.gameObject.GetComponent<Poster>().pickedUp = false;
            hasItem = false;
            justReleased = true;
            pickupSounds.Play();
        }

        if (canpickup && !justReleased) 
        {
            if (Input.GetKeyDown("space"))
            {
                ObjectIwantToPickUp.GetComponent<Rigidbody>().isKinematic = true;   
                ObjectIwantToPickUp.transform.position = myHands.transform.position;
                ObjectIwantToPickUp.transform.SetParent(myHands.transform);
                ObjectIwantToPickUp.gameObject.GetComponent<Poster>().pickedUp = true;
                hasItem = true;
                pickupSounds.Play();
            }
        }
        justReleased = false;
    }
    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "Poster") 
        {
            if (other.gameObject.GetComponent<Poster>().canGrab && !other.gameObject.GetComponent<Poster>().thrownAway)
            {
                canpickup = true;
                ObjectIwantToPickUp = other.gameObject;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        canpickup = false;
    }
}
