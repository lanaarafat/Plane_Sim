using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchDestroy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Plane"))
        {
            Destroy(gameObject, 1.0f);
        }
    }
}
