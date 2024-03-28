using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotateWithController : MonoBehaviour
{
    public GameObject objectRotateWithController;
    public float rotationSpeed = 50f;

    void Update()
    {
        // Get input from the joystick
        float horizontalInput = Input.GetAxis("Horizontal");

        // Calculate rotation amount based on input
        float rotationAmount = horizontalInput * rotationSpeed * Time.deltaTime;

        // Apply rotation to the object
        objectRotateWithController.transform.Rotate(Vector3.up, rotationAmount);
    }
}
