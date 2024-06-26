using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using FMODUnity;

[CreateAssetMenu(menuName = "ScriptableObjects/Phone Call")]
public class PhoneScript : ScriptableObject
{
    // public FMODUnity.EventReference callSound;
    public TimelineAsset timelineToTrigger;
}
