using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

[RequireComponent(typeof(WorldObject))]
public class FakeTerminal : Interactable
{
    [SerializeField] TimelineAsset playAfterInteraction;
    [SerializeField] TimelineManager timeline;

    public override void Interact()
    {
        timeline.PlayTimeline(playAfterInteraction);
        
        // some terminals, like the cleanerbot, don't show
        // as goals
        // if (goalMarker != null && goalIcon != null)
        // {
        //     goalMarker.SetActive(false);
        //     goalIcon.RemoveGoal(this.gameObject);
        // }
    }

    // public override string Blocker()
    // {
    //     if (alreadyConnected) return "error:connected";
    //     return "";
    // }
}
