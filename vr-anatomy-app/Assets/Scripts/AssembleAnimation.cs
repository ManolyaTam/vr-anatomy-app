//using UnityEngine;

//public class AssembleAnimation : MonoBehaviour
//{
//    [System.Serializable]
//    public class Part
//    {
//        public Transform partTransform;
//        [HideInInspector] public Vector3 initialLocalPosition;
//        [HideInInspector] public Quaternion initialLocalRotation;
//    }

//    public Part[] parts;
//    public float animationDuration = 2.0f;
//    public AnimationCurve animationCurve;

//    private Vector3[] finalLocalPositions;
//    private Quaternion[] finalLocalRotations;
//    private float startTime;

//    void Start()
//    {
//        finalLocalPositions = new Vector3[parts.Length];
//        finalLocalRotations = new Quaternion[parts.Length];

//        for (int i = 0; i < parts.Length; i++)
//        {
//            // Capture the initial local position and rotation
//            parts[i].initialLocalPosition = parts[i].partTransform.localPosition;
//            parts[i].initialLocalRotation = parts[i].partTransform.localRotation;

//            // Set the final local position and rotation
//            finalLocalPositions[i] = Vector3.zero; // Final position is (0, 0, 0) relative to parent
//            finalLocalRotations[i] = Quaternion.identity; // Final rotation is zero rotation relative to parent

//            // Optionally, you can move parts to an initial offset for animation
//            // parts[i].partTransform.localPosition += new Vector3(0, 0, 5); // Example offset
//            // parts[i].partTransform.localRotation = Quaternion.Euler(0, 0, 0); // Example initial rotation
//        }

//        startTime = Time.time;
//    }

//    void Update()
//    {
//        float t = (Time.time - startTime) / animationDuration;
//        t = Mathf.Clamp01(t);
//        float curvedT = animationCurve.Evaluate(t);

//        for (int i = 0; i < parts.Length; i++)
//        {
//            parts[i].partTransform.localPosition = Vector3.Lerp(parts[i].initialLocalPosition, finalLocalPositions[i], curvedT);
//        }
//    }
//}

//using UnityEngine;

//public class AssembleAnimation : MonoBehaviour, IPartAssignable
//{
//    [System.Serializable]
//    public class Part
//    {
//        public Transform partTransform;
//        [HideInInspector] public Vector3 initialLocalPosition;
//        [HideInInspector] public Quaternion initialLocalRotation;
//    }

//    public Part[] parts;
//    public float animationDuration = 2.0f;
//    public AnimationCurve animationCurve;

//    private Vector3[] separatedPositions;
//    private Quaternion[] separatedRotations;
//    private Vector3[] initialLocalPositions;
//    private Quaternion[] initialLocalRotations;

//    private bool isSeparating = false;
//    private bool isAnimating = false;
//    private float startTime;

//    void Start()
//    {
//        separatedPositions = new Vector3[parts.Length];
//        separatedRotations = new Quaternion[parts.Length];
//        initialLocalPositions = new Vector3[parts.Length];
//        initialLocalRotations = new Quaternion[parts.Length];

//        Debug.Log("Chest " + parts[0].partTransform.localPosition);

//        for (int i = 0; i < parts.Length; i++)
//        {
//            Capture the initial local position and rotation
//           initialLocalPositions[i] = parts[i].partTransform.localPosition;
//            initialLocalRotations[i] = parts[i].partTransform.localRotation;

//            Set the separated position and rotation
//            separatedPositions[i] = GetUniqueSeparatedPosition(i);
//            separatedPositions[i] = GetUniqueSeparatedPosition(i, parts[i].partTransform);

//            separatedRotations[i] = parts[i].partTransform.localRotation;
//            separatedRotations[i] = Quaternion.Euler(GetUniqueSeparatedRotation(i));
//        }
//    }

//    public void AssignParts(Transform[] parts)
//    {
//        this.parts = new Part[parts.Length];
//        for (int i = 0; i < parts.Length; i++)
//        {
//            this.parts[i] = new Part { partTransform = parts[i] };
//        }
//    }

//    void Update()
//    {
//        if (isAnimating)
//        {
//            float t = (Time.time - startTime) / animationDuration;
//            t = Mathf.Clamp01(t);
//            float curvedT = animationCurve.Evaluate(t);

//            for (int i = 0; i < parts.Length; i++)
//            {
//                if (isSeparating)
//                {
//                    parts[i].partTransform.localPosition = Vector3.Lerp(initialLocalPositions[i], separatedPositions[i], curvedT);
//                    parts[i].partTransform.localRotation = Quaternion.Lerp(initialLocalRotations[i], separatedRotations[i], curvedT);
//                }
//                else
//                {
//                    parts[i].partTransform.localPosition = Vector3.Lerp(separatedPositions[i], initialLocalPositions[i], curvedT);
//                    parts[i].partTransform.localRotation = Quaternion.Lerp(separatedRotations[i], initialLocalRotations[i], curvedT);
//                }
//            }

