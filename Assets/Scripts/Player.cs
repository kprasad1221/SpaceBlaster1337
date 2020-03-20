using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [Tooltip("In m^-1s")] [SerializeField] float xSpeed = 4f;
    [SerializeField] float xRange = 3.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffsetThisFrame = xSpeed * horizontalThrow * Time.deltaTime;
        Debug.Log("Horizontal Throw:" + horizontalThrow);
        Debug.Log("xOffset:" + xOffsetThisFrame);
        
        float rawXOffset = transform.localPosition.x + xOffsetThisFrame;
        float clampXOffset = Mathf.Clamp(rawXOffset, -xRange, xRange);
        transform.localPosition = new Vector3(clampXOffset, transform.localPosition.y, transform.localPosition.z);
    }
}
