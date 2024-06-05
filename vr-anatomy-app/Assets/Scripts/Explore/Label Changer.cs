using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LabelChanger : MonoBehaviour
{
    public TextMeshProUGUI label;

    public void setLabel()
    {
        if (label != null)
        {
            label.text = gameObject.name;
        }
        else
        {
            Debug.Log("missing reference at gameObject " + gameObject.name);
        }
    }
}
