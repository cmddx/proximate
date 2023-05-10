using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Proximity : MonoBehaviour
{
    public DynamicFloat targetDistance;
    public TextMeshProUGUI targetDistanceText;

    void Update()
    {
        string distance = targetDistance.Value.ToString("F2");
        targetDistanceText.text = distance + "m";
    }
}
