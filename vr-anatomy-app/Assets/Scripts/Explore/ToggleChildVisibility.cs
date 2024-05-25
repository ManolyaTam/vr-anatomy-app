using UnityEngine;

public class ToggleChildVisibility : MonoBehaviour
{
    public void ShowOnlyChild(string childName)
    {
        gameObject.SetActive(true);
        foreach (Transform child in transform)
        {
            if (child.gameObject.name.Equals(childName))
            {
                child.gameObject.SetActive(true);
            }
            else
            {
                // Disable other children
                child.gameObject.SetActive(false);
            }
        }
    }

    public void ShowParentAgain()
    {
        gameObject.SetActive(true);
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }
    }
    public void HideOnlyChild(string childName)
    {
        foreach (Transform child in transform)
        {
            if (child.gameObject.name.Equals(childName))
            {
                child.gameObject.SetActive(false);
            }
        }
    }
}
