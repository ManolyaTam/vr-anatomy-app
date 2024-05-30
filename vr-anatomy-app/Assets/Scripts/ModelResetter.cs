using UnityEngine;
using System.Collections.Generic;
using UnityEngine.XR.Interaction.Toolkit;

public class ModelResetter : MonoBehaviour, IPartAssignable
{
    [System.Serializable]
    public class Part
    {
        public Transform partTransform;
        public VRGrabber grabInteractable;
    }

    public Part[] parts;
    private Vector3[] initialLocalPositions;
    private Quaternion[] initialLocalRotations;

    void Start()
    {
        initialLocalPositions = new Vector3[parts.Length];
        initialLocalRotations = new Quaternion[parts.Length];

        for (int i = 0; i < parts.Length; i++)
        {
            // Capture the initial local position and rotation
            initialLocalPositions[i] = parts[i].partTransform.localPosition;
            initialLocalRotations[i] = parts[i].partTransform.localRotation;

            // Get the XRGrabInteractable component if it exists
            parts[i].grabInteractable = parts[i].partTransform.GetComponent<VRGrabber>();
        }
    }

    public void AssignParts(Transform[] parts)
    {
        this.parts = new Part[parts.Length];
        for (int i = 0; i < parts.Length; i++)
        {
            this.parts[i] = new Part { partTransform = parts[i] };
            this.parts[i].grabInteractable = parts[i].GetComponent<VRGrabber>();
        }
    }

    public void ResetToInitialState()
    {
        for (int i = 0; i < parts.Length; i++)
        {
            parts[i].partTransform.localPosition = initialLocalPositions[i];
            parts[i].partTransform.localRotation = initialLocalRotations[i];

            // Enable XRGrabInteractable if it exists
            if (parts[i].grabInteractable != null)
            {
                parts[i].grabInteractable.enabled = true;
            }

            // Reset join state if the object has ObjectJoiner component
            ObjectJoiner joiner = parts[i].partTransform?.GetComponent<ObjectJoiner>();
            if (joiner != null)
            {
                joiner.ResetJoinState();
            }
        }
    }
}