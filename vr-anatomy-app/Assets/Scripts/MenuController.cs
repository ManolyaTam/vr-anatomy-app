using UnityEngine;
using UnityEngine.InputSystem;

public class MenuController : MonoBehaviour
{
    public GameObject menuPanel;
    public InputActionReference openMenuAction;

    private void Awake()
    {
        openMenuAction.action.Enable();
        openMenuAction.action.performed += ToggleMenu;
        InputSystem.onDeviceChange += onDeviceChange;
    }

    private void onDestroy()
    {
        openMenuAction.action.Disable();
        openMenuAction.action.performed -= ToggleMenu;
        InputSystem.onDeviceChange -= onDeviceChange;
    }

    private void ToggleMenu(InputAction.CallbackContext context)
    {
        menuPanel.SetActive(!menuPanel.activeSelf);
    }

    private void onDeviceChange(InputDevice device, InputDeviceChange change)
    {
        switch (change)
        {
            case InputDeviceChange.Disconnected:
                openMenuAction.action.Disable();
                openMenuAction.action.performed -= ToggleMenu;
                break;
            case InputDeviceChange.Reconnected:
                openMenuAction.action.Enable();
                openMenuAction.action.performed += ToggleMenu;
                break;
        }
    }

}