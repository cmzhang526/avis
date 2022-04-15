// Floater v0.0.2
// by Donovan Keith
//
// [MIT License](https://opensource.org/licenses/MIT)

using UnityEngine;
using System.Collections;

// Makes objects float up & down while gently spinning.
public class Floater : MonoBehaviour
{
    public GameObject birdGameObject;
    // User Inputs
    public float degreesPerSecond = 15.0f;
    public float amplitude = 0.5f;
    public float frequency = 1f;
    private float timeElapsedSincePause = 0.0f;

    public bool floatOn = true;
    // Position Storage Variables
    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();

    // Use this for initialization
    void Start()
    {
        // Store the starting position & rotation of the object
        posOffset = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseMenu.isPaused) return;
        // Float up/down with a Sin()
        tempPos = transform.position;
        if (floatOn)
        { tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude; }
        else
        {
            if (birdGameObject.GetComponent<BirdMovement>().isOnGround)
                tempPos.y = .5f;
            else
                tempPos.y = 5f;
        }

        transform.position = tempPos;
    }
}
