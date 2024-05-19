using UnityEngine;

public class AssembleAnimation : MonoBehaviour
{
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

    private Vector3[] finalLocalPositions;
    private Quaternion[] finalLocalRotations;
    private float startTime;

    void Start()
    {
        finalLocalPositions = new Vector3[parts.Length];
        finalLocalRotations = new Quaternion[parts.Length];

        for (int i = 0; i < parts.Length; i++)
        {
            // Capture the initial local position and rotation
            parts[i].initialLocalPosition = parts[i].partTransform.localPosition;
            parts[i].initialLocalRotation = parts[i].partTransform.localRotation;

            // Set the final local position and rotation
            finalLocalPositions[i] = Vector3.zero; // Final position is (0, 0, 0) relative to parent
            finalLocalRotations[i] = Quaternion.identity; // Final rotation is zero rotation relative to parent

            // Optionally, you can move parts to an initial offset for animation
            // parts[i].partTransform.localPosition += new Vector3(0, 0, 5); // Example offset
            // parts[i].partTransform.localRotation = Quaternion.Euler(0, 0, 0); // Example initial rotation
        }

        startTime = Time.time;
    }

    void Update()
    {
        float t = (Time.time - startTime) / animationDuration;
        t = Mathf.Clamp01(t);
        float curvedT = animationCurve.Evaluate(t);

        for (int i = 0; i < parts.Length; i++)
        {
            parts[i].partTransform.localPosition = Vector3.Lerp(parts[i].initialLocalPosition, finalLocalPositions[i], curvedT);
            //parts[i].partTransform.localRotation = Quaternion.Slerp(parts[i].initialLocalRotation, finalLocalRotations[i], curvedT);
        }
    }
}
