using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using FMODUnity;

public class IdentifiedObject : MonoBehaviour
{
    public DynamicString targetName;
    public TextMeshProUGUI targetNameText;

    public void UpdateTargetNameText()
    {
        targetNameText.text = targetName.Value;
    }
}
