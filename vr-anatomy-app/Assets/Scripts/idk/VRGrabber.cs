using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections;

public class VRGrabber : XRGrabInteractable
{
    private Vector3 originalPosition;
    private Quaternion originalRotation;
    private Vector3 originalScale;
    private bool isReturning = false;

    private void Start()
    {
        if (!attachTransform)
        {
            GameObject attachPoint = new GameObject("Offset Grab Pivot");
            attachPoint.transform.SetParent(transform, false);
            attachTransform = attachPoint.transform;
        }

        // Store the original position, rotation, and scale at the start
        originalPosition = transform.position;
        originalRotation = transform.rotation;
        originalScale = transform.localScale;
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        attachTransform.position = args.interactorObject.transform.position;
        attachTransform.rotation = args.interactorObject.transform.rotation;

        base.OnSelectEntered(args);

        // Stop any returning animation if it's in progress
        //StopCoroutine(ReturnToOriginalTransform());
        //isReturning = false;
    }

    //protected override void OnSelectExited(SelectExitEventArgs args)
    //{
    //    base.OnSelectExited(args);

    //    // Start the coroutine to return to the original position, rotation, and scale
    //    StartCoroutine(ReturnToOriginalTransform());
    //}

    //private IEnumerator ReturnToOriginalTransform()
    //{
    //    isReturning = true;
    //    float duration = 1.0f; // Duration of the return animation
    //    float elapsedTime = 0f;

    //    Vector3 startingPosition = transform.position;
    //    Quaternion startingRotation = transform.rotation;
    //    Vector3 startingScale = transform.localScale;

    //    while (elapsedTime < duration)
    //    {
    //        // Interpolate position, rotation, and scale
    //        transform.position = Vector3.Lerp(startingPosition, originalPosition, elapsedTime / duration);
    //        transform.rotation = Quaternion.Lerp(startingRotation, originalRotation, elapsedTime / duration);
    //        transform.localScale = Vector3.Lerp(startingScale, originalScale, elapsedTime / duration);

    //        elapsedTime += Time.deltaTime;
    //        yield return null;
    //    }

    //    // Ensure the final position, rotation, and scale are set
    //    transform.position = originalPosition;
    //    transform.rotation = originalRotation;
    //    transform.localScale = originalScale;

    //    isReturning = false;
    //}
}
