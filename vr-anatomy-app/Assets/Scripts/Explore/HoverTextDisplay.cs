using UnityEngine;
using TMPro;

public class HoverTextDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text textMeshPro;
    [SerializeField] private GameObject panel; // Required reference to the panel holding the TextMeshPro

    private Camera mainCamera; // Cache the main camera for efficiency
    private bool isHovered;

    private void Start()
    {
        mainCamera = Camera.main;
        if (!textMeshPro)
        {
            Debug.LogError("Missing TextMeshPro reference in HoverTextDisplay script on " + gameObject.name);
        }
        if (!panel)
        {
            Debug.LogError("Missing Panel reference in HoverTextDisplay script on " + gameObject.name);
        }
        panel.SetActive(false); // Hide the panel initially
    }

    private void Update()
    {
        if (!mainCamera)
        {
            mainCamera = Camera.main; // Recache if camera changes
            return;
        }

        // Raycast using VR specific input (replace with your VR input system's method)
        bool isVRHovering = VRRaycastForHover(); // Implement this function to check for VR controller hover

        if (isVRHovering) // Check for VR hover instead of mouse raycast
        {
            if (!isHovered)
            {
                isHovered = true;
                // Update text with current object name
                textMeshPro.text = gameObject.name;
                panel.SetActive(true); // Show the panel
                Debug.Log("Hovering over with VR controller: " + gameObject.name);
            }
        }
        else
        {
            // Object is no longer hovered (or mouse interaction), hide panel
            if (isHovered)
            {
                isHovered = false;
                panel.SetActive(false); // Hide the panel
                Debug.Log("No longer hovering with VR controller: " + gameObject.name);
            }
        }
    }

    // Function to implement VR specific raycast for hover detection (replace with your VR input system's method)
    private bool VRRaycastForHover()
    {
        // Implement your VR input system's logic to check if a VR controller is hovering over the object
        // This might involve checking for specific button presses or proximity to the object

        // Example (replace with your actual implementation):
        // return OVRInput.IsControllerTouching(OVRInput.Hand.Left); // Replace with your VR input system's method
        return false; // Placeholder until you implement VR specific hover detection
    }
}