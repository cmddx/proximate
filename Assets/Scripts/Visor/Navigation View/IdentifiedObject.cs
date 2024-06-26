using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using FMODUnity;

public class IdentifiedObject : MonoBehaviour
{
    public DynamicString targetName;
    public TextMeshProUGUI targetNameText;
    [SerializeField] ScriptableBool dogMode;

    void OnEnable()
    {
        UpdateTargetNameText();
    }

    public void UpdateTargetNameText()
    {
        if (dogMode.value)
        {
            targetNameText.text = "dog";
        }
        else targetNameText.text = targetName.Value;
    }
}
