using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ElevatorController : MonoBehaviour
{
    [Header("Elevator Settings")]
    [SerializeField] public Transform elevator; // The physical elevator part on the plane
    [SerializeField] private float maxDeflection = 20f; // Degrees up/down
    [SerializeField] private float responseSpeed = 5f;

    [Header("VR Yoke Settings")]
    [SerializeField] public Transform vrYoke; // The actual yoke the player grabs
    [SerializeField] private Vector3 yokeForwardAxis = Vector3.forward; // Axis to check movement
    [SerializeField] private float yokeMovementRange = 0.3f; // Meters forward/backward

    private float currentDeflection = 0f;

    private void Update()
    {
        UpdateElevatorDeflection();
        ApplyDeflectionToElevator();
    }

    private void UpdateElevatorDeflection()
    {
        if (vrYoke == null || elevator == null)
            return;

        // Measure local movement along forward axis (push/pull)
        float localZ = Vector3.Dot(vrYoke.localPosition, yokeForwardAxis.normalized);

        // Normalize to -1 to 1 range
        float normalizedInput = Mathf.Clamp(localZ / yokeMovementRange, -1f, 1f);

        currentDeflection = Mathf.Lerp(currentDeflection, -normalizedInput * maxDeflection, Time.deltaTime * responseSpeed);
    }

    private void ApplyDeflectionToElevator()
    {
        elevator.localRotation = Quaternion.Euler(currentDeflection, 0f, 0f);
    }
}
