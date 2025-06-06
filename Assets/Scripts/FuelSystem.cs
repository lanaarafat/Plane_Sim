using UnityEngine;

public class FuelSystem : MonoBehaviour
{
    [Header("Fuel Settings")]
    [SerializeField] private float maxFuel = 200f; // Total capacity in liters or gallons
    [SerializeField] private float fuelConsumptionRate = 0.1f; // Liters/sec at full throttle
    [SerializeField] private float currentFuel = 200f;

    [Header("System States")]
    [SerializeField] public bool fuelShutoff = false;       // Controlled from cockpit
    [SerializeField] public bool fuelPumpActive = false;    // Controlled from cockpit
    [SerializeField] public FuelTank selectedTank = FuelTank.LEFT;

    public enum FuelTank { LEFT, RIGHT, BOTH }

    public bool HasFuel => currentFuel > 0 && !fuelShutoff;

    private void Update()
    {
        if (CanConsumeFuel())
        {
            ConsumeFuel(Time.deltaTime);
        }
    }

    public void SetFuelPumpState(bool isActive)
    {
        fuelPumpActive = isActive;
    }

    public void SetFuelShutoffState(bool isShutoff)
    {
        fuelShutoff = isShutoff;
    }

    public void SetFuelTank(FuelTank tank)
    {
        selectedTank = tank;
    }

    private bool CanConsumeFuel()
    {
        return !fuelShutoff && currentFuel > 0;
    }

    private void ConsumeFuel(float deltaTime)
    {
        // Simple uniform rate (can be adjusted with throttle input)
        currentFuel = Mathf.Max(0f, currentFuel - fuelConsumptionRate * deltaTime);
    }

    public float GetFuelLevelNormalized()
    {
        return currentFuel / maxFuel;
    }

    public void Refuel()
    {
        currentFuel = maxFuel;
    }
}
