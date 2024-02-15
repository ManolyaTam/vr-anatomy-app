using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandAnimatorController : MonoBehaviour
{
    [SerializeField] private InputActionProperty triggerAction;
    [SerializeField] private InputActionProperty gripAction;

    private Animator anim;

    private void Start()
    {
        
    }
    private void Update()
    {
        float triggerVlaue = triggerAction.action.ReadValue<float>();
        float gripVlaue = gripAction.action.ReadValue<float>();

        anim.SetFloat("Trigger", triggerVlaue);
        anim.SetFloat("Grip", gripVlaue);
    }
}
