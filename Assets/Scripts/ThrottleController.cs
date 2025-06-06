using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ThrottleController : MonoBehaviour
{
    [Header("Throttle Lever")]
    [SerializeField] private XRGrabInteractable throttleLever;  // Assign the grab interactable
    [SerializeField] private Transform leverTransform;          // The actual moving lever

    [Header("Throttle Range")]
    [SerializeField] private float minZ = -0.1f;  // Lever fully back (idle)
    [SerializeField] private float maxZ = 0.1f;   // Lever fully forward (full throttle)

    [Header("Engine Output")]
    [Range(0, 1f)]
    [SerializeField] private float currentThrottle = 0f;
    public float ThrottleValue => currentThrottle;

    [Header("Smoothing")]
    [SerializeField] private float smoothingSpeed = 5f;

    private float targetThrottle = 0f;
    private Vector3 initialLocalPosition;

    private void Start()
    {
        if (leverTransform == null)
            leverTransform = throttleLever.transform;

        initialLocalPosition = leverTransform.localPosition;
    }

    private void Update()
    {
        UpdateThrottleFromLever();
        ApplySmoothing();
    }

    private void UpdateThrottleFromLever()
    {
        float localZ = leverTransform.localPosition.z;
        float clampedZ = Mathf.Clamp(localZ, minZ, maxZ);

        float normalized = Mathf.InverseLerp(minZ, maxZ, clampedZ);
        targetThrottle = Mathf.Clamp01(normalized);
    }

    private void ApplySmoothing()
    {
        currentThrottle = Mathf.Lerp(currentThrottle, targetThrottle, Time.deltaTime * smoothingSpeed);
    }
}
