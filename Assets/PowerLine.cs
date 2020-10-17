using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerLine : MonoBehaviour
{
    private string orientation;
    
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
}
