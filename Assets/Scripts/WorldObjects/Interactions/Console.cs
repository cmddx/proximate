using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

[RequireComponent(typeof(WorldObject))]
public class Console : Interactable
{
    [SerializeField] TimelineManager timeliner;
    [SerializeField] TimelineAsset timelineToPlay;
    [SerializeField] DocumentList documentList;
    [SerializeField] UploadManager uploadManager;
    [SerializeField] ConditionList gameConditions;

    bool consoleEnabled;

    void Start()
    {
        ConditionData progress = gameConditions.Get("progressIndex");

        if(progress.value == 0)
            consoleEnabled = false;
        else consoleEnabled = true;
    }

    public override void Interact()
    {
        List<DocumentData> documentsToUpload = documentList.DocumentsToUpload();

        if (documentsToUpload.Count > 0)
        {
            uploadManager.StartUpload(documentsToUpload);
            return;
        }

        timeliner.PlayTimeline(timelineToPlay);
    }

    public void EnableConsole()
    {
        consoleEnabled = true;
    }

    public override string Blocker()
    {
        if (!consoleEnabled)
        {
            return "error:" + "starting up";
        }

        return "";
    }
}
