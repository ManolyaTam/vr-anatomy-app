using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LabelChanger : MonoBehaviour
{
    public TextMeshProUGUI label;

    public void setLabel()
    {
        label.text = gameObject.name;
    }
}
