using UnityEngine;

[RequireComponent(typeof(AssembleAnimation))]
public class AutoAssignParts : MonoBehaviour
{
    private void Awake()
    {
        AssembleAnimation assembleAnimation = GetComponent<AssembleAnimation>();

        // Get all child transforms
        Transform[] childTransforms = GetComponentsInChildren<Transform>();

        // Initialize the parts array with the correct length
        assembleAnimation.parts = new AssembleAnimation.Part[childTransforms.Length - 1]; // Exclude the parent itself

        // Populate the parts array with child transforms
        int index = 0;
        foreach (Transform child in childTransforms)
        {
            if (child == transform) continue; // Skip the parent object

            assembleAnimation.parts[index] = new AssembleAnimation.Part
            {
                partTransform = child
            };
            index++;
        }
    }
}
