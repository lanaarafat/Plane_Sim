using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class DetectLanding : MonoBehaviour
{
    [SerializeField] private GameObject runway;
    [SerializeField] private GameObject plane;
    public Transform ringObj;
    public float distancebtw = 5f;

    private bool runOnce = false;

    private BoxCollider runwayCollider;

    private void Start()
    {
        runwayCollider = runway.GetComponent<BoxCollider>();
    }

    public void Update()
    {
        if(Vector3.Distance(ringObj.position, plane.transform.position) < distancebtw && !runOnce)
        {
            // Assuming you have a method to handle landing logic
            runOnce = true;
            runwayCollider.enabled = true;

        }
    }
}
