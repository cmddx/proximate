using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class AirlockMalfunction : MonoBehaviour
{
    [SerializeField] FMODUnity.StudioEventEmitter alarmEmitter;
    [SerializeField] TimelineManager defaultTimeline;
    [SerializeField] TimelineAsset navToCall;

    public void StartMalfunction()
    {
        StartCoroutine(MalfunctionRoutine());
    }

    IEnumerator MalfunctionRoutine()
    {
        yield return new WaitForSeconds(6f);

        alarmEmitter.Play();

        yield return new WaitForSeconds(7f);

        defaultTimeline.PlayTimeline(navToCall);
    }
}
