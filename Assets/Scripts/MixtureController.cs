using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MixtureController : MonoBehaviour
{
    [Header("Mixture Lever")]
    [SerializeField] private Transform mixtureLever;
    [SerializeField] private XRBaseInteractable mixtureInteractable;

    [Header("Mixture Positions")]
    [SerializeField] private Transform cutoffPosition;   // Engine off
    [SerializeField] private Transform idlePosition;     // Idle mixture
    [SerializeField] private Transform richPosition;     // Full rich mixture

    private enum MixtureSetting { Cutoff, Idle, Rich }
    private MixtureSetting currentSetting = MixtureSetting.Cutoff;

    private void OnEnable()
    {
        if (mixtureInteractable != null)
            mixtureInteractable.selectEntered.AddListener(SwitchMixtureSetting);
    }

    private void OnDisable()
    {
        if (mixtureInteractable != null)
            mixtureInteractable.selectEntered.RemoveListener(SwitchMixtureSetting);
    }

    private void SwitchMixtureSetting(SelectEnterEventArgs args)
    {
        // Cycle through: Cutoff -> Idle -> Rich -> Cutoff ...
        currentSetting = currentSetting switch
        {
            MixtureSetting.Cutoff => MixtureSetting.Idle,
            MixtureSetting.Idle => MixtureSetting.Rich,
            MixtureSetting.Rich => MixtureSetting.Cutoff,
            _ => MixtureSetting.Cutoff
        };

        UpdateLeverPosition();
        // You can add events or notify engine controller here about mixture changes
    }

    private void UpdateLeverPosition()
    {
        switch (currentSetting)
        {
            case MixtureSetting.Cutoff:
                mixtureLever.position = cutoffPosition.position;
                mixtureLever.rotation = cutoffPosition.rotation;
                break;
            case MixtureSetting.Idle:
                mixtureLever.position = idlePosition.position;
                mixtureLever.rotation = idlePosition.rotation;
                break;
            case MixtureSetting.Rich:
                mixtureLever.position = richPosition.position;
                mixtureLever.rotation = richPosition.rotation;
                break;
        }
    }
}
