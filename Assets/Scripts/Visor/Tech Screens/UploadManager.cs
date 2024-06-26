using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UI;
using TMPro;
using FMOD.Studio;

public class UploadManager : MonoBehaviour
{
    [SerializeField] TimelineManager defaultTimeline;
    [SerializeField] TimelineAsset navToUp;
    [SerializeField] TimelineAsset upToDocs;
    [SerializeField] DocumentList documentList;
    [SerializeField] DocumentView documentView;
    [SerializeField] Slider downloadBar;
    [SerializeField] TextMeshProUGUI documentText;
    [SerializeField] FMODUnity.EventReference downloadSound;
    [SerializeField] FMODUnity.EventReference finishedSound;
    [SerializeField] ProgressUnlocker progressUnlocker;


    List<DocumentData> documentsToUpload;

    public void StartUpload(List<DocumentData> _documentsToUpload)
    {
        defaultTimeline.PlayTimeline(navToUp);

        documentsToUpload = _documentsToUpload;

        foreach (DocumentData document in _documentsToUpload)
        {
            DocumentData foundDoc = documentList.
                FindItemFromReferenceName(document.documentPrefab.name);

            if (foundDoc == null)
            {
                Debug.LogError("Couldn't find document " +
                    document.documentPrefab.name);
                return;
            }

            foundDoc.uploaded = true;
        }
    }

    void OnEnable()
    {
        StartCoroutine(UploadBar());
    }

    IEnumerator UploadBar()
    {
        int numDocs = documentsToUpload.Count;

        float t = 0.0f;
        float intervalLength = 0.8f;

        float intervalTicker = intervalLength;
        int intervalCount = 0;


        while (t <= numDocs * intervalLength)
        {
            t += Time.deltaTime;
            intervalTicker += Time.deltaTime;

            downloadBar.value = Mathf.Lerp(0, 1, t / (numDocs * intervalLength));

            if (intervalTicker >= intervalLength)
            {
                documentText.text = documentsToUpload[intervalCount].
                    documentPrefab.name.Substring(3);

                AudioManager.instance.PlayOneShot(downloadSound);

                intervalTicker = 0f;
                intervalCount++;
            }

            yield return null;
        }

        documentView.SetUpDoc(documentsToUpload[0]);

        defaultTimeline.PlayTimeline(upToDocs);
        AudioManager.instance.PlayOneShot(finishedSound);

        if (ContinuityCheck()) progressUnlocker.NextStage();
    }

    bool ContinuityCheck()
    {
        bool continuous = true;
        bool missingDoc = false;

        // starting from 2 because the first two items in
        // the document list are used by the map
        for (int i = 2; i < documentList.items.Count; i++)
        {
            DocumentData document = documentList.items[i];

            if (document.unlocked == false)
            {
                missingDoc = true;
                continue;
            }

            if (document.unlocked && missingDoc)
            {
                continuous = false;
                break;
            }
        }

        return continuous;
    }
}
