using UnityEngine;

public class VSI : MonoBehaviour
{
    public FlightDataProvider dataProvider;
    public Transform needle;
    public float maxRate = 2000f; // ft/min
    public float maxAngle = 90f;

    void Update()
    {
        float vsi = Mathf.Clamp(dataProvider.VerticalSpeed, -maxRate, maxRate);
        float angle = (vsi / maxRate) * maxAngle;
        needle.localRotation = Quaternion.Euler(0f, 0f, -angle);
    }
}
