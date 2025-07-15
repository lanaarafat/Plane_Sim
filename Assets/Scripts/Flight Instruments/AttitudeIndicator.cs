using UnityEngine;

public class AttitudeIndicator : MonoBehaviour
{
    public FlightDataProvider dataProvider;
    public Transform pitchObject;
    public Transform bankObject;

    public float pitchScale = 2.0f; // Adjust based on your model
    void Update()
    {
        float pitch = dataProvider.Pitch;
        float bank = dataProvider.Bank;

        pitchObject.localPosition = new Vector3(0f, pitch * pitchScale, 0f);
        bankObject.localRotation = Quaternion.Euler(0f, 0f, -bank);
    }
}
