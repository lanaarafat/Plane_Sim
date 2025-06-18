using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialUI : MonoBehaviour
{
    public GameObject welcomePanel, propellerPanel, landinggearPanel, wingsPanel, aileronsPanel, flapsPanel, empennagePanel, elevatorPanel, rudderPanel, yokePanel, throttlePanel, mixturePanel, flapleverPanel, rudderpedalsPanel, masterswitchPanel, fuelselectorPanel, magnetosPanel, airspeedindicatorPanel, attitudePanel, altimeterPanel, turncordinatorPanel, headingindicatorPanel, vsiPanel, completionPanel;
    // public RawImage fadePanel; // UI Image for fade effect

    public void Start()
    {
        ShowPanel(welcomePanel); // Start with Welcome Panel
    }

    public void ShowPropeller()
    {
        ShowPanel(propellerPanel);
    }

    public void ShowLandingGear()
    {
        ShowPanel(landinggearPanel);
    }

    public void ShowWings()
    {
        ShowPanel(wingsPanel);
    }

    public void ShowAirelons()
    {
        ShowPanel(aileronsPanel);
    }

    public void ShowFlaps()
    {
        ShowPanel(flapsPanel);
    }

    public void ShowEmpennage()
    {
        ShowPanel(empennagePanel);
    }
    public void ShowElevator()
    {
        ShowPanel(elevatorPanel);
    }

    public void ShowRudder()
    {
        ShowPanel(rudderPanel);
    }

    public void ShowYoke()
    {
        ShowPanel(yokePanel);
    }
    public void ShowAirspeedIndicator()
    {
        ShowPanel(airspeedindicatorPanel);
    }
    public void ShowAttitudeIndicator()
    {
        ShowPanel(attitudePanel);
    }
    public void ShowAltimeter()
    {
        ShowPanel(altimeterPanel);
    }
    public void ShowTurnCordinator()
    {
        ShowPanel(turncordinatorPanel);
    }
    public void ShowVSI()
    {
        ShowPanel(vsiPanel);
    }
    public void ShowTutorialCompletion()
    {
        ShowPanel(completionPanel);
    }

    public void FlyPlane()
    {
        SceneManager.LoadScene("FlyingScene");
    }

    private void ShowPanel(GameObject panel)
    {
        welcomePanel.SetActive(false);
        propellerPanel.SetActive(false);
        landinggearPanel.SetActive(false);
        wingsPanel.SetActive(false);
        aileronsPanel.SetActive(false);
        flapsPanel.SetActive(false);
        empennagePanel.SetActive(false);
        elevatorPanel.SetActive(false);
        rudderPanel.SetActive(false);
        yokePanel.SetActive(false);
        throttlePanel.SetActive(false);
        mixturePanel.SetActive(false);
        flapleverPanel.SetActive(false);
        rudderpedalsPanel.SetActive(false);
        masterswitchPanel.SetActive(false);
        fuelselectorPanel.SetActive(false);
        magnetosPanel.SetActive(false);
        airspeedindicatorPanel.SetActive(false);
        attitudePanel.SetActive(false);
        altimeterPanel.SetActive(false);
        turncordinatorPanel.SetActive(!false);
        headingindicatorPanel.SetActive(!false);
        vsiPanel.SetActive(!false);
        completionPanel.SetActive(false);



        panel.SetActive(true);
    }
}