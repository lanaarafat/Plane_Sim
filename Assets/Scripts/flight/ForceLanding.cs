using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceLanding : MonoBehaviour
{
    [SerializeField] private Transform landingRightTransform;
    [SerializeField] private Transform landingLeftTransform;
    [SerializeField] private Transform planePrepellerTransform;
    [SerializeField] private GameObject planeObject;
    [SerializeField] private SimpleAirPlaneController simpleAirPlaneController;
    [SerializeField] private float planeStopTime = 6.0f;
    [SerializeField] private AudioSource landingAudioSource;
    [SerializeField] private GameObject completionCanvas;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Plane"))
        {
            if (Vector3.Distance(landingRightTransform.position, planePrepellerTransform.position) >
               Vector3.Distance(landingLeftTransform.position, planePrepellerTransform.position))
            {
                planeObject.transform.position = landingRightTransform.position;
                planeObject.transform.rotation = landingRightTransform.rotation;
            }
            else
            {
                planeObject.transform.position = landingLeftTransform.position;
                planeObject.transform.rotation = landingLeftTransform.rotation;
            }

            simpleAirPlaneController.airplaneState = SimpleAirPlaneController.AirplaneState.Takeoff;

            StartCoroutine(TimeBeforePlaneStop(planeStopTime));

        }
    }


    IEnumerator TimeBeforePlaneStop(float planeStopTime)
    {
        yield return new WaitForSeconds(planeStopTime);
        simpleAirPlaneController.SetSpeed(0.0f);
        simpleAirPlaneController.enabled = false;
        landingAudioSource.Stop();

        completionCanvas.SetActive(true);

    }

}