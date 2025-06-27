using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchAnime : MonoBehaviour
{
    private Animator animator; // Reference to the Animator component
    private bool isOn = false;

    public bool getSwitchState()
    {
        return isOn; // Returns the current state of the switch
    }

    public void Start()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
    }

    public void CheckingCalls()
    {
        Debug.Log("The Switch Method is called");
    }

    public void Switch()
    {
        if(isOn)
        {
            SwitchOff(); // If currently on, switch off
        }
        else
        {
            SwitchOn(); // If currently off, switch on
        }
    }

    private void SwitchOn()
    {
        if (animator != null)
        {
            animator.SetBool("isOn", true); // Assuming "isOn" is the parameter in the Animator
            isOn = true; // Update the state to on
        }
    }

    private void SwitchOff()
    {
        if (animator != null)
        {
            animator.SetBool("isOn", false); // Assuming "isOn" is the parameter in the Animator
            isOn = false; // Update the state to off
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Check if the colliding object has the tag "Player"
        {
            Switch(); // Call the switch method when the player collides with the switch
        }
    }
}


