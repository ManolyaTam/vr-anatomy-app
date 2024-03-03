using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasAttacher : MonoBehaviour
{
    public GameObject canvasPrefab;

    void Start()
    {
        // Find all objects with a specific tag
        GameObject[] objects = GameObject.FindGameObjectsWithTag("organ");

        // Iterate through each object
        foreach (GameObject obj in objects)
        {
            // Instantiate the Canvas prefab
            GameObject newCanvas = Instantiate(canvasPrefab, obj.transform.position, Quaternion.identity, obj.transform);

            // adjust the Canvas position and rotation relative to the object 
            newCanvas.transform.localPosition = new Vector3(
                obj.transform.position.x, obj.transform.localPosition.y + 50, obj.transform.localPosition.z
            );
            newCanvas.transform.localRotation = obj.transform.rotation;

        }
    }
}
