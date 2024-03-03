using UnityEngine;
using System;


// ShowCanvasOnRaycastHit
public class ShowCanvas : MonoBehaviour
{
    public GameObject canvas;
    private LineRenderer controllerLineRenderer;
    //private LineRenderer rightControllerLineRenderer;
    //public GameObject LeftVRController;
    public GameObject RightVRController;

    private void Update()
    {
        RaycastHit hitLeft, hitRight;
        controllerLineRenderer = RightVRController.GetComponent<LineRenderer>();

        // Check if the VR controller's line intersects with the model's collider
        RaycastHit hit;
        if (Physics.Raycast(controllerLineRenderer.transform.position, controllerLineRenderer.transform.forward, out hit))
        {
            if (hit.collider.gameObject == gameObject)
            {
                Debug.Log(gameObject);
                // Show the canvas when the VR controller's line intersects with the model
                canvas.SetActive(true);
                return; // Exit the update loop to prevent canvas from being hidden immediately
            }
        }

        // Hide the canvas when the VR controller's line does not intersect with the model
        canvas.SetActive(false);
    }
}
