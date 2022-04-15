using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

public class BirdMovement : MonoBehaviour
{
    [SerializeField] GameObject poop;

    public enum BirdState { Flying, Waddling, Charging};
    private BirdState currState = BirdState.Flying;
    private BirdState previousState = BirdState.Flying;

    public CharacterController controller;
    public float speed = 6f;

    public float turnSmoothTime = .2f;
    float turnSmoothVelocity;

    public Transform cam;

    public CinemachineFreeLook camera;

    private float maxPower = 10.0f;
    private float power;
    private float rechargeFactor = 3.0f;
    private float chargeFactor = -1f;

    private bool spacebarDown = false;

    private Slider powerSlider;
    public GameObject powerSliderUI;

    public GameObject body;

    public bool isCharging = false;
    public bool isOnGround = false;

    void Start()
    {
        powerSlider = GameObject.Find("Power Slider").GetComponent<Slider>();
        power = maxPower;
    }

    // Update is called once per frame
    void Update()
    {
        //powerSliderUI.SetActive(true);
        if (Input.GetKeyDown(KeyCode.E) && currState != BirdState.Waddling)
        {
            FirePoop();
        }
        if(Input.GetKeyDown(KeyCode.Q))
        {
            if (currState == BirdState.Flying)
                currState = BirdState.Waddling;
            else if (currState == BirdState.Waddling)
                currState = BirdState.Flying;
        }

        ChangePower(chargeFactor * Time.deltaTime);
         
        if (power < 0 && !isCharging)
        {
            currState = BirdState.Waddling;
        }

        if (currState == BirdState.Waddling)
        {
            isOnGround = true;
            transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
            //camera.GetRig(1).GetCinemachineComponent<CinemachineComposer>().m_ScreenY = .5f;
            body.GetComponent<Floater>().amplitude = .01f;
            body.GetComponent<Floater>().frequency = 4f;
            body.GetComponent<Floater>().floatOn = true;
            speed = 3f;
            chargeFactor = 0f;
        }
        else if (currState == BirdState.Flying)
        {
            isOnGround = false;
            transform.position = new Vector3(transform.position.x, 5, transform.position.z);
            //camera.GetRig(1).GetCinemachineComponent<CinemachineComposer>().m_ScreenY = .5f;
            body.GetComponent<Floater>().amplitude = .02f;
            body.GetComponent<Floater>().frequency = 1f;
            body.GetComponent<Floater>().floatOn = true;
            speed = 6f;
            chargeFactor = -.5f;
        }
        else if(currState == BirdState.Charging)
        {
            body.GetComponent<Floater>().floatOn = false;
            chargeFactor = 3f;
        }

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if(direction.magnitude >= .1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
        else if(currState == BirdState.Waddling)
        {
            body.GetComponent<Floater>().floatOn = false;
        }
    }
    
    public void SetStateCharging()
    {
        previousState = currState;
        if (previousState == BirdState.Flying)
            isOnGround = false;
        else if (previousState == BirdState.Waddling)
            isOnGround = true;
        currState = BirdState.Charging;
    }

    public void SetStateFlying()
    {
        currState = BirdState.Flying;
    }

    public void RestoreState()
    {
        currState = previousState;
    }

    public bool IsStateWaddling()
    {
        return currState == BirdState.Waddling;
    }

    void ChangePower(float change)
    {
        power += change;
        if (power > maxPower) power = maxPower;
        powerSlider.value = power / maxPower;
    }

    public void FirePoop()
    {
        GameObject localPoop = Instantiate(poop, transform.position, transform.rotation);
    }
}
