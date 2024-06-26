using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DocumentsButton : MonoBehaviour
{
    [SerializeField] GameObject notif;
    [SerializeField] TextMeshProUGUI notifCount;
    [SerializeField] DocumentList documents;

    void OnEnable()
    {
        int numDocs = 0;

        foreach (DocumentData document in documents.items)
        {
            if (document.unlocked && !document.read)
                numDocs++;
        }

        if (numDocs == 0)
        {
            notif.SetActive(false);
        }
        else if (numDocs < 10)
        {
            notif.SetActive(true);
            notifCount.text = numDocs.ToString();
        }
        else
        {
            notif.SetActive(true);
            notifCount.text = "+";
        }
    }
}
