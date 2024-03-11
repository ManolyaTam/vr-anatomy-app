using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BodyPart : MonoBehaviour
{
    public string partName;
    public string description;
    public GameObject infoPanel;
    public TextMeshProUGUI label;
    public TextMeshProUGUI info;

    private void Start()
    {
        infoPanel.SetActive(false);
    }
    public void ShowInfo()
    {
        infoPanel.SetActive(true);
        label.text = partName;
        info.text = description;
    }
    public void HideInfo()
    {
        infoPanel.SetActive(false);
    }
}
