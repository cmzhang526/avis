using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public GameObject targetObject;

    private Vector3 displacement;

    // Start is called before the first frame update
    void Start()
    {
        displacement = targetObject.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = targetObject.transform.position - displacement;
        // transform.LookAt(targetObject.transform);
    }
}
