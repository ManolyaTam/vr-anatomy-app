using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ObjectClickHandler : MonoBehaviour
{
    private XRBaseInteractor interactor;

    private void OnEnable()
    {
        interactor = FindObjectOfType<XRBaseInteractor>();

        if (interactor != null)
        {
            interactor.selectEntered.AddListener(OnSelectEntered);
        }
    }

    private void OnDisable()
    {
        if (interactor != null)
        {
            interactor.selectEntered.RemoveListener(OnSelectEntered);
        }
    }

    private void OnSelectEntered(SelectEnterEventArgs args)
    {
        if (args.interactableObject.transform == transform)
        {
            Debug.Log("Clicking on " + gameObject.name);
        }
    }
}
