using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CyclingObjectChange : MonoBehaviour
{
    [SerializeField] List<string> objectNames;
    [SerializeField] float period;
    WorldObject worldObject;
    float time = 0;
    int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        worldObject = GetComponent<WorldObject>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time >= period)
        {
            time = 0;

            worldObject.visorName = objectNames[index];

            index++;
            index = index % objectNames.Count;
        }
    }
}
