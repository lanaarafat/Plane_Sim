using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFlying : MonoBehaviour
{

    int count = 0;
    public AudioSource planeAudioSource;
    public AudioClip flyingClip;
    public Light rightLight;
    public Light leftLight;
    public float newAcceleration = 4f;
    public float newSpeed = 20f;

    [SerializeField] private SimpleAirPlaneController simpleAirPlaneController;
    [SerializeField] private Rigidbody planeRigidbody;
   
    private void OnTriggerExit(Collider other)
    {
       
        if (other.CompareTag("Plane") && count <= 0)
        {
            // Assuming the player has a script that handles flying
            simpleAirPlaneController.airplaneState = SimpleAirPlaneController.AirplaneState.Flying;
            count = 1;

            SetLightsToRed();
            ChangeSpeeds();


            if (planeAudioSource != null) 
            { 
                planeAudioSource.clip = flyingClip;
                planeAudioSource.Play();
                planeAudioSource.loop = true;
            }   

        }

      

    }


    private void SetLightsToRed()
    {
        rightLight.color = Color.red;
        leftLight.color = Color.red;
    }

    private void ChangeSpeeds()
    {
        simpleAirPlaneController.SetAcceleration(newAcceleration);
        simpleAirPlaneController.SetSpeed(newSpeed);
    }
}

