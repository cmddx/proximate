using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Timeline;

public class ProgressUnlocker : MonoBehaviour
{
    [SerializeField] List<TimelineAsset> unlockNotifs;
    [SerializeField] TimelineManager subtitleTimeline;
    [SerializeField] ConditionList conditions;
    [SerializeField] GoalMarkers goalMarkersNav;
    [SerializeField] GoalMarkers goalMarkersConsole;
    [SerializeField] GoalIcon goalIcons;
    [SerializeField] SaveController saveController;
    ConditionData progressIndex;

    void Start()
    {
        foreach (ConditionData condition in conditions.items)
        {
            if (condition.conditionName == "progressIndex")
            {
                progressIndex = condition;
            }
        }

        if(progressIndex.value == 9) return;

        goalMarkersNav.UnlockNextMarkers(progressIndex.value);
        goalMarkersConsole.UnlockNextMarkers(progressIndex.value);
        goalIcons.SetCurrentGoals(progressIndex.value);
    }

    public void NextStage()
    {
        StartCoroutine(ShowNotif(progressIndex.value));

        progressIndex.value++;
        saveController.SaveGame();

        if(progressIndex.value == 9) return;

        goalMarkersNav.UnlockNextMarkers(progressIndex.value);
        goalMarkersConsole.UnlockNextMarkers(progressIndex.value);
        goalIcons.SetCurrentGoals(progressIndex.value);
        this.GetComponent<EnvironmentProgession>().UpdateEnvironment();
    }

    IEnumerator ShowNotif(int progressIndex)
    {
        yield return new WaitForSeconds(0.8f);
        subtitleTimeline.PlayTimeline(unlockNotifs[progressIndex]);
    }
}
