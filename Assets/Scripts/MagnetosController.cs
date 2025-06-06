using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MagnetosController : MonoBehaviour
{
    [Header("Magneto 1")]
    [SerializeField] private Transform magneto1Lever;
    [SerializeField] private XRBaseInteractable magneto1Interactable;
    [SerializeField] private float offAngle1 = 0f;
    [SerializeField] private float onAngle1 = 45f;
    private bool magneto1On = false;

    [Header("Magneto 2")]
    [SerializeField] private Transform magneto2Lever;
    [SerializeField] private XRBaseInteractable magneto2Interactable;
    [SerializeField] private float offAngle2 = 0f;
    [SerializeField] private float onAngle2 = 45f;
    private bool magneto2On = false;

    private void OnEnable()
    {
        if (magneto1Interactable != null)
            magneto1Interactable.selectEntered.AddListener(ToggleMagneto1);

        if (magneto2Interactable != null)
            magneto2Interactable.selectEntered.AddListener(ToggleMagneto2);
    }

    private void OnDisable()
    {
        if (magneto1Interactable != null)
            magneto1Interactable.selectEntered.RemoveListener(ToggleMagneto1);

        if (magneto2Interactable != null)
            magneto2Interactable.selectEntered.RemoveListener(ToggleMagneto2);
    }

    private void ToggleMagneto1(SelectEnterEventArgs args)
    {
        magneto1On = !magneto1On;
        UpdateMagnetoVisual(magneto1Lever, magneto1On, onAngle1, offAngle1);
    }

    private void ToggleMagneto2(SelectEnterEventArgs args)
    {
        magneto2On = !magneto2On;
        UpdateMagnetoVisual(magneto2Lever, magneto2On, onAngle2, offAngle2);
    }

    private void UpdateMagnetoVisual(Transform lever, bool isOn, float onAngle, float offAngle)
    {
        if (lever != null)
        {
            float angle = isOn ? onAngle : offAngle;
            lever.localRotation = Quaternion.Euler(angle, 0f, 0f);
        }
    }

    public bool IsMagneto1On() => magneto1On;
    public bool IsMagneto2On() => magneto2On;
}
