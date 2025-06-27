using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmPlaneController : MonoBehaviour
{
    [SerializeField]
    private float pitchForce = 10f;
    [SerializeField]
    private float rollForce = 10f;
    [SerializeField]
    private float takeOffForce = 100f;


    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    private void FixedUpdate()
    {

        if(Input.GetKey(KeyCode.W))
        {
            rb.AddForce(transform.forward * takeOffForce);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.AddTorque(transform.right * pitchForce);
        }

        if(Input.GetKey(KeyCode.A))
        {
            rb.AddTorque(transform.right * -pitchForce);
        }
    }
}
