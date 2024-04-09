using UnityEngine;
using System;

public class ShowCanvas : MonoBehaviour
{
    public GameObject panel;
    //public GameObject VRController; // Reference to the VR controller
    //private float distanceThreshold = 2f; // Distance threshold to show the canvas
    private void Start()
    {
        panel.SetActive(false);
    }
    public void ShowCanvasPanel()
    {
        // Calculate the distance between the object and the VR controller
        //Vector3 offset = VRController.transform.position - transform.position;
        //float distance = offset.magnitude;

        // Show the canvas if the distance is less than the threshold
        //if (distance <= distanceThreshold)
        //{
        //    canvas.SetActive(true);
        //}
        panel.SetActive(true);
    }
    public void HideCanvasPanel()
    {
        panel.SetActive(false);
    }
}