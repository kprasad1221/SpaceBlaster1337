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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffsetThisFrame = xSpeed * horizontalThrow * Time.deltaTime;
        float verticalThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffsetThisFrame = ySpeed * verticalThrow * Time.deltaTime;
      //  Debug.Log("Horizontal Throw:" + horizontalThrow);
      //  Debug.Log("xOffset:" + xOffsetThisFrame);
        
        float rawXOffset = transform.localPosition.x + xOffsetThisFrame;
        float clampXOffset = Mathf.Clamp(rawXOffset, -xRange, xRange);
        float rawYOffset = transform.localPosition.y + yOffsetThisFrame;
        float clampYOffset = Mathf.Clamp(rawYOffset, yRangeMin, yRangeMax);
        transform.localPosition = new Vector3(clampXOffset, clampYOffset, transform.localPosition.z);
    }
}
