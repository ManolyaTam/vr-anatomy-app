using UnityEngine;

//[RequireComponent(typeof(AssembleAnimation))]
//public class AutoAssignParts : MonoBehaviour
//{
//    //private void Awake()
//    //{
//    //    AssembleAnimation assembleAnimation = GetComponent<AssembleAnimation>();

//    //    // Get all child transforms
//    //    Transform[] childTransforms = GetComponentsInChildren<Transform>();

//    //    // Initialize the parts array with the correct length
//    //    assembleAnimation.parts = new AssembleAnimation.Part[childTransforms.Length - 1]; // Exclude the parent itself

//    //    // Populate the parts array with child transforms
//    //    int index = 0;
//    //    foreach (Transform child in childTransforms)
//    //    {
//    //        if (child == transform) continue; // Skip the parent object

//    //        assembleAnimation.parts[index] = new AssembleAnimation.Part
//    //        {
//    //            partTransform = child
//    //        };
//    //        index++;
//    //    }
//    //}

//    private void Awake()
//    {
//        AssembleAnimation assembleAnimation = GetComponent<AssembleAnimation>();

//        // Get only direct child transforms
//        Transform[] childTransforms = GetComponentsInChildren<Transform>(true); // true to include inactive children
//        int directChildCount = 0;

//        // First, count only direct children
//        foreach (Transform child in childTransforms)
//        {
//            if (child.parent == transform) // Check if the immediate parent is the current GameObject
//            {
//                directChildCount++;
//            }
//        }

//        // Initialize the parts array with the correct length
//        assembleAnimation.parts = new AssembleAnimation.Part[directChildCount];

//        // Populate the parts array with only direct child transforms
//        int index = 0;
//        foreach (Transform child in childTransforms)
//        {
//            if (child.parent == transform) // Check if the immediate parent is the current GameObject
//            {
//                assembleAnimation.parts[index] = new AssembleAnimation.Part
//                {
//                    partTransform = child
//                };
//                index++;
//            }
//        }
//    }
//}

[RequireComponent(typeof(IPartAssignable))]
public class AutoAssignParts : MonoBehaviour
{
    private void Awake()
    {
        IPartAssignable partAssignable = GetComponent<IPartAssignable>();

        // Get only direct child transforms
        Transform[] childTransforms = GetComponentsInChildren<Transform>(true); // true to include inactive children
        int directChildCount = 0;

        // First, count only direct children
        foreach (Transform child in childTransforms)
        {
            if (child.parent == transform) // Check if the immediate parent is the current GameObject
            {
                directChildCount++;
            }
        }

        // Collect the direct child transforms
        Transform[] directChildTransforms = new Transform[directChildCount];
        int index = 0;
        foreach (Transform child in childTransforms)
        {
            if (child.parent == transform) // Check if the immediate parent is the current GameObject
            {
                directChildTransforms[index] = child;
                index++;
            }
        }

        // Assign parts using the interface method
        partAssignable.AssignParts(directChildTransforms);
    }
}