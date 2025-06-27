using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialUI : MonoBehaviour
{

    [Header("Settings")]
    [SerializeField] private Transform playerTransfrom;
    [SerializeField] private AudioSource audioSource;
    [SerializeField]
    [Range(0f, 5f)]
    private float outlineSizeShow = 4.0f;

    #region VARIABLES

    [Space(10)]
    [Header("Welcome")]
    [SerializeField] private GameObject welcomeCanvas;
    [SerializeField] private Button welcomeNextBtn;

    [Space(10)]
    [Header("Propeller")]
    [SerializeField] private GameObject propCanvas;
    [SerializeField] private Button propNextBtn;
    [SerializeField] private AudioClip propAudioClip;
    [SerializeField] private Outline propOutline;
    [SerializeField] private Transform propLocation;

    [Space(10)]
    [Header("Landing Gear")]
    [SerializeField] private GameObject landinggearCanvas;
    [SerializeField] private Button landinggearNextBtn;
    [SerializeField] private AudioClip landinggearAudioClip;
    [SerializeField] private Outline landinggearOutline;
    [SerializeField] private Transform landinggearLocation;

    /*[Space(10)]
    [Header("Wings")]
    [SerializeField] private GameObject wingsCanvas;
    [SerializeField] private Button wingsNextBtn;
    [SerializeField] private AudioClip wingsAudioClip;
    [SerializeField] private Outline wingsOutline;
    [SerializeField] private Transform wingsLocation;*/

    [Space(10)]
    [Header("Ailerons")]
    [SerializeField] private GameObject aileronsCanvas;
    [SerializeField] private Button aileronsNextBtn;
    [SerializeField] private AudioClip aileronsAudioClip;
    [SerializeField] private Outline aileronsOutline;
    [SerializeField] private Transform aileronsLocation;

    [Space(10)]
    [Header("Flaps")]
    [SerializeField] private GameObject flapsCanvas;
    [SerializeField] private Button flapsNextBtn;
    [SerializeField] private AudioClip flapsAudioClip;
    [SerializeField] private Outline flapsOutline;
    [SerializeField] private Transform flapsLocation;

    /* [Space(10)]
     [Header("Empennage")]
     [SerializeField] private GameObject empennageCanvas;
     [SerializeField] private Button empennageNextBtn;
     [SerializeField] private AudioClip empennageAudioClip;
     [SerializeField] private Outline empennageOutline;
     [SerializeField] private Transform empennageLocation;*/

    [Space(10)]
    [Header("Elevator")]
    [SerializeField] private GameObject elevatorCanvas;
    [SerializeField] private Button elevatorNextBtn;
    [SerializeField] private AudioClip elevatorAudioClip;
    [SerializeField] private Outline elevatorOutline;
    [SerializeField] private Transform elevatorLocation;

    [Space(10)]
    [Header("Rudder")]
    [SerializeField] private GameObject rudderCanvas;
    [SerializeField] private Button rudderNextBtn;
    [SerializeField] private AudioClip rudderAudioClip;
    [SerializeField] private Outline rudderOutline;
    [SerializeField] private Transform rudderLocation;

    [Space(10)]
    [Header("Yoke")]
    [SerializeField] private GameObject yokeCanvas;
    [SerializeField] private Button yokeNextBtn;
    [SerializeField] private AudioClip yokeAudioClip;
    [SerializeField] private Outline yokeOutline;
    [SerializeField] private Transform yokeLocation;

    [Space(10)]
    [Header("Throttle")]
    [SerializeField] private GameObject throttleCanvas;
    [SerializeField] private Button throttleNextBtn;
    [SerializeField] private AudioClip throttleAudioClip;
    [SerializeField] private Outline throttleOutline;
    [SerializeField] private Transform throttleLocation;

    [Space(10)]
    [Header("Mixture")]
    [SerializeField] private GameObject mixtureCanvas;
    [SerializeField] private Button mixtureNextBtn;
    [SerializeField] private AudioClip mixtureAudioClip;
    [SerializeField] private Outline mixtureOutline;
    [SerializeField] private Transform mixtureLocation;

    [Space(10)]
    [Header("FlapLever")]
    [SerializeField] private GameObject flapleverCanvas;
    [SerializeField] private Button flapleverNextBtn;
    [SerializeField] private AudioClip flapleverAudioClip;
    [SerializeField] private Outline flapleverOutline;
    [SerializeField] private Transform flapleverLocation;

    [Space(10)]
    [Header("RudderPedals")]
    [SerializeField] private GameObject rudderpedalsCanvas;
    [SerializeField] private Button rudderpedalsNextBtn;
    [SerializeField] private AudioClip rudderpedalsAudioClip;
    [SerializeField] private Outline rudderpedalsOutline;
    [SerializeField] private Transform rudderpedalsLocation;

    [Space(10)]
    [Header("Master Switch")]
    [SerializeField] private GameObject masterswitchCanvas;
    [SerializeField] private Button masterswitchNextBtn;
    [SerializeField] private AudioClip masterswitchAudioClip;
    [SerializeField] private Outline masterswitchOutline;
    [SerializeField] private Transform masterswitchLocation;

    [Space(10)]
    [Header("Fuel Selector")]
    [SerializeField] private GameObject fuelselectorCanvas;
    [SerializeField] private Button fuelselectorNextBtn;
    [SerializeField] private AudioClip fuelselectorAudioClip;
    [SerializeField] private Outline fuelselectorOutline;
    [SerializeField] private Transform fuelselectorLocation;

    [Space(10)]
    [Header("Magnetos")]
    [SerializeField] private GameObject magnetosCanvas;
    [SerializeField] private Button magnetosNextBtn;
    [SerializeField] private AudioClip magnetosAudioClip;
    [SerializeField] private Outline magnetosOutline;
    [SerializeField] private Transform magnetosLocation;

    [Space(10)]
    [Header("AirSpeedIndicator")]
    [SerializeField] private GameObject airspeedCanvas;
    [SerializeField] private Button airspeedNextBtn;
    [SerializeField] private AudioClip airspeedAudioClip;
    [SerializeField] private Outline airspeedOutline;
    [SerializeField] private Transform airspeedLocation;

    [Space(10)]
    [Header("Attitude")]
    [SerializeField] private GameObject attitudeCanvas;
    [SerializeField] private Button attitudeNextBtn;
    [SerializeField] private AudioClip attitudeAudioClip;
    [SerializeField] private Outline attitudeOutline;
    [SerializeField] private Transform attitudeLocation;

    [Space(10)]
    [Header("Altimeter")]
    [SerializeField] private GameObject altimeterCanvas;
    [SerializeField] private Button altimeterNextBtn;
    [SerializeField] private AudioClip altimeterAudioClip;
    [SerializeField] private Outline altimeterOutline;
    [SerializeField] private Transform altimeterLocation;

    [Space(10)]
    [Header("TurnCoordinator")]
    [SerializeField] private GameObject turncoordinatorCanvas;
    [SerializeField] private Button turncoordinatorNextBtn;
    [SerializeField] private AudioClip turncoordinatorAudioClip;
    [SerializeField] private Outline turncoordinatorOutline;
    [SerializeField] private Transform turncoordinatorLocation;

    [Space(10)]
    [Header("HeadingCoordinator")]
    [SerializeField] private GameObject headingcoordinatorCanvas;
    [SerializeField] private Button headingcoordinatorNextBtn;
    [SerializeField] private AudioClip headingcoordinatorAudioClip;
    [SerializeField] private Outline headingcoordinatorOutline;
    [SerializeField] private Transform headingcoordinatorLocation;

    [Space(10)]
    [Header("VSI")]
    [SerializeField] private GameObject vsiCanvas;
    [SerializeField] private Button vsiNextBtn;
    [SerializeField] private AudioClip vsiAudioClip;
    [SerializeField] private Outline vsiOutline;
    [SerializeField] private Transform vsiLocation;

    [Space(10)]
    [Header("Tutorial Completion")]
    [SerializeField] private GameObject completionCanvas;
    [SerializeField] private Button completionNextBtn;
    [SerializeField] private AudioClip completionAudioClip;
    [SerializeField] private Outline completionOutline;
    [SerializeField] private Transform completionLocation;

    #endregion

    public void Start()
    {
        // Start with Welcome Panel
        welcomeCanvas.SetActive(true);
        welcomeNextBtn.onClick.AddListener(ShowPropeller);
        propNextBtn.onClick.AddListener(ShowLandingGear);
        landinggearNextBtn.onClick.AddListener(ShowAilerons);
        // wingsNextBtn.onClick.AddListener(ShowAilerons);
        aileronsNextBtn.onClick.AddListener(ShowFlaps);
        flapsNextBtn.onClick.AddListener(ShowElevator);
        // empennageNextBtn.onClick.AddListener(ShowElevator);
        elevatorNextBtn.onClick.AddListener(ShowRudder);
        rudderNextBtn.onClick.AddListener(ShowYoke);
        yokeNextBtn.onClick.AddListener(ShowThrottle);
        throttleNextBtn.onClick.AddListener(ShowMixture);
        mixtureNextBtn.onClick.AddListener(ShowFlapLever);
        flapleverNextBtn.onClick.AddListener(ShowRudderPedals);
        rudderpedalsNextBtn.onClick.AddListener(ShowMasterSwitch);
        masterswitchNextBtn.onClick.AddListener(ShowFuelSelector);
        fuelselectorNextBtn.onClick.AddListener(ShowMagnetos);
        magnetosNextBtn.onClick.AddListener(ShowHeadingCoordinator);
        headingcoordinatorNextBtn.onClick.AddListener(ShowAirspeedIndicator);
        airspeedNextBtn.onClick.AddListener(ShowAttitudeIndicator);
        attitudeNextBtn.onClick.AddListener(ShowAltimeter);
        altimeterNextBtn.onClick.AddListener(ShowTurnCoordinator);
        turncoordinatorNextBtn.onClick.AddListener(ShowVSI);
        vsiNextBtn.onClick.AddListener(ShowTutorialCompletion);
        completionNextBtn.onClick.AddListener(MainMenu);

    }

    #region METHODS
    public void ShowPropeller()
    {
        welcomeCanvas.SetActive(false);
        propCanvas.SetActive(true);
        propOutline.OutlineWidth = outlineSizeShow;

        StartCoroutine(playsoundLater(propAudioClip));

        changePosition(propLocation);

    }
    public void ShowLandingGear()
    {

        propCanvas.SetActive(false);
        landinggearCanvas.SetActive(true);
        propOutline.OutlineWidth = 0;
        landinggearOutline.OutlineWidth = outlineSizeShow;

        StartCoroutine(playsoundLater(landinggearAudioClip));

        changePosition(landinggearLocation);
    }

    /* public void ShowWings()
     {
         landinggearCanvas.SetActive(false);
         wingsCanvas.SetActive(true);
         wingsOutline.OutlineWidth = outlineSizeShow;

         StartCoroutine(playsoundLater(wingsAudioClip));

         changePosition(wingsLocation);
     }*/

    public void ShowAilerons()
    {
        landinggearCanvas.SetActive(false);
        aileronsCanvas.SetActive(true);
        landinggearOutline.OutlineWidth = 0;
        aileronsOutline.OutlineWidth = outlineSizeShow;

        StartCoroutine(playsoundLater(aileronsAudioClip));

        changePosition(aileronsLocation);
    }

    public void ShowFlaps()
    {
        aileronsCanvas.SetActive(false);
        flapsCanvas.SetActive(true);
        aileronsOutline.OutlineWidth = 0;
        flapsOutline.OutlineWidth = outlineSizeShow;

        StartCoroutine(playsoundLater(flapsAudioClip));

        changePosition(flapsLocation);
    }

    /*public void ShowEmpennage()
    {
        flapsCanvas.SetActive(false);
        empennageCanvas.SetActive(true);
        empennageOutline.OutlineWidth = outlineSizeShow;

        StartCoroutine(playsoundLater(empennageAudioClip));

        changePosition(empennageLocation);
    }*/
    public void ShowElevator()
    {
        flapsCanvas.SetActive(false);
        elevatorCanvas.SetActive(true);
        flapsOutline.OutlineWidth = 0;
        elevatorOutline.OutlineWidth = outlineSizeShow;

        StartCoroutine(playsoundLater(elevatorAudioClip));

        changePosition(elevatorLocation);
    }

    public void ShowRudder()
    {
        elevatorCanvas.SetActive(false);
        rudderCanvas.SetActive(true);
        elevatorOutline.OutlineWidth = 0;
        rudderOutline.OutlineWidth = outlineSizeShow;

        StartCoroutine(playsoundLater(rudderAudioClip));

        changePosition(rudderLocation);
    }

    public void ShowYoke()
    {
        rudderCanvas.SetActive(false);
        yokeCanvas.SetActive(true);
        rudderOutline.OutlineWidth = 0;
        yokeOutline.OutlineWidth = outlineSizeShow;

        StartCoroutine(playsoundLater(yokeAudioClip));

        changePosition(yokeLocation);

    }

    public void ShowThrottle()
    {
        yokeCanvas.SetActive(false);
        throttleCanvas.SetActive(true);
        yokeOutline.OutlineWidth = 0;
        throttleOutline.OutlineWidth = outlineSizeShow;

        StartCoroutine(playsoundLater(throttleAudioClip));
        changePosition(throttleLocation);

    }
    public void ShowMixture()
    {
        throttleCanvas.SetActive(false);
        mixtureCanvas.SetActive(true);
        throttleOutline.enabled = false;
        mixtureOutline.OutlineWidth = outlineSizeShow;

        StartCoroutine(playsoundLater(mixtureAudioClip));
        changePosition(mixtureLocation);


    }
    public void ShowFlapLever()
    {
        mixtureCanvas.SetActive(false);
        flapleverCanvas.SetActive(true);
        mixtureOutline.OutlineWidth = 0;
        flapleverOutline.OutlineWidth = outlineSizeShow;

        StartCoroutine(playsoundLater(flapleverAudioClip));
        changePosition(flapleverLocation);


    }
    public void ShowRudderPedals()
    {
        flapleverCanvas.SetActive(false);
        rudderpedalsCanvas.SetActive(true);
        flapleverOutline.OutlineWidth = 0;
        rudderpedalsOutline.OutlineWidth = outlineSizeShow;

        StartCoroutine(playsoundLater(rudderpedalsAudioClip));
        changePosition(rudderpedalsLocation);

    }
    public void ShowMasterSwitch()
    {
        rudderpedalsCanvas.SetActive(false);
        masterswitchCanvas.SetActive(true);
        rudderpedalsOutline.OutlineWidth = 0;
        masterswitchOutline.OutlineWidth = outlineSizeShow;

        StartCoroutine(playsoundLater(masterswitchAudioClip));
        changePosition(masterswitchLocation);

    }
    public void ShowFuelSelector()
    {
        masterswitchCanvas.SetActive(false);
        fuelselectorCanvas.SetActive(true);
        masterswitchOutline.OutlineWidth = 0;
        fuelselectorOutline.OutlineWidth = outlineSizeShow;

        StartCoroutine(playsoundLater(fuelselectorAudioClip));
        changePosition(fuelselectorLocation);
    }
    public void ShowMagnetos()
    {
        fuelselectorCanvas.SetActive(false);
        magnetosCanvas.SetActive(true);
        fuelselectorOutline.OutlineWidth = 0;
        magnetosOutline.OutlineWidth = outlineSizeShow;

        StartCoroutine(playsoundLater(magnetosAudioClip));
        changePosition(magnetosLocation);

    }
    public void ShowHeadingCoordinator()
    {
        magnetosCanvas.SetActive(false);
        headingcoordinatorCanvas.SetActive(true);
        magnetosOutline.OutlineWidth = 0;
        headingcoordinatorOutline.OutlineWidth = outlineSizeShow;

        StartCoroutine(playsoundLater(headingcoordinatorAudioClip));
        changePosition(headingcoordinatorLocation);

    }
    public void ShowAirspeedIndicator()
    {
        headingcoordinatorCanvas.SetActive(false);
        airspeedCanvas.SetActive(true);
        headingcoordinatorOutline.OutlineWidth = 0;
        airspeedOutline.OutlineWidth = outlineSizeShow;

        StartCoroutine(playsoundLater(airspeedAudioClip));
        changePosition(airspeedLocation);
    }
    public void ShowAttitudeIndicator()
    {
        airspeedCanvas.SetActive(false);
        attitudeCanvas.SetActive(true);
        airspeedOutline.OutlineWidth = 0;
        attitudeOutline.OutlineWidth = outlineSizeShow;

        StartCoroutine(playsoundLater(attitudeAudioClip));
        changePosition(attitudeLocation);
    }
    public void ShowAltimeter()
    {
        attitudeCanvas.SetActive(false);
        altimeterCanvas.SetActive(true);
        attitudeOutline.OutlineWidth = 0;
        altimeterOutline.OutlineWidth = outlineSizeShow;

        StartCoroutine(playsoundLater(altimeterAudioClip));
        changePosition(altimeterLocation);
    }
    public void ShowTurnCoordinator()
    {
        altimeterCanvas.SetActive(false);
        turncoordinatorCanvas.SetActive(true);
        altimeterOutline.OutlineWidth = 0;
        turncoordinatorOutline.OutlineWidth = outlineSizeShow;

        StartCoroutine(playsoundLater(turncoordinatorAudioClip));
        changePosition(turncoordinatorLocation);
    }
    public void ShowVSI()
    {
        turncoordinatorCanvas.SetActive(false);
        vsiCanvas.SetActive(true);
        turncoordinatorOutline.OutlineWidth = 0;
        vsiOutline.OutlineWidth = outlineSizeShow;

        StartCoroutine(playsoundLater(vsiAudioClip));
        changePosition(vsiLocation);

    }
    public void ShowTutorialCompletion()
    {
        vsiCanvas.SetActive(false);
        completionCanvas.SetActive(true);
        vsiOutline.OutlineWidth = 0;
        completionOutline.OutlineWidth = outlineSizeShow;

        StartCoroutine(playsoundLater(completionAudioClip));
        changePosition(completionLocation);
    }

    private void changePosition(Transform pos)
    {
        playerTransfrom.position = pos.position;
        playerTransfrom.rotation = pos.rotation;
    }

    IEnumerator playsoundLater(AudioClip clipStart)
    {
        if (audioSource != null)
        {
            audioSource.Stop();
        }

        yield return new WaitForSeconds(1.0f);
        if (audioSource != null)
        {
            audioSource.Stop();
            audioSource.clip = clipStart;
            audioSource.Play();
        }
    }

    #endregion

    public void FlyPlane()
    {
        SceneManager.LoadScene("Flying Scene");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("WorkingScene");
    }

}