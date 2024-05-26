using TMPro;
using UnityEngine;

public class Part : MonoBehaviour
{
    public OrganInfo partInfo;

    public void ShowInfo(TextMeshProUGUI info)
    {
        info.text = partInfo.description;
    }

}
