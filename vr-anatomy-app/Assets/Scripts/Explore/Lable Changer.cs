using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LableChanger : MonoBehaviour
{
    public TextMeshProUGUI label;

    public void setLabel()
    {
        label.text = gameObject.name;
    }
}
