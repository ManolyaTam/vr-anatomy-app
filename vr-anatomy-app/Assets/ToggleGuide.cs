using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggleGuide : MonoBehaviour
{
    private GameObject[] guideObjects;
    private bool guideIsActive = true;
    void Start()
    {
        guideObjects = GameObject.FindGameObjectsWithTag("guideObject");

    }
    public void OnToggle()
    {
        guideIsActive = !guideIsActive;
        foreach (GameObject obj in guideObjects) {
            obj.SetActive(guideIsActive);
        }
    }
}
