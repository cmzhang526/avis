using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poster : MonoBehaviour
{
    public bool canGrab = false;
    public bool thrownAway = false;
    public bool pickedUp = false;
    private float deathTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (thrownAway)
        {
            deathTimer += Time.deltaTime;
            if (deathTimer >= 3)
            {
                gameObject.SetActive(false);
            }
            return;
        }

        if (gameObject.transform.parent != null)
        {
            if (gameObject.transform.parent.tag == "Protester")
            {
                gameObject.GetComponent<Rigidbody>().isKinematic = true;
                canGrab = false;
            }
        }
        else
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
            canGrab = true;
        }
    }
}
