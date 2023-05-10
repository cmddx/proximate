using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.Playables;

public class TimelineManager : MonoBehaviour
{
    public static TimelineManager instance { get; private set; }
    [SerializeField] List<TimelineAsset> timelines;
    [SerializeField] PlayableDirector director;

    private void Awake()
    {
        if (instance != null)
            Debug.LogError("Found more than one Audio Manager in the scene.");

        instance = this;

        Cursor.visible = false; //this should be somewhere else lol
    }

    public void PlayTimeline(TimelineAsset timelineToPlay)
    {
        foreach (TimelineAsset timeline in timelines)
        {
            if (timeline == timelineToPlay)
            {
                director.playableAsset = timeline;
                director.Play();
                return;
            }
        }

        Debug.Log("Could not find timeline: " + timelineToPlay.name);
    }
}
