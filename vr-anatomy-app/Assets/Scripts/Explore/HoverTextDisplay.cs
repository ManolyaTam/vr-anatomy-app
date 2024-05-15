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

        // Add a log to test logging
        Debug.Log("Hello, World!");
    }

    private void Update()
    {
        if (!mainCamera)
        {
            mainCamera = Camera.main; // Recache if camera changes
            return;
        }

        // Raycast for hover detection (mouse or VR controller)
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            GameObject hitObject = hit.collider.gameObject;
            if (hitObject == gameObject) // Check if the hit object is the one we want to display hover text for
            {
                if (!isHovered)
                {
                    isHovered = true;
                    // Update text with current object name
                    textMeshPro.text = gameObject.name;
                    panel.SetActive(true); // Show the panel
                    Debug.Log("Hovering over: " + gameObject.name);
                }
            }
            else
            {
                // Object is no longer hovered, hide panel
                if (isHovered)
                {
                    isHovered = false;
                    panel.SetActive(false); // Hide the panel
                    Debug.Log("No longer hovering over: " + gameObject.name);
                }
            }
        }
        else
        {
            // No object hovered, hide panel
            if (isHovered)
            {
                isHovered = false;
                panel.SetActive(false); // Hide the panel
                Debug.Log("No object hovered.");
            }
        }
    }
}
