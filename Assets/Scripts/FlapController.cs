using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FlapControllerVR : MonoBehaviour
{
    [Header("Flap Surfaces")]
    [SerializeField] public Transform leftFlap;
    [SerializeField] public Transform rightFlap;

    [Header("Flap Settings")]
    [SerializeField] private float maxFlapAngle = 30f;      // Maximum flap deflection angle
    [SerializeField] private float flapSpeed = 60f;         // Degrees per second for flap animation

    [Header("Lever Settings")]
    [SerializeField] public XRGrabInteractable flapLever;  // VR lever interactable
    [SerializeField] public Transform leverTransform;      // Transform of the lever part that moves
    [SerializeField] private float leverMinY = -0.1f;       // Lowest local Y position of lever
    [SerializeField] private float leverMaxY = 0.1f;        // Highest local Y position of lever

    private float currentFlapAngle = 0f;
    private float targetFlapAngle = 0f;

    private void Update()
    {
        if (flapLever.isSelected)
        {
            UpdateTargetFlapAngleFromLever();
        }

        AnimateFlaps();
    }

    private void UpdateTargetFlapAngleFromLever()
    {
        // Get normalized lever position (0 to 1)
        float normalized = Mathf.InverseLerp(leverMinY, leverMaxY, leverTransform.localPosition.y);
        normalized = Mathf.Clamp01(normalized);

        // Map normalized lever position to flap angle (0 to maxFlapAngle)
        targetFlapAngle = normalized * maxFlapAngle;
    }

    private void AnimateFlaps()
    {
        // Smoothly move current flap angle towards target
        currentFlapAngle = Mathf.MoveTowards(currentFlapAngle, targetFlapAngle, flapSpeed * Time.deltaTime);

        if (leftFlap != null)
            leftFlap.localRotation = Quaternion.Euler(-currentFlapAngle, 0f, 0f);

        if (rightFlap != null)
            rightFlap.localRotation = Quaternion.Euler(-currentFlapAngle, 0f, 0f);
    }
}
