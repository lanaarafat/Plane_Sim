using UnityEngine;

public class AirspeedIndicator : MonoBehaviour
{
    public FlightDataProvider dataProvider;
    public Transform needle;
    public float maxSpeed = 100f;
    public float maxAngle = 200f;

    void Update()
    {
        float speed = Mathf.Clamp(dataProvider.Airspeed, 0, maxSpeed);
        float angle = (speed / maxSpeed) * maxAngle;
        needle.localRotation = Quaternion.Euler(0f, 0f, -angle);
    }
}
