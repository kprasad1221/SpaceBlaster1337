using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [Header("General")]
    [Tooltip("In m^-1s")] [SerializeField] float xControlSpeed = 4f;
    [Tooltip("In m^-1s")] [SerializeField] float yControlSpeed = 4f;
    [Tooltip("In m")][SerializeField] float xRange = 3.5f;
    [Tooltip("In m")] [SerializeField] float yRangeMin = -1f;
    [Tooltip("In m")] [SerializeField] float yRangeMax = 4f;

    [SerializeField] GameObject[] guns;

    [Header("Screen Position Based")]
    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float positionYawFactor = 5f;

    [Header("Control Based")]
    [SerializeField] float controlPitchFactor = -20f;
    [SerializeField] float controlRollFactor = -20f;

    float xThrow, yThrow;
    bool isControlsEnabled;

    // Start is called before the first frame update
    void Start()
    {
        isControlsEnabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isControlsEnabled)
        {
            ProcessTranslation();
            ProcessRotation();
            ProcessFiring();
        }
    }

    private void ProcessTranslation()
    {

        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        float xOffsetThisFrame = xControlSpeed * xThrow * Time.deltaTime;
        float yOffsetThisFrame = yControlSpeed * yThrow * Time.deltaTime;

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

    void OnPlayerDeath() //called by string reference in PlayerCollisionHandler.cs
    {
        print("Controls Frozen");
        isControlsEnabled = false;
    }

    private void ProcessFiring()
    {
        if(CrossPlatformInputManager.GetButton("Fire"))
        {
            FireGuns();
        }
        else
        {
            CeaseGuns();
        }
    }

    private void FireGuns()
    {
        foreach (GameObject gun in guns)
        {
            gun.SetActive(true);
        }
    }

    private void CeaseGuns()
    {
        foreach (GameObject gun in guns)
        {
            gun.SetActive(false);
        }
    }
}
