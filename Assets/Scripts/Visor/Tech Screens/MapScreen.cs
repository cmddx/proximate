using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class MapScreen : MonoBehaviour
{
    [SerializeField] TimelineManager timeliner;
    [SerializeField] TimelineAsset mapToConsole;
    [SerializeField] TimelineAsset mapToDownload;
    [SerializeField] DownloadManager downloadManager;
    [SerializeField] List<GameObject> mapDocuments;
    [SerializeField] ConditionList conditionList;
    [SerializeField] GameObject downloadButton;

    void OnEnable()
    {
        ConditionData downloaded = conditionList.
            FindItemFromReferenceName("mapDownloaded");
        if (downloaded.value == 1) downloadButton.SetActive(false);
    }

    public void BackToConsole()
    {
        timeliner.PlayTimeline(mapToConsole);
    }

    public void DownloadMap()
    {
        timeliner.PlayTimeline(mapToDownload);

        downloadManager.StartDownload(mapDocuments, true);

        ConditionData condition = conditionList.
            FindItemFromReferenceName("mapDownloaded");
        condition.value = 1;
    }
}
