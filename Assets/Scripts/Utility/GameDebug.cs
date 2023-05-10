using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameDebug : MonoBehaviour
{
    public DynamicString targetName;
    public DynamicFloat targetDistance;
    public List<TextMeshProUGUI> textBoxes;

    void Update()
    {
        textBoxes[0].text = targetName.Value;
        string distance = targetDistance.Value.ToString("F2");
        textBoxes[1].text = distance + "m";
    }
}
