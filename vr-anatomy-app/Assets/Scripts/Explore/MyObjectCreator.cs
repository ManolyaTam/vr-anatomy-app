using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCreator : MonoBehaviour
{
    public GameObject labelPrefab;
    public GameObject labelsParent;

    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                // creating an instance of the prefab
                // then making it a child of the labelsParent
                // Quaternion = rotaions, identity = default values
                Instantiate(labelPrefab, new Vector3(i + 2, j + 2, 2), Quaternion.identity).transform.parent = labelsParent.transform;

            }
        }
    }
}