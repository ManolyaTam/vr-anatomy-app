using UnityEngine;

public class ToggleObjectVisibility : MonoBehaviour
{
    public GameObject panelInfo;
    private BodyPart bodyPartScript;

    private void Start()
    {
        bodyPartScript = GameObject.FindObjectOfType<BodyPart>();
    }

    // Method to toggle visibility when the button is clicked
    public void Toggle_ObjectVisibility()
    {
        // Toggle the visibility of the object
        if (panelInfo.activeSelf == false)
        {
            bodyPartScript.ShowInfo();
        }
        else
        {
            bodyPartScript.HideInfo();
        }
    }
}
