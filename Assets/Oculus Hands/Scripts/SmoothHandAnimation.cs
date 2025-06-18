using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Hands.Scripts
{
    public class SmoothHandAnimation : MonoBehaviour
    {
        [SerializeField] private Animator handAnimator;
        [SerializeField] private InputActionReference triggerActionRef;
        [SerializeField] private InputActionReference gripActionRef;

        private static readonly int TriggerAnimation = Animator.StringToHash(name: "Trigger");
        private static readonly int GripAnimation = Animator.StringToHash(name: "Grip");


        // Update is called once per frame
        private void Update()
        {
            float triggerValue = triggerActionRef.action.ReadValue<float>();
            handAnimator.SetFloat(id: TriggerAnimation, triggerValue);

            float gripValue = gripActionRef.action.ReadValue<float>();
            handAnimator.SetFloat(id: GripAnimation, gripValue);
        }
    }
}
