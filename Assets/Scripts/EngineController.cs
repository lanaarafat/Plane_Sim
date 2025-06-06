using UnityEngine;

public class EngineController : MonoBehaviour
{
    [Header("Throttle Input")]
    [SerializeField] private float maxRPM = 2700f; // Max revolutions per minute
    [SerializeField] private AnimationCurve throttleToRPMCurve;

    [Header("Dependencies")]
    [SerializeField] public FuelSystem fuelSystem; // Public for Inspector
    [SerializeField] public ElectricalSystem electricalSystem; // Public for Inspector

    [Header("Magnetos")]
    [SerializeField] public MagnetoState magnetoState = MagnetoState.OFF;

    [Header("Engine State")]
    [SerializeField] private bool isEngineRunning = false;
    [SerializeField] private float currentRPM = 0f;

    private float throttleInput = 0f;

    public float CurrentRPM => currentRPM;
    public bool IsRunning => isEngineRunning;

    public enum MagnetoState
    {
        OFF,
        LEFT,
        RIGHT,
        BOTH
    }

    private void Update()
    {
        UpdateEngineState();
    }

    /// <summary>
    /// Called from ThrottleController to set desired input level
    /// </summary>
    public void SetThrottle(float input)
    {
        throttleInput = Mathf.Clamp01(input);
    }

    private void UpdateEngineState()
    {
        if (CanRun())
        {
            if (!isEngineRunning)
            {
                StartEngine();
            }

            // Calculate RPM based on throttle input using curve
            float rpmFactor = throttleToRPMCurve.Evaluate(throttleInput);
            currentRPM = rpmFactor * maxRPM;
        }
        else
        {
            StopEngine();
        }
    }

    private bool CanRun()
    {
        return magnetoState == MagnetoState.BOTH &&
               fuelSystem != null && fuelSystem.HasFuel &&
               electricalSystem != null && electricalSystem.IsPowered;
    }

    private void StartEngine()
    {
        isEngineRunning = true;
        // Optional: Trigger sound, visual effects, etc.
    }

    private void StopEngine()
    {
        isEngineRunning = false;
        currentRPM = 0f;
    }
}
