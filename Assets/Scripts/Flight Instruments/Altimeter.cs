using UnityEngine;

public class Altimeter : MonoBehaviour
{
    public FlightDataProvider dataProvider;
    public Transform smallNeedle;
    public Transform largeNeedle;

    void Update()
    {
        float altitude = dataProvider.Altitude;
        float largeAngle = -(altitude % 1000f) / 1000f * 360f;
        float smallAngle = -(altitude / 1000f) * 360f;

        largeNeedle.localRotation = Quaternion.Euler(0f, 0f, largeAngle);
        smallNeedle.localRotation = Quaternion.Euler(0f, 0f, smallAngle);
    }
}
