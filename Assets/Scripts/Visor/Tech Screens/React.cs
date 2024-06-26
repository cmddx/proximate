using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class React : MonoBehaviour
{
    [TextArea]
    [SerializeField] string reactNames;

    TextMeshProUGUI docNameText;
    string docName;

    void Start()
    {
        docNameText = GameObject.FindWithTag("DocumentName").
            GetComponent<TextMeshProUGUI>();

        if (reactNames.Length > 30)
        {
            reactNames = reactNames[..30] + "...";
        }
    }

    public void ShowNames()
    {
        docName = docNameText.text;
        docNameText.text = reactNames;
    }

    public void HideNames()
    {
        docNameText.text = docName;
    }
}
