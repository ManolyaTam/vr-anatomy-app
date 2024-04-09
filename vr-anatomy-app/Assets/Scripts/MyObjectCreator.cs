using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCreator : MonoBehaviour
{
    public GameObject label;
    public GameObject labelsParent;

    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                Instantiate(label, new Vector3(i + 2, j + 2, 2), Quaternion.identity).transform.parent = labelsParent.transform;
            }

        }
    }
}
