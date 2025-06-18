using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject welcomePanel, mainMenuPanel, planeSelectPanel, notesPanel, locationPanel, weatherPanel;
    // public RawImage fadePanel; // UI Image for fade effect

    public void Start()
    {
        ShowPanel(welcomePanel); // Start with Welcome Panel
    }

    public void ShowMainMenu()
    {
        ShowPanel(mainMenuPanel);
    }

    public void ShowPlaneSelect()
    {
        ShowPanel(planeSelectPanel);
    }

    public void ShowNotes()
    {
        ShowPanel(notesPanel);
    }

    public void ShowWeatherPanel()
    {
        ShowPanel(weatherPanel);
    }

    public void ShowLocationPanel()
    {
        ShowPanel(locationPanel);
    }

    public void Tutorial()
    {
        SceneManager.LoadScene("TutorialScene");
    }

    public void FlyPlane()
    {
        SceneManager.LoadScene("FlyingScene");
    }

    private void ShowPanel(GameObject panel)
    {
        welcomePanel.SetActive(false);
        mainMenuPanel.SetActive(false);
        planeSelectPanel.SetActive(false);
        notesPanel.SetActive(false);
        locationPanel.SetActive(false);
        weatherPanel.SetActive(false);

        panel.SetActive(true);
    }
}