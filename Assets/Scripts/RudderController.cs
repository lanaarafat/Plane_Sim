using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;

public class RudderController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] public Transform rudder;              // Tail rudder
    [SerializeField] public Transform leftPedal;           // Left rudder pedal
    [SerializeField] public Transform rightPedal;          // Right rudder pedal
    [SerializeField] public Transform noseWheel;           // Nosewheel for steering
    [SerializeField] private Rigidbody aircraftRigidbody;  // For ground check

    [Header("Brake Settings")]
    [SerializeField] private InputActionProperty leftBrakeInput;
    [SerializeField] private InputActionProperty rightBrakeInput;
    [SerializeField] private float brakeStrength = 300f;

    [Header("VR Input Settings")]
    [SerializeField] private InputActionProperty yawInputAction;  // Left/Right from thumbstick

    [Header("Deflection Settings")]
    [SerializeField] private float maxRudderAngle = 25f;
    [SerializeField] private float maxPedalAngle = 15f;
    [SerializeField] private float maxNoseWheelAngle = 20f;

    private float yawValue = 0f;

    private void OnEnable()
    {
        yawInputAction.action.Enable();
        leftBrakeInput.action.Enable();
        rightBrakeInput.action.Enable();
    }

    private void OnDisable()
    {
        yawInputAction.action.Disable();
        leftBrakeInput.action.Disable();
        rightBrakeInput.action.Disable();
    }

    private void Update()
    {
        ReadInput();
        ApplyRudderYaw();
        ApplyNoseWheelSteering();
    }

    private void FixedUpdate()
    {
        ApplyBrakes();
    }

    private void ReadInput()
    {
        yawValue = yawInputAction.action.ReadValue<Vector2>().x;
    }

    private void ApplyRudderYaw()
    {
        float rudderAngle = yawValue * maxRudderAngle;
        float pedalAngle = yawValue * maxPedalAngle;

        if (rudder != null)
            rudder.localRotation = Quaternion.Euler(0f, rudderAngle, 0f);

        if (leftPedal != null)
            leftPedal.localRotation = Quaternion.Euler(-pedalAngle, 0f, 0f);

        if (rightPedal != null)
            rightPedal.localRotation = Quaternion.Euler(pedalAngle, 0f, 0f);
    }

    private void ApplyNoseWheelSteering()
    {
        if (noseWheel == null || aircraftRigidbody == null)
            return;

        bool isGrounded = Mathf.Abs(aircraftRigidbody.velocity.y) < 0.1f;

        if (isGrounded)
        {
            float steerAngle = yawValue * maxNoseWheelAngle;
            noseWheel.localRotation = Quaternion.Euler(0f, steerAngle, 0f);
        }
    }

    private void ApplyBrakes()
    {
        if (aircraftRigidbody == null)
            return;

        float leftBrake = leftBrakeInput.action.ReadValue<float>();
        float rightBrake = rightBrakeInput.action.ReadValue<float>();
        float brakeForce = (leftBrake + rightBrake) * brakeStrength;

        Vector3 brakeVector = -aircraftRigidbody.velocity.normalized * brakeForce;
        brakeVector.y = 0f;

        aircraftRigidbody.AddForce(brakeVector, ForceMode.Force);
    }
}
