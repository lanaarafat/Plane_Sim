using UnityEngine;

public class HeadingIndicator : MonoBehaviour
{
    public FlightDataProvider dataProvider;
    public Transform compassNeedle;

    void Update()
    {
        float heading = dataProvider.Heading;
        compassNeedle.localRotation = Quaternion.Euler(0f, 0f, -heading);
    }
}
