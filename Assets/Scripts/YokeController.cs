using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class YokeController : MonoBehaviour
{
    [Header("Control Surface References")]
    [SerializeField] public Transform elevator;       // Tail elevator
    [SerializeField] public Transform leftAileron;    // Left wing aileron
    [SerializeField] public Transform rightAileron;   // Right wing aileron

    [Header("Yoke Settings")]
    [SerializeField] private Transform yokeBase; // The static base used to compare rotation
    [SerializeField] private float maxPitchAngle = 15f;
    [SerializeField] private float maxRollAngle = 20f;
    [SerializeField] private float controlSensitivity = 1f;

    private Quaternion initialYokeLocalRotation;

    private void Start()
    {
        // Record the initial local rotation of the yoke for comparison
        if (yokeBase == null)
        {
            Debug.LogError("Yoke Base is not assigned!");
            return;
        }

        initialYokeLocalRotation = transform.localRotation;
    }

    private void Update()
    {
        ApplyYokeRotation();
    }

    private void ApplyYokeRotation()
    {
        // Calculate local rotation difference from initial state
        Quaternion deltaRotation = Quaternion.Inverse(initialYokeLocalRotation) * transform.localRotation;
        Vector3 deltaEuler = deltaRotation.eulerAngles;

        // Normalize to -180 to 180
        deltaEuler.x = NormalizeAngle(deltaEuler.x);
        deltaEuler.z = NormalizeAngle(deltaEuler.z);

        float pitchInput = Mathf.Clamp(deltaEuler.x / maxPitchAngle, -1f, 1f) * controlSensitivity;
        float rollInput = Mathf.Clamp(deltaEuler.z / maxRollAngle, -1f, 1f) * controlSensitivity;

        // Apply to elevator (pitch)
        if (elevator != null)
        {
            float elevatorDeflection = -pitchInput * maxPitchAngle; // Invert to match plane convention
            elevator.localRotation = Quaternion.Euler(elevatorDeflection, 0f, 0f);
        }

        // Apply to ailerons (roll)
        if (leftAileron != null)
        {
            float aileronDeflection = rollInput * maxRollAngle;
            leftAileron.localRotation = Quaternion.Euler(-aileronDeflection, 0f, 0f); // Down when rolling right
        }

        if (rightAileron != null)
        {
            float aileronDeflection = rollInput * maxRollAngle;
            rightAileron.localRotation = Quaternion.Euler(aileronDeflection, 0f, 0f); // Up when rolling right
        }
    }

    private float NormalizeAngle(float angle)
    {
        if (angle > 180f) angle -= 360f;
        return angle;
    }
}
