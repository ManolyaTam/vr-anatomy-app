using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections;

public class VRGrabber : XRGrabInteractable
{
    //private Vector3 originalPosition;
    //private Quaternion originalRotation;
    //private Vector3 originalScale;
    //private bool isReturning = false;

    private void Start()
    {
        if (!attachTransform)
        {
            GameObject attachPoint = new GameObject("Offset Grab Pivot");
            attachPoint.transform.SetParent(transform, false);
            attachTransform = attachPoint.transform;
        }

        // Store the original position, rotation, and scale at the start
        //originalPosition = transform.position;
        //originalRotation = transform.rotation;
        //originalScale = transform.localScale;
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        attachTransform.position = args.interactorObject.transform.position;
        attachTransform.rotation = args.interactorObject.transform.rotation;

        base.OnSelectEntered(args);
    }
}
