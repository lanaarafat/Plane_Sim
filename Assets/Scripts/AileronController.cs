using UnityEngine;

public class AileronController : MonoBehaviour
{
    [Header("Aileron References")]
    [SerializeField] public Transform leftAileron;
    [SerializeField] public Transform rightAileron;

    [Header("VR Yoke")]
    [SerializeField] public Transform vrYoke; // The physical yoke object

    [Header("Aileron Settings")]
    [SerializeField] private float maxDeflection = 15f; // Max angle in degrees
    [SerializeField] private float smoothing = 5f;

    [Header("Yoke Settings")]
    [Tooltip("Z-axis rotation range in degrees (e.g., -45 to +45)")]
    [SerializeField] private float maxYokeRotation = 45f;

    private float currentInput = 0f;

    private void Update()
    {
        UpdateAileronInputFromYoke();
        ApplyAileronDeflection();
    }

    private void UpdateAileronInputFromYoke()
    {
        if (vrYoke == null) return;

        // Get local Z rotation (turning the yoke like a steering wheel)
        float zRotation = vrYoke.localEulerAngles.z;
        if (zRotation > 180f) zRotation -= 360f; // Convert to -180 to +180

        float targetInput = Mathf.Clamp(zRotation / maxYokeRotation, -1f, 1f);
        currentInput = Mathf.Lerp(currentInput, targetInput, Time.deltaTime * smoothing);
    }

    private void ApplyAileronDeflection()
    {
        if (leftAileron != null)
            leftAileron.localRotation = Quaternion.Euler(-currentInput * maxDeflection, 0f, 0f);

        if (rightAileron != null)
            rightAileron.localRotation = Quaternion.Euler(currentInput * maxDeflection, 0f, 0f);
    }
}
