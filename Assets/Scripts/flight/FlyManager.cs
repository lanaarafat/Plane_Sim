using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;
using UnityEngine.XR.Interaction.Toolkit;

public class FlyManager : MonoBehaviour
{
    [Space(10)]
    [Header("Flight Settings")]
    [SerializeField] private float highLightValue = 1.0f;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Transform playerDefaultTransform;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private float timeBeforeTakeOff = 8.0f; // Time to wait before takeoff after key turn
    [SerializeField] private float timeBeforeSoundPlay = 3.0f;
    [SerializeField] private AudioSource planeAudioSource;

    [Space(10)]
    [Header("Engine Start")]
    [SerializeField] private GameObject engineObj;
    [SerializeField] private Outline engineStartOutline;
    [SerializeField] private XRBaseInteractable engineStartInteractable;
    [SerializeField] private AudioClip engineStartAudioClip;


    [Space(10)]
    [Header("Throttle Push")]
    [SerializeField] private GameObject throttleObj;
    [SerializeField] private Outline throttlePushOutline;
    [SerializeField] private XRSlider throttlePushInteractable;
    [SerializeField] private AudioClip throttlePushAudioClip;
    [SerializeField] private float throttlePushValue = 0.2f; // Example value for throttle push threshold


    [Space(10)]
    [Header("Mixture Pull Lean")]
    [SerializeField] private GameObject mixtureObj;
    [SerializeField] private Outline mixturePullLeanOutline;
    [SerializeField] private XRSlider mixturePullLeanInteractable;
    [SerializeField] private AudioClip mixturePullLeanAudioClip;
    [SerializeField] private float mixturePullLeanValue = 0.2f; // Example value for mixture pull lean threshold


    [Space(10)]
    [Header("Fuel Selector Valve")]
    [SerializeField] private GameObject fuelSelectorObj;
    [SerializeField] private Outline fuelSelectorValveOutline;
    [SerializeField] private XRKnob fuelSelectorValveInteractable;
    [SerializeField] private AudioClip fuelSelectorValveAudioClip;
    [SerializeField] private float minFuelSelectorValue = 0.4f; // Example value for fuel selector valve threshold
    [SerializeField] private float maxFuelSelectorValue = 0.6f; // Example value for fuel selector valve threshold


    [Space(10)]
    [Header("Wing Flap")]
    [SerializeField] private GameObject wingFlapObj;
    [SerializeField] private Outline wingFlapOutline;
    [SerializeField] private XRSlider wingFlapInteractable;
    [SerializeField] private AudioClip wingFlapAudioClip;
    [SerializeField] private float wingFlapValue = 0.2f;


    [Space(10)]
    [Header("Key Turn")]
    [SerializeField] private GameObject keyObj;
    [SerializeField] private Outline keyTurnOutline;
    [SerializeField] private XRKnob keyTurnInteractable;
    [SerializeField] private AudioClip keyTurnAudioClip;
    [SerializeField] private float keyTurnValueOn = 0.8f;
    [SerializeField] private float keyTurnValueOff = 0.2f;

    [Space(10)]
    [Header("Take Off ")]
    [SerializeField] private AudioClip takeOffAudioClip;
    [SerializeField] private SimpleAirPlaneController simpleAirPlaneController;
   


    // take off plans and flying from here to complete the process.

    private void Awake()
    {
        simpleAirPlaneController.enabled = false;
    }

    void Start()
    {
      StartSwitchTutorial();
        // Initialize flight settings or any other setup if needed
      engineStartInteractable.selectEntered.AddListener(ThrottlePush);
   

    }

    private void StartSwitchTutorial()
    {
        SetPlayerPosition();
        engineStartOutline.OutlineWidth = highLightValue;
        StartCoroutine(PlayAudio(engineStartAudioClip));

       
    }

    private void ThrottlePush(SelectEnterEventArgs args)
    {
        engineStartOutline.enabled = false;
        throttlePushOutline.OutlineWidth = highLightValue;

        StartCoroutine(PlayAudio(throttlePushAudioClip));

        //throttlePushInteractable.selectEntered.AddListener(CheckThrottlePush);
        throttlePushInteractable.selectExited.AddListener(CheckThrottlePush);

        engineStartInteractable.enabled = false;
        engineStartInteractable.selectEntered.RemoveListener(ThrottlePush);

    }

