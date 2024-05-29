using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PartSelection : MonoBehaviour
{
    public Transform controllerTransform; // Reference to the VR controller transform
    public LayerMask selectionMask; // Layer mask for selectable objects
    private XRSimpleInteractable interactable;


    void Start()
    {
        interactable = GetComponent<XRSimpleInteractable>();
        //Add a listener to the onSelectEntered event
        interactable.onSelectEntered.AddListener(OnSelectEnter);
        interactable.onSelectExited.AddListener(OnSelectExit);
    }

    //void Update()
    //{
    //    // Cast a ray from the controller
    //    RaycastHit hit;
    //    if (Physics.Raycast(controllerTransform.position, controllerTransform.forward, out hit, Mathf.Infinity, selectionMask))
    //    {
    //        GameObject hitObject = hit.collider.gameObject;

    //        if (hitObject)
    //        {
    //            Debug.Log(hitObject.name);
    //            PartSelector.selected = hitObject; 
    //        }
    //    }
    //    //else
    //    //{
    //    //    // If no object is hit, clear the selected object
    //    //    ClearSelectedObject();
    //    //}
    //}
    //public void SetSelected()
    //{
    //    PartSelector.selected = gameObject;
    //    Debug.Log($"{gameObject.name} Selected");

    //    // Check if the object has an outline component
    //    Outline outline = gameObject.GetComponent<Outline>();

    //    // If outline component exists, enable it
    //    if (outline != null)
    //    {
    //        outline.enabled = true;
    //    }
    //    else
    //    {
    //        Debug.LogError("Outline component not found on selected object.");
    //    }
    //}

    //public void OnNotSelect()
    //{
    //    // Check if the object has an outline component
    //    Outline outline = gameObject.GetComponent<Outline>();

    //    // If outline component exists, enable it
    //    if (outline != null)
    //    {
    //        outline.enabled = false;
    //    }
    //}

    void OnSelectEnter(XRBaseInteractor interactor)
    {
        PartSelector.selected = gameObject;
        Debug.Log($"{gameObject.name} Selected");

        // Check if the object has an outline component
        Outline outline = gameObject.GetComponent<Outline>();

        // If outline component exists, enable it
        if (outline != null)
        {
            outline.enabled = true;
        }
        else
        {
            Debug.LogError("Outline component not found on selected object.");
        }
    }
    void OnSelectExit(XRBaseInteractor interactor)
    {
        Debug.Log($"{gameObject.name} Not Selected");

        // Check if the object has an outline component
        Outline outline = gameObject.GetComponent<Outline>();

        // If outline component exists, enable it
        if (outline != null)
        {
            outline.enabled = false;
        }
    }
}
