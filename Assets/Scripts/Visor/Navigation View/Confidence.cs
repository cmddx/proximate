using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Confidence : MonoBehaviour
{
    public DynamicFloat targetConfidence;
    public TextMeshProUGUI targetConfidenceText;
    [SerializeField] ScriptableBool dogMode;

    void Update()
    {
        string confidence = "";
        if (dogMode.value)
        {
            confidence = "100";
        }
        else confidence = targetConfidence.Value.ToString("F1");

        targetConfidenceText.text = confidence + "%";
    }
}
