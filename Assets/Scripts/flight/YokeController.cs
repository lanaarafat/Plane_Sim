using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Content.Interaction;

public class YokeController : MonoBehaviour
{

    private XRKnob yokeKnob;
    // [SerializeField] private XRSliderM yokeSlider;
    [SerializeField] private GameObject yokeTurn;
    [SerializeField] private GameObject yokePull;

    private InputAction yokeRightActionPullInput;
    private InputAction yokeLeftActionPullInput;

    private InputAction yokeRightActionSelectInput;
    private InputAction yokeLeftActionSelectInput;



    private void Start()
    {
        yokeRightActionPullInput = InputSystem.actions.FindAction("XRI RightHand Interaction/UI Press");
        yokeLeftActionPullInput = InputSystem.actions.FindAction("XRI LeftHand Interaction/UI Press");

        yokeRightActionSelectInput = InputSystem.actions.FindAction("XRI RightHand Interaction/Select");
        yokeLeftActionSelectInput = InputSystem.actions.FindAction("XRI LeftHand Interaction/Select");

        //yokeSlider = GetComponent<XRSliderM>();
        //yokeKnob = GetComponent<XRKnob>();

        //yokeSlider.enabled = false;
        //yokeKnob.enabled = true;


        yokeKnob = yokeTurn.GetComponent<XRKnob>();

    }

    private void Update()
    {
        if (yokeLeftActionPullInput.IsPressed() && yokeRightActionPullInput.IsPressed() && (yokeRightActionSelectInput.IsPressed() || yokeLeftActionSelectInput.IsPressed()))
        {

            yokePull.SetActive(true);
            yokeTurn.SetActive(false);
            yokeKnob.value = 0.5f;
            Debug.Log("Yoke Pull Activated");

        }

        else if (yokeRightActionSelectInput.IsPressed() || yokeLeftActionSelectInput.IsPressed() && (!yokeLeftActionPullInput.IsPressed() || !yokeRightActionPullInput.IsPressed()))
        {
            yokeTurn.SetActive(true);
            yokePull.SetActive(false);
            Debug.Log("Yoke Turn Activated");
        }

    }


}
