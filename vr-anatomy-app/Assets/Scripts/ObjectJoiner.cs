using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ObjectJoiner : MonoBehaviour
{
    public Transform snapPointObject1; // Snap point on the first object
    public Transform snapPointObject2; // Snap point on the second object
    public float snapDistanceThreshold = 0.1f; // Maximum distance for snapping

    private bool isJoined = false; // Flag to track if the objects are joined

    private void Update()
    {
        // Check if the objects are currently joined
        if (!isJoined) // Check if the objects are not joined
        {
            // If the objects are not currently joined, check for join conditions
            CheckForJoin();
        }
    }

    private void CheckForJoin()
    {
        // Check if the snap points of both objects are close to each other
        if (Vector3.Distance(snapPointObject1.position, snapPointObject2.position) <= snapDistanceThreshold)
        {
            // Join the objects
            JoinObjects();
            isJoined = true; // Mark the objects as joined
        }
    }

    private void JoinObjects()
    {
        // Disable rigidbodies 
        Rigidbody rb1 = transform.GetComponent<Rigidbody>();
        //if (rb1 != null)
        //{
        //    rb1.isKinematic = true; 
        //}

        // Disable colliders if necessary
        BoxCollider collider1 = transform.GetComponent<BoxCollider>();
        if (collider1 != null)
        {
            collider1.enabled = false;
        }

        // Remove XR Grabbable component
        XRGrabInteractable grabbable1 = transform.GetComponent<XRGrabInteractable>();
        if (grabbable1 != null)
        {
            Destroy(grabbable1);
        }

        // Destroy the rigidbody component
        Destroy(rb1);

        // Destroy the collider component
        Destroy(collider1);

        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
    }
}
