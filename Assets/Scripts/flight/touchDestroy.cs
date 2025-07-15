using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchDestroy : MonoBehaviour
{

    [SerializeField] private SimpleAirPlaneController simpleAirPlaneController;

    private void OnEnable()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Plane"))
        {
            if(simpleAirPlaneController != null)
            {
                simpleAirPlaneController.canLand = true;
            }
            
            Destroy(gameObject, 1.0f);
        }
    }
}
