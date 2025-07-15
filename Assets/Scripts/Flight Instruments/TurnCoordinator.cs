using UnityEngine;

public class TurnCoordinator : MonoBehaviour
{
    public FlightDataProvider dataProvider;
    public Transform needle;
    public float maxTurnRate = 30f; // deg/sec
    public float maxAngle = 45f;

    void Update()
    {
        float turn = Mathf.Clamp(dataProvider.TurnRate, -maxTurnRate, maxTurnRate);
        float angle = (turn / maxTurnRate) * maxAngle;
        needle.localRotation = Quaternion.Euler(0f, 0f, -angle);
    }
}
