/* using UnityEngine;

[RequireComponent(typeof(EngineController))]
[RequireComponent(typeof(FlightPhysics))]
public class AircraftController : MonoBehaviour
{
    // System References (SRP: Holds only references, doesn't manage logic)
    private EngineController engineController;
    private FlightPhysics flightPhysics;
    private FuelSystem fuelSystem;
    private ElectricalSystem electricalSystem;

    [SerializeField] private AileronController aileronController;
    [SerializeField] private ElevatorController elevatorController;
    [SerializeField] private RudderController rudderController;
    [SerializeField] private FlapsController flapsController;
    [SerializeField] private TrimController trimController;

    [Header("VR Controls")]
    [SerializeField] private YokeController yokeController;
    [SerializeField] private RudderPedalController rudderPedalController;
    [SerializeField] private ThrottleController throttleController;

    private void Awake()
    {
        engineController = GetComponent<EngineController>();
        flightPhysics = GetComponent<FlightPhysics>();
        fuelSystem = GetComponent<FuelSystem>();
        electricalSystem = GetComponent<ElectricalSystem>();
    }

    private void Update()
    {
        if (!electricalSystem.IsPowered || !fuelSystem.HasFuel) return;

        // Update flight control surfaces based on VR input
        float pitchInput = yokeController.GetPitchInput();
        float rollInput = yokeController.GetRollInput();
        float yawInput = rudderPedalController.GetYawInput();
        float brakeInput = rudderPedalController.GetBrakeInput();

        aileronController.SetRollInput(rollInput);
        elevatorController.SetPitchInput(pitchInput);
        rudderController.SetYawInput(yawInput);
        flapsController.UpdateFlapsPosition();
        trimController.ApplyTrim(elevatorController);

        // Engine & throttle
        float throttle = throttleController.GetThrottleInput();
        engineController.SetThrottle(throttle);

        // Flight physics calculations
        flightPhysics.ApplyAerodynamics(
            pitchInput, rollInput, yawInput,
            throttle,
            aileronController.Deflection,
            elevatorController.Deflection,
            rudderController.Deflection,
            flapsController.CurrentDeflection
        );
    }
}
*/