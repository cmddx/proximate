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
    bool consoleEnabled;

    void Start()
    {
        consoleEnabled = false;
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
