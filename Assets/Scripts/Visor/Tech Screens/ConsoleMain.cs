using System.Collections;
using System.Collections.Generic;
using UnityEngine.Timeline;
using UnityEngine;

public class ConsoleMain : MonoBehaviour
{
    [SerializeField] TechScreens techScreens;
    [SerializeField] TimelineManager defaultTimeline;
    [SerializeField] TimelineManager subtitleTimeline;
    [SerializeField] TimelineAsset consoleToDocList;
    [SerializeField] TimelineAsset undockError;
    [SerializeField] TimelineAsset airlockError;
    [SerializeField] TimelineAsset airlockUnlock;
    [SerializeField] TimelineAsset consoleToNav;
    [SerializeField] TimelineAsset consoleToCall;
    [SerializeField] FMODUnity.StudioEventEmitter unlockBottomEmitter;
    [SerializeField] ConditionList conditions;
    bool finalCallPlayed = false;

    public void OpenDocList()
    {
        defaultTimeline.PlayTimeline(consoleToDocList);
    }

    public void ShowUndockError()
    {
        subtitleTimeline.PlayTimeline(undockError);
    }

    public void UnlockAirlock()
    {
        ConditionData condition = conditions.
            Get("bottomAirlockUnlocked");

        if (condition.value == 1)
        {
            subtitleTimeline.PlayTimeline(airlockError);
            techScreens.PlayError();
            return;
        }

        condition.value = 1;

        unlockBottomEmitter.Play();
        subtitleTimeline.PlayTimeline(airlockUnlock);

        condition = conditions.
            Get("topAirlockUnlocked");
        condition.value = 0;
    }

    public void ExitConsole()
    {
        int progressIndex = conditions.
            Get("progressIndex").value;

        if (!finalCallPlayed && progressIndex == 9)
        {
            defaultTimeline.PlayTimeline(consoleToCall);
            finalCallPlayed = true;
        }
        else defaultTimeline.PlayTimeline(consoleToNav);
    }
}
