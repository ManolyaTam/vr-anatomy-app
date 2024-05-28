using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PartSelector : MonoBehaviour
{
    public static GameObject selected; // Global variable to hold the selected part

    public void ShowParentWithChildren(GameObject parent)
    {
        if (parent == null) return;

        parent.SetActive(true);

        // Iterate through all children and set them active
        foreach (Transform child in parent.transform)
        {
            SetActiveRecursively(child.gameObject, true);
        }
    }

    // Helper method to set active state recursively
    private void SetActiveRecursively(GameObject obj, bool state)
    {
        obj.SetActive(state);
        foreach (Transform child in obj.transform)
        {
            SetActiveRecursively(child.gameObject, state);
        }
    }
}
