using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UI;
using TMPro;
using FMOD.Studio;

public class DownloadManager : MonoBehaviour
{
    [SerializeField] TimelineManager defaultTimeline;
    [SerializeField] TimelineAsset navToDown;
    [SerializeField] TimelineAsset downToNav;
    [SerializeField] DocumentList documentList;
    [SerializeField] Slider downloadBar;
    [SerializeField] TextMeshProUGUI documentText;
    [SerializeField] FMODUnity.EventReference downloadSound;
    [SerializeField] FMODUnity.EventReference finishedSound;

    List<GameObject> documentsToDownload;
    bool comingFromMapView;
    bool isSonaVisor;
    TimelineAsset playAfterDownload;

    public void StartDownload(List<GameObject> _documentsToDownload,
        bool _comingFromMapView = false,
        bool _isSonaVisor = false,
        TimelineAsset _playAfterDownload = null)
    {
        if (!_comingFromMapView)
            defaultTimeline.PlayTimeline(navToDown);

        documentsToDownload = _documentsToDownload;
        comingFromMapView = _comingFromMapView;
        isSonaVisor = _isSonaVisor;

        // sometimes we want a special event to happen after the download,
        // like a phone call or a noise. otherwise, we just return to
        // nav view normally
        if (_playAfterDownload == null)
        {
            playAfterDownload = downToNav;
        }
        else playAfterDownload = _playAfterDownload;

        foreach (GameObject document in _documentsToDownload)
        {
            if (comingFromMapView) return;

            DocumentData foundDoc = documentList.
                FindItemFromReferenceName(document.name);

            if (foundDoc == null)
            {
                Debug.LogError("Couldn't find document " + document.name);
                return;
            }

            foundDoc.unlocked = true;
        }
    }

    void OnEnable()
    {
        GetComponent<CanvasGroup>().alpha = 1;
        StartCoroutine(DownloadBar());
    }

    IEnumerator DownloadBar()
    {
        int numDocs = documentsToDownload.Count;

        float t = 0.0f;
        float intervalLength = 2;
        if (comingFromMapView) intervalLength = 3;

        float intervalTicker = intervalLength;
        int intervalCount = 0;


        while (t <= numDocs * intervalLength)
        {
            t += Time.deltaTime;
            intervalTicker += Time.deltaTime;

            downloadBar.value = Mathf.Lerp(0, 1, t / (numDocs * intervalLength));

            if (intervalTicker >= intervalLength)
            {
                if (intervalCount == numDocs) break; // fixes a potential race condition

                if (!isSonaVisor)
                {
                    documentText.text = documentsToDownload[intervalCount].
                        name.Substring(3);

                    AudioManager.instance.PlayOneShot(downloadSound);

                    intervalTicker = 0f;
                    intervalCount++;
                }
                else
                {
                    isSonaVisor = false;
                    numDocs++;

                    documentText.text = "Skipping duplicates";

                    AudioManager.instance.PlayOneShot(downloadSound);

                    intervalTicker = 0f;
                }
            }

            yield return null;
        }

        if (!comingFromMapView)
            defaultTimeline.PlayTimeline(playAfterDownload);

        AudioManager.instance.PlayOneShot(finishedSound);
    }
}
