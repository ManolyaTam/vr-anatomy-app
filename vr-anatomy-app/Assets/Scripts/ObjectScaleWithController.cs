using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScaleWithController : MonoBehaviour
{
    public GameObject objectScaleWithController;
    public float scaleSpeed = 0.1f; // Adjust as needed
    public float minScale = 8f; // Minimum scale limit
    public float maxScale = 16f; // Maximum scale limit

    void Update()
    {
        // Get input from the joystick (vertical axis)
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate scale amount based on input
        float scaleAmount = 1.0f + verticalInput * scaleSpeed;

        // Apply scale with limits
        Vector3 newScale = objectScaleWithController.transform.localScale * scaleAmount;
        newScale.x = Mathf.Clamp(newScale.x, minScale, maxScale);
        newScale.y = Mathf.Clamp(newScale.y, minScale, maxScale);
        newScale.z = Mathf.Clamp(newScale.z, minScale, maxScale);
        objectScaleWithController.transform.localScale = newScale;
    }
}
