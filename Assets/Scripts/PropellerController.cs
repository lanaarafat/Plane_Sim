using UnityEngine;

public class PropellerController : MonoBehaviour
{
    [Header("Propeller Settings")]
    [SerializeField] public Transform propellerTransform;

    [Tooltip("Maximum RPM at full throttle")]
    [SerializeField] private float maxRPM = 2500f;

    [Tooltip("Throttle input source (reference to throttle script)")]
    [SerializeField] private ThrottleController throttleController;

    private float currentRPM;

    private void Update()
    {
        UpdateRPM();
        RotatePropeller();
    }

    private void UpdateRPM()
    {
        if (throttleController == null)
            return;

        currentRPM = throttleController.ThrottleValue * maxRPM;
    }

    private void RotatePropeller()
    {
        if (propellerTransform == null)
            return;

        float rotationSpeed = (currentRPM / 60f) * 360f * Time.deltaTime;
        propellerTransform.Rotate(Vector3.forward, rotationSpeed, Space.Self);
    }
}
