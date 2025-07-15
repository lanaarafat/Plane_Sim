using UnityEngine;

public class SixPackInstruments : MonoBehaviour
{
    [Header("Aircraft Reference")]
    [SerializeField] private Rigidbody aircraftRb;

    [Header("Airspeed Indicator")]
    [SerializeField] private Transform airspeedNeedle;
    [SerializeField] private float maxAirspeed = 100f;
    [SerializeField] private float airspeedMaxAngle = 200f;

    [Header("Attitude Indicator")]
    [SerializeField] private Transform attitudeHorizonObject;
    [SerializeField] private float attitudePitchScale = 0.05f;
    [SerializeField] private Transform horizonRotation;

    [Header("Altimeter")]
    [SerializeField] private Transform altimeterLargeNeedle;
    [SerializeField] private Transform altimeterSmallNeedle;
    [SerializeField] private Transform Sealevel;

    [Header("Turn Coordinator")]
    [SerializeField] private Transform turnCoordinatorNeedle;
    [SerializeField] private float maxTurnRate = 30f;
    [SerializeField] private float turnMaxAngle = 45f;

    [Header("Heading Indicator")]
    [SerializeField] private Transform compassNeedle;

    [Header("Vertical Speed Indicator")]
    [SerializeField] private Transform vsiNeedle;
    [SerializeField] private float maxVSI = 2000f;
    [SerializeField] private float vsiMaxAngle = 90f;

    [Header("Managers")]
    [SerializeField] private SimpleAirPlaneController simpleAirPlaneController;


    void Update()
    {
        if (aircraftRb == null) return;

        // Data extraction
        float airspeed = aircraftRb.velocity.magnitude * 1.94384f; // m/s to knots
        float altitude = Sealevel.position.y; // m to ft
        float verticalSpeed = aircraftRb.velocity.y * 196.850f; // m/s to ft/min
        float heading = horizonRotation.eulerAngles.y;
        float pitch = NormalizeAngle(transform.eulerAngles.x);
        float bank = NormalizeAngle(horizonRotation.eulerAngles.z);
        float turnAngle = NormalizeAngle(horizonRotation.eulerAngles.z);

        // 1. Airspeed Indicator
        float airspeedClamped = Mathf.Clamp(simpleAirPlaneController.CurrentSpeed(), 0, maxAirspeed);
        float airspeedAngle = (airspeedClamped / maxAirspeed) * airspeedMaxAngle;
        airspeedNeedle.localRotation = Quaternion.Euler(0f, 0f, -airspeedAngle);

        // 2. Attitude Indicator
        if (attitudeHorizonObject != null)
        {
           // attitudeHorizonObject.localPosition = new Vector3(0f, pitch * attitudePitchScale, 0f);
            attitudeHorizonObject.localRotation = Quaternion.Euler(0f, 0f, -bank);
        }

        // 3. Altimeter
        float largeAngle = -(altitude % 1000f) / 1000f * 360f;
        float smallAngle = -(altitude / 1000f) * 360f;
        altimeterLargeNeedle.localRotation = Quaternion.Euler(0f, 0f, largeAngle);
        altimeterSmallNeedle.localRotation = Quaternion.Euler(0f, 0f, smallAngle);

        // 4. Turn Coordinator
        // float turnClamped = Mathf.Clamp(turnRate, -maxTurnRate, maxTurnRate);
        // float turnAngle = (turnClamped / maxTurnRate) * turnMaxAngle;
        turnCoordinatorNeedle.localRotation = Quaternion.Euler(0f, 0f, turnAngle);

        // 5. Heading Indicator
        compassNeedle.localRotation = Quaternion.Euler(0f, 0f, -heading);

        // 6. Vertical Speed Indicator
        float vsiClamped = Mathf.Clamp(verticalSpeed, -maxVSI, maxVSI);
        float vsiAngle = (vsiClamped / maxVSI) * vsiMaxAngle;
        vsiNeedle.localRotation = Quaternion.Euler(0f, 0f, -vsiAngle);
    }

    float NormalizeAngle(float angle)
    {
        if (angle > 180f) angle -= 360f;
        return angle;
    }
}
