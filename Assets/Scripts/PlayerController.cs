using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] InputAction movement;
    [SerializeField] InputAction fire;

    [SerializeField] float xySpeed = 25f;
    [SerializeField] float xRange = 5f;
    [SerializeField] float yRange = 5f;
    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float controlPitchFactor = -15f;
    [SerializeField] float positionYawFactor = -2f;
    [SerializeField] float controlRollFactor = -20f;
    [SerializeField] float rotationFactor = 1f;
    float yThrow;
    float xThrow;


    void Start()
    {
        
    }

    private void OnEnable()
    {
        movement.Enable();
        fire.Enable();
    }

    private void OnDisable()
    {
        movement.Disable();
        fire.Disable();
    }
    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
        ProcessFiring();
    }
        void ProcessTranslation()
    {
        yThrow = movement.ReadValue<Vector2>().y;
        xThrow = movement.ReadValue<Vector2>().x;

        float yOffset = yThrow * Time.deltaTime * xySpeed;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        float xOffset = xThrow * Time.deltaTime * xySpeed;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        transform.localPosition = new Vector3
            (clampedXPos, clampedYPos, transform.localPosition.z);
    }

    void ProcessRotation()
    {

        float pitchDuetoPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDuetoControlThrow = yThrow * controlPitchFactor;

        float pitch = pitchDuetoPosition + pitchDuetoControlThrow;

        float yaw = transform.localPosition.x + positionYawFactor; 
        
        float roll = xThrow * controlRollFactor; 

        Quaternion targetRotation = Quaternion.Euler(pitch, yaw, roll);
        transform.localRotation = Quaternion.RotateTowards(transform.localRotation, targetRotation, rotationFactor);
    }
    void ProcessFiring()
    {
        //if pushing fire button
        // then print "shooting"
        // else don't print "shooting"

        if (fire.ReadValue<float>() > 0.1)
        {
            Debug.Log("Shooting");
        }
        else
        {
            Debug.Log("Not Shooting");
        }

    } 
}
