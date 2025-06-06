using UnityEngine;

public class ElectricalSystem : MonoBehaviour
{
    [Header("System Toggles")]
    [SerializeField] public bool masterSwitchOn = false;     // Main battery switch
    [SerializeField] public bool alternatorOn = false;       // Alternator simulates charging
    [SerializeField] public bool batteryAvailable = true;    // Battery not drained or failed

    [Header("Power Output")]
    [SerializeField] private float batteryVoltage = 12.6f;
    [SerializeField] private float alternatorVoltage = 14.0f;
    [SerializeField] private float currentVoltage = 0f;

    [Header("Circuit Breakers")]
    [SerializeField] public bool avionicsBreaker = true;
    [SerializeField] public bool lightsBreaker = true;
    [SerializeField] public bool fuelPumpBreaker = true;

    public float CurrentVoltage => currentVoltage;
    public bool IsPowered => masterSwitchOn && batteryAvailable;

    private void Update()
    {
        UpdateElectricalState();
    }

    private void UpdateElectricalState()
    {
        if (!masterSwitchOn || !batteryAvailable)
        {
            currentVoltage = 0f;
            return;
        }

        currentVoltage = alternatorOn ? alternatorVoltage : batteryVoltage;
    }

    public bool IsAvionicsPowered()
    {
        return IsPowered && avionicsBreaker;
    }

    public bool IsLightsPowered()
    {
        return IsPowered && lightsBreaker;
    }

    public bool IsFuelPumpPowered()
    {
        return IsPowered && fuelPumpBreaker;
    }

    public void SetMasterSwitch(bool isOn)
    {
        masterSwitchOn = isOn;
    }

    public void SetAlternator(bool isOn)
    {
        alternatorOn = isOn;
    }

    public void ToggleBreaker(string breakerName, bool state)
    {
        switch (breakerName.ToLower())
        {
            case "avionics": avionicsBreaker = state; break;
            case "lights": lightsBreaker = state; break;
            case "fuelpump": fuelPumpBreaker = state; break;
        }
    }
}
