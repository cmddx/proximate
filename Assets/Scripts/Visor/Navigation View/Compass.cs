using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compass : MonoBehaviour
{
    public DynamicFloat playerRotation;
    public List<Transform> compassLetters;

    void Update()
    {
        transform.localRotation = Quaternion.Euler(0, 0, -playerRotation.Value);

        foreach (Transform letter in compassLetters)
        {
            letter.localRotation = Quaternion.Euler(0, 0, playerRotation.Value);
        }
    }
}
