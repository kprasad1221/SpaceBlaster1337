using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [Tooltip("In m^-1s")] [SerializeField] float xSpeed = 4f;
    [Tooltip("In m^-1s")] [SerializeField] float ySpeed = 4f;
    [Tooltip("In m")][SerializeField] float xRange = 3.5f;
    [Tooltip("In m")] [SerializeField] float yRangeMin = -1f;
    [Tooltip("In m")] [SerializeField] float yRangeMax = 4f;

    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float controlPitchFactor = -20f;
    [SerializeField] float positionYawFactor = 5f;
    [SerializeField] float controlRollFactor = -20f;

    float xThrow, yThrow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    private void ProcessTranslation()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float xOffsetThisFrame = xSpeed * xThrow * Time.deltaTime;
        float yOffsetThisFrame = ySpeed * yThrow * Time.deltaTime;

        float rawXOffset = transform.localPosition.x + xOffsetThisFrame;
        float clampXOffset = Mathf.Clamp(rawXOffset, -xRange, xRange);
        float rawYOffset = transform.localPosition.y + yOffsetThisFrame;
        float clampYOffset = Mathf.Clamp(rawYOffset, yRangeMin, yRangeMax);

        transform.localPosition = new Vector3(clampXOffset, clampYOffset, transform.localPosition.z);
    }

    private void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float positionDueToControl = yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + positionDueToControl;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }
}
