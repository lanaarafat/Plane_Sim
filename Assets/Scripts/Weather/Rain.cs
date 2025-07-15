using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain : MonoBehaviour
{
    [SerializeField] private GameObject rainEffect;
    [SerializeField] private string targetTag = "Plane";
    [SerializeField] private GameObject outsideRain;

    private bool rainEnabled = false;

    private void OnTriggerExit(Collider other)
    {
        if (!rainEnabled && other.CompareTag(targetTag))
        {
            if (rainEffect != null)
            {
                rainEffect.SetActive(true);
                rainEnabled = true;
            }
            if (outsideRain != null)
            {
                outsideRain.SetActive(false);
            }
        }
    }
}
