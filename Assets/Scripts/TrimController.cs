using UnityEngine;

public class TrimController : MonoBehaviour
{
    [Header("Trim Lever Settings")]
    [Tooltip("The VR-tracked trim lever or knob object (user moves this)")]
    [SerializeField] public Transform trimControl;

    [Tooltip("Position when trim is fully nose-down")]
    [SerializeField] private Transform noseDownPosition;

    [Tooltip("Position when trim is fully nose-up")]
    [SerializeField] private Transform noseUpPosition;

    [Range(-1f, 1f)]
    [Tooltip("Trim value: -1 = full nose-down, 1 = full nose-up")]
    public float trimValue = 0f;

    private void Update()
    {
        UpdateTrimValue();
    }

    private void UpdateTrimValue()
    {
        if (trimControl == null || noseDownPosition == null || noseUpPosition == null)
            return;

        Vector3 trimRange = noseUpPosition.position - noseDownPosition.position;
        Vector3 currentOffset = trimControl.position - noseDownPosition.position;

        float projection = Vector3.Dot(currentOffset, trimRange.normalized);
        float maxLength = trimRange.magnitude;

        trimValue = Mathf.Clamp((projection / maxLength) * 2f - 1f, -1f, 1f); // Normalize to -1 to 1
    }
}
