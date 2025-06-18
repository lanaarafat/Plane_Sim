using UnityEngine;

public class YokeRollController : MonoBehaviour
{
    [Header("Yoke Settings")]
    [Tooltip("The transform of the yoke stick (grabbed by user)")]
    public Transform yokeTransform;

    [Tooltip("The max expected Z-axis rotation (degrees) in either direction")]
    public float maxYokeRotation = 45f;

    [Header("Aircraft Settings")]
    [Tooltip("The aircraft transform to apply roll to")]
    public Transform aircraftTransform;

    [Tooltip("How fast the aircraft rolls (degrees per second)")]
    public float rollSpeed = 60f;

    [Tooltip("How much the yoke rotation affects aircraft roll (0 to 1)")]
    [Range(0f, 1f)]
    public float rollSensitivity = 0.5f;

    void Update()
    {
        if (yokeTransform == null || aircraftTransform == null) return;

        // Get current local Z rotation of the yoke (twist left/right)
        float zRotation = yokeTransform.localEulerAngles.z;

        // Convert 0–360 range to -180 to 180
        if (zRotation > 180f) zRotation -= 360f;

        // Normalize to -1 to 1 based on maxYokeRotation
        float rollInput = Mathf.Clamp(zRotation / maxYokeRotation, -1f, 1f);

        // Calculate roll angle for this frame
        float rollAmount = rollInput * rollSpeed * rollSensitivity * Time.deltaTime;

        // Apply roll to the aircraft (around its forward axis)
        aircraftTransform.Rotate(Vector3.forward, -rollAmount, Space.Self);
    }
}