//            if (t >= 1.0f)
//            {
//                isAnimating = false;
//            }
//        }
//    }

//    public void SeparateParts()
//    {
//        if (!isAnimating)
//        {
//            isSeparating = true;
//            startTime = Time.time;
//            isAnimating = true;
//        }
//        Debug.Log("After Chest " + parts[0].partTransform.localPosition);
//    }

//    public void CombineParts()
//    {
//        if (!isAnimating)
//        {
//            isSeparating = false;
//            startTime = Time.time;
//            isAnimating = true;
//        }
//    }
//    Vector3 GetUniqueSeparatedPosition(int index)
//    {
//        Generate positions in a circular pattern around the origin
//        float angle = index * Mathf.PI * 2 / parts.Length;
//        float radius = 0.5f;
//        return new Vector3(Mathf.Cos(angle) * radius, 0, Mathf.Sin(angle) * radius);
//    }

//    Vector3 GetUniqueSeparatedPosition(int index, Transform partTransform)
//    {
//        Generate positions in a circular pattern around the origin
//        float angle = index * Mathf.PI * 2 / parts.Length;
//        float radius = 0.5f;
//        Vector3 circularPosition = new Vector3(Mathf.Cos(angle) * radius, 0, Mathf.Sin(angle) * radius);

//        Convert circular position to local space relative to the part
//        Vector3 localCircularPosition = partTransform.InverseTransformDirection(circularPosition);

//        Return the initial position plus the local circular position
//        return partTransform.localPosition + localCircularPosition;
//    }
//    public void ResetParts()
//    {
//        for (int i = 0; i < parts.Length; i++)
//        {
//            parts[i].partTransform.localPosition = initialLocalPositions[i];
//            parts[i].partTransform.localRotation = initialLocalRotations[i];
//        }

//        Stop any ongoing animation
//        isAnimating = false;
//    }
//}

using UnityEngine;

public class AssembleAnimation : MonoBehaviour, IPartAssignable
{
    public float separationDistance = 1.0f; // Default separation distance

    [System.Serializable]
    public class Part
    {
        public Transform partTransform;
        [HideInInspector] public Vector3 initialLocalPosition;
        [HideInInspector] public Quaternion initialLocalRotation;
    }

    public Part[] parts;
    public float animationDuration = 2.0f;
    public AnimationCurve animationCurve;

    private Vector3[] separatedPositions;
    private Quaternion[] separatedRotations;
    private Vector3[] initialLocalPositions;
    private Quaternion[] initialLocalRotations;

    private bool isSeparating = false;
    private bool isAnimating = false;
    private float startTime;

    void Start()
    {
        separatedPositions = new Vector3[parts.Length];
        separatedRotations = new Quaternion[parts.Length];
        initialLocalPositions = new Vector3[parts.Length];
        initialLocalRotations = new Quaternion[parts.Length];

        for (int i = 0; i < parts.Length; i++)
        {
            // Capture the initial local position and rotation
            initialLocalPositions[i] = parts[i].partTransform.localPosition;
            initialLocalRotations[i] = parts[i].partTransform.localRotation;

            // Set the separated position and rotation
            separatedPositions[i] = GetUniqueSeparatedPosition(i);
            separatedRotations[i] = parts[i].partTransform.localRotation;
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

    void Update()
    {
        if (isAnimating)
        {
            float t = (Time.time - startTime) / animationDuration;
            t = Mathf.Clamp01(t);
            float curvedT = animationCurve.Evaluate(t);

            for (int i = 0; i < parts.Length; i++)
            {
                if (isSeparating)
                {
                    parts[i].partTransform.localPosition = Vector3.Lerp(initialLocalPositions[i], separatedPositions[i], curvedT);
                }
                else
                {
                    parts[i].partTransform.localPosition = Vector3.Lerp(separatedPositions[i], initialLocalPositions[i], curvedT);
                }
            }

            if (t >= 1.0f)
            {
                isAnimating = false;
            }
        }
    }

    public void SeparateParts()
    {
        if (!isAnimating)
        {
            isSeparating = true;
            startTime = Time.time;
            isAnimating = true;
        }
    }

    public void CombineParts()
    {
        if (!isAnimating)
        {
            isSeparating = false;
            startTime = Time.time;
            isAnimating = true;
        }
    }

    Vector3 GetUniqueSeparatedPosition(int index)
    {
        // Generate positions in a circular pattern around the origin
        float angle = index * Mathf.PI * 2 / parts.Length;
        float radius = separationDistance; // Use the provided separation distance
        return new Vector3(Mathf.Cos(angle) * radius, 0, Mathf.Sin(angle) * radius);
    }

    public void ResetParts()
    {
        for (int i = 0; i < parts.Length; i++)
        {
            parts[i].partTransform.localPosition = initialLocalPositions[i];
            parts[i].partTransform.localRotation = initialLocalRotations[i];
        }

        // Stop any ongoing animation
        isAnimating = false;
    }
}
