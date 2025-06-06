using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MasterSwitchController : MonoBehaviour
{
    [Header("Switch Settings")]
    [SerializeField] private bool isOn = false;

    [Header("Visuals")]
    [SerializeField] private Transform switchLever;
    [SerializeField] private float offAngle = 0f;
    [SerializeField] private float onAngle = 45f;

    [Header("XR Interaction")]
    [SerializeField] private XRBaseInteractable interactable;

    private void OnEnable()
    {
        if (interactable != null)
        {
            interactable.selectEntered.AddListener(OnSwitchToggled);
        }
    }

    private void OnDisable()
    {
        if (interactable != null)
        {
            interactable.selectEntered.RemoveListener(OnSwitchToggled);
        }
    }

    private void OnSwitchToggled(SelectEnterEventArgs args)
    {
        isOn = !isOn;
        UpdateSwitchVisual();
        // You can add event callbacks here to notify other systems of the switch state change
    }

    private void UpdateSwitchVisual()
    {
        if (switchLever != null)
        {
            float targetAngle = isOn ? onAngle : offAngle;
            switchLever.localRotation = Quaternion.Euler(targetAngle, 0f, 0f);
        }
    }

    public bool IsSwitchOn()
    {
        return isOn;
    }
}
