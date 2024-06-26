using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

[RequireComponent(typeof(WorldObject))]
public class TerminalWithBlocker : Interactable
{
    [SerializeField] List<GameObject> documents;
    [SerializeField] DownloadManager downloadManager;

    // optional, a timeline that controls a special
    // action after the download is done
    [SerializeField] TimelineAsset playAfterDownload;
    [SerializeField] GameObject goalMarker;
    [SerializeField] GameObject alternativeGoal;
    [SerializeField] GoalIcon goalIcon;
    public int progressIndexRequirement;
    public ConditionList conditionList;
    public string blockerName;


    bool alreadyConnected;

    public override void Interact()
    {
        downloadManager.StartDownload(documents,
            _playAfterDownload: playAfterDownload,
            _isSonaVisor: gameObject.name == "Visor");
        alreadyConnected = true;

        // some terminals, like the cleanerbot, don't show
        // as goals
        if (goalMarker != null && goalIcon != null)
        {
            goalMarker.SetActive(false);

            if (alternativeGoal != null)
                goalIcon.RemoveGoal(alternativeGoal);
            else goalIcon.RemoveGoal(this.gameObject);
        }
    }

    public override string Blocker()
    {
        if (alreadyConnected) return "error:connected";

        ConditionData condition = conditionList.
        FindItemFromReferenceName("progressIndex");

        if (condition.value < progressIndexRequirement)
        {
            return "error:" + blockerName;
        }

        return "";
    }
}
