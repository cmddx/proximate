using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Confidence : MonoBehaviour
{
    public DynamicFloat targetConfidence;
    public TextMeshProUGUI targetConfidenceText;

    void Update()
    {
        string confidence = targetConfidence.Value.ToString("F1");
        targetConfidenceText.text = confidence + "%";
    }
}
