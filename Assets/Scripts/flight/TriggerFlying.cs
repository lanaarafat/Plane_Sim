using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFlying : MonoBehaviour
{

    int count = 0;
    public AudioSource planeAudioSource;
    public AudioClip flyingClip;

    [SerializeField] private SimpleAirPlaneController simpleAirPlaneController;
    private void OnTriggerExit(Collider other)
    {
       

        if (other.CompareTag("Plane") && count <= 0)
        {
            // Assuming the player has a script that handles flying
            simpleAirPlaneController.airplaneState = SimpleAirPlaneController.AirplaneState.Flying;
            count = 1;

            if (planeAudioSource != null) 
            { 
                planeAudioSource.clip = flyingClip;
                planeAudioSource.Play();
                planeAudioSource.loop = true;
            }
           

        }
    }
}

