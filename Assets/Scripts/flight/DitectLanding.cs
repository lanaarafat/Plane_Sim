using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DitectLanding : MonoBehaviour
{
    [SerializeField] private GameObject runway;
    [SerializeField] private GameObject plane;
    public Transform ringObj;
    public float distancebtw = 5f;

    private bool runOnce = false;

    public void Update()
    {
        if (Vector3.Distance(ringObj.position, plane.transform.position) < distancebtw && !runOnce)
        {
            // Assuming you have a method to handle landing logic
            runOnce = true;
            runway.GetComponent<BoxCollider>().enabled = true;

        }
    }
}