    private void CheckThrottlePush(SelectExitEventArgs args)
    {

        if (throttlePushInteractable.value < throttlePushValue)
        {
            throttlePushInteractable.selectExited.AddListener(MixturePull);
        }
    }

    private void MixturePull(SelectExitEventArgs args)
    {
        throttlePushOutline.enabled = false;
        mixturePullLeanOutline.OutlineWidth = highLightValue;

        StartCoroutine(PlayAudio(mixturePullLeanAudioClip));

        mixturePullLeanInteractable.selectExited.AddListener(CheckMixturePull);




        throttlePushInteractable.enabled = false;
        throttlePushInteractable.selectExited.RemoveListener(MixturePull);

       
    }

    private void CheckMixturePull(SelectExitEventArgs args)
    {
        if (mixturePullLeanInteractable.value <= mixturePullLeanValue)
        {
            mixturePullLeanInteractable.selectExited.AddListener(FuelSelectorValve);
        }
    }



    private void FuelSelectorValve(SelectExitEventArgs args)
    {
        mixturePullLeanOutline.enabled = false;
        fuelSelectorValveOutline.OutlineWidth = highLightValue;

        StartCoroutine(PlayAudio(fuelSelectorValveAudioClip));

        fuelSelectorValveInteractable.selectExited.AddListener(CheckFuelSelectorValve);



        mixturePullLeanInteractable.enabled = false;
        mixturePullLeanInteractable.selectExited.RemoveListener(FuelSelectorValve);
      
    }

    private void CheckFuelSelectorValve(SelectExitEventArgs e)
    {
        if (fuelSelectorValveInteractable.value > minFuelSelectorValue && fuelSelectorValveInteractable.value < maxFuelSelectorValue)
        {
            fuelSelectorValveInteractable.selectExited.AddListener(WingFlapChange);
        }
    }


    private void WingFlapChange(SelectExitEventArgs args)
    {
        fuelSelectorValveOutline.enabled = false;
        wingFlapOutline.OutlineWidth = highLightValue;

        StartCoroutine(PlayAudio(wingFlapAudioClip));

        wingFlapInteractable.selectExited.AddListener(CheckWingFlap);


        fuelSelectorValveInteractable.enabled = false;
        fuelSelectorValveInteractable.selectExited.RemoveListener(WingFlapChange);
    }

    private void CheckWingFlap(SelectExitEventArgs arg)
    {
        if(wingFlapInteractable.value <= wingFlapValue)
        {
            wingFlapInteractable.selectExited.AddListener(KeyTurn);
        }
    }

    private void KeyTurn(SelectExitEventArgs args)
    {
        wingFlapOutline.enabled = false;
        keyTurnOutline.OutlineWidth = highLightValue;


        StartCoroutine(PlayAudio(keyTurnAudioClip)); 

        keyTurnInteractable.selectExited.AddListener(CheckKeyTurn);


        wingFlapInteractable.enabled = false;
        wingFlapInteractable.selectExited.RemoveListener(KeyTurn);

    }

    bool once = false;

    private void CheckKeyTurn(SelectExitEventArgs args)
    {
        if (keyTurnInteractable.value >= keyTurnValueOn)
        {
            // keyTurnInteractable.selectEntered.AddListener(PlayTakeOffActiviated);
            if(once == false)
            {
                StartCoroutine(PlaneTakeOffActiviated());
                once = true;
            }
            

        }
    }


     IEnumerator PlaneTakeOffActiviated()
     {
        keyTurnOutline.enabled = false;
        simpleAirPlaneController.enabled = true;

       

        yield return new WaitForSeconds(timeBeforeTakeOff);
        StartCoroutine(PlayAudio(takeOffAudioClip));
        simpleAirPlaneController.airplaneState = SimpleAirPlaneController.AirplaneState.Takeoff;

        keyTurnInteractable.enabled = false;

     }


     // setup usage of yoke for turning left and right.

     // do rings in the sky.

    private void SetPlayerPosition()
    {
        playerTransform.position = playerDefaultTransform.position;
        playerTransform.rotation = playerDefaultTransform.rotation;
    }

    IEnumerator PlayAudio(AudioClip clip)
    {
        yield return new WaitForSeconds(timeBeforeSoundPlay);
        if (clip != null)
        {
            if (audioSource != null)
            {
                audioSource.PlayOneShot(clip);
            }
        }
    }

    private void Update()
    {
        
    }

}
