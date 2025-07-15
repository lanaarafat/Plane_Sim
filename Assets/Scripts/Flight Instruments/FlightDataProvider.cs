using UnityEngine;

public class FlightDataProvider : MonoBehaviour
{
    public Rigidbody aircraftRb;

    public float Airspeed => aircraftRb.velocity.magnitude * 1.94384f; // m/s to knots
    public float Altitude => transform.position.y * 3.28084f; // meters to feet
    public float VerticalSpeed => aircraftRb.velocity.y * 196.850f; // m/s to ft/min
    public float Heading => transform.eulerAngles.y;
    public float Pitch => transform.eulerAngles.x;
    public float Bank => transform.eulerAngles.z;

    public float TurnRate => aircraftRb.angularVelocity.y * Mathf.Rad2Deg; // deg/sec
}
