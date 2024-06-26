using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObjectInfoLoader : MonoBehaviour
{
    public DynamicString objectInfo;
    [SerializeField] CanvasGroup subtitleCanvasGroup;
    [SerializeField] TextMeshProUGUI objectInfoTextbox;

    public void LoadObjectInfo()
    {
        if (objectInfo.Value == "")
        {
            this.GetComponent<CanvasGroup>().alpha = 0;
            subtitleCanvasGroup.alpha = 1;
            return;
        }

        this.GetComponent<CanvasGroup>().alpha = 1;
        subtitleCanvasGroup.alpha = 0;

        objectInfoTextbox.text = "RFID INFO: " + objectInfo.Value;
    }
}
