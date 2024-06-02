using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;

[RequireComponent(typeof(XRSimpleInteractable))]
[RequireComponent(typeof(Rigidbody))]
public class HoverLabelAndOutline : MonoBehaviour
{
    private XRSimpleInteractable interactable;
    private Outline outline;
    private Rigidbody rb;
    public TextMeshProUGUI label;
    public GameObject panel;


    // Public variable to set the outline color in the inspector
    public Color outlineColor = Color.yellow;

    void Awake()
    {
        interactable = GetComponent<XRSimpleInteractable>();
        outline = GetComponent<Outline>();
        rb = GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.useGravity = false;
            rb.isKinematic = true;
        }
        if (outline == null)
        {
            outline = gameObject.AddComponent<Outline>();
        }

        // Set the initial color of the outline
        outline.OutlineColor = outlineColor;

        // Enable properties on XRGrabInteractable
        if (interactable != null)
        {
            interactable.onHoverEntered.AddListener(OnHoverEnter);
            interactable.onHoverExited.AddListener(OnHoverExit);
        }

        outline.enabled = false; // Make sure the outline is initially off
    }

    private void OnHoverEnter(XRBaseInteractor interactor)
    {

        // Enable outline on select enter
        if (outline != null)
        {
            outline.OutlineColor = outlineColor; // Apply the color
            outline.enabled = true;
        }
        if(panel != null && label != null)
        {
            panel.SetActive(true);
            label.text = gameObject.name;
        }
    }

    private void OnHoverExit(XRBaseInteractor interactor)
    {

        // Disable outline on select exit
        if (outline != null)
        {
            outline.enabled = false;
        }
        if (panel != null && label != null)
        {
            panel.SetActive(false);
            label.text = "";
        } else
        {
            Debug.LogError("lable or panel not passed in gameobject " + gameObject.name);
        }
    }

    private void OnDestroy()
    {
        if (interactable != null)
        {
            interactable.onSelectEntered.RemoveListener(OnHoverEnter);
            interactable.onSelectExited.RemoveListener(OnHoverExit);
        }
    }
}
