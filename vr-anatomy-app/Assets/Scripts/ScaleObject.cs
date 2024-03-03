using UnityEngine;

public class scaleObject : MonoBehaviour
{
    public GameObject Object;

    private bool _ZoomIn;
    private bool _ZoomOut;

    // Object scale speed
    public float Scale = 0.1f;

    // Minimum and maximum scales for the object
    private float MinScale = 0.9f;
    private float MaxScale = 1.9f;

    // Update is called once per frame
    void Update()
    {
        if (_ZoomIn)
        {
            // Check if the object is not already at the maximum scale
            if (Object.transform.localScale.x < MaxScale)
            {
                // Make the object bigger
                Object.transform.localScale += new Vector3(Scale, Scale, Scale);
            }
        }

        if (_ZoomOut)
        {
            // Check if the object is not already at the minimum scale
            if (Object.transform.localScale.x > MinScale)
            {
                // Make the object smaller
                Object.transform.localScale -= new Vector3(Scale, Scale, Scale);
            }
        }
    }

    // Make object scaled big
    public void OnPressZoomIn()
    {
        _ZoomIn = true;
    }

    public void OnReleaseZoomIn()
    {
        _ZoomIn = false;
    }

    // Make object scaled small
    public void OnPressZoomOut()
    {
        _ZoomOut = true;
    }

    public void OnReleaseZoomOut()
    {
        _ZoomOut = false;
    }
}
