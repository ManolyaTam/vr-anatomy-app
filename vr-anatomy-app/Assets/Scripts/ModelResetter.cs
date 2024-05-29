using UnityEngine;
using System.Collections.Generic;

public class ModelResetter : MonoBehaviour, IPartAssignable
{
    [System.Serializable]
    public class Part
    {
        public Transform partTransform;
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
        }
    }

    public void AssignParts(Transform[] parts)
    {
        this.parts = new Part[parts.Length];
        for (int i = 0; i < parts.Length; i++)
        {
            this.parts[i] = new Part { partTransform = parts[i] };
        }
    }

    public void ResetToInitialState()
    {
        for (int i = 0; i < parts.Length; i++)
        {
            parts[i].partTransform.localPosition = initialLocalPositions[i];
            parts[i].partTransform.localRotation = initialLocalRotations[i];
        }
    }
}
