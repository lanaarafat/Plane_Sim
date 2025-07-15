using UnityEngine;
using UnityEngine.XR;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuOpener : MonoBehaviour
{
    [SerializeField] private GameObject menuCanvas;

    private InputDevice leftHand;
    private bool menuButtonPreviouslyPressed = false;

    private void Start()
    {
        TryInitializeLeftHand();
    }

    private void TryInitializeLeftHand()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesAtXRNode(XRNode.LeftHand, devices);
        if (devices.Count > 0)
        {
            leftHand = devices[0];
        }
    }

    private void Update()
    {
        if (!leftHand.isValid)
            TryInitializeLeftHand();

        if (leftHand.TryGetFeatureValue(CommonUsages.menuButton, out bool isPressed))
        {
            if (isPressed && !menuButtonPreviouslyPressed)
            {
                // Toggle menu on button press
                if (menuCanvas != null)
                    menuCanvas.SetActive(!menuCanvas.activeSelf);
            }

            menuButtonPreviouslyPressed = isPressed;
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("WorkingScene");
    }
}
