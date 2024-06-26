using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class BathroomFlooder : MonoBehaviour
{
    [SerializeField] TimelineManager subtitleTimeline;
    [SerializeField] TimelineAsset toiletVoice;
    [SerializeField] Door leftDoor;
    [SerializeField] Door rightDoor;

    // float doorMalfunctionDelay = 1;

    public void StartFlooding()
    {
        subtitleTimeline.PlayTimeline(toiletVoice);

        leftDoor.blockerName = "emergency lock - flooding detected";
        rightDoor.blockerName = "emergency lock - flooding detected";

        leftDoor.progressIndexRequirement = 100;

        // StartCoroutine(DoorsMalfunction());
    }

    // IEnumerator DoorsMalfunction()
    // {
    //     yield return new WaitForSeconds(doorMalfunctionDelay);

    //     leftDoor.blockerName = "emergency lock - flooding detected";
    //     rightDoor.blockerName = "emergency lock - flooding detected";

    //     leftDoor.progressIndexRequirement = 100;
    // }
}
