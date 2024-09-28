using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.Playables;

public class TimelineManager : MonoBehaviour
{
    // public static TimelineManager instance { get; private set; }
    [SerializeField] PlayableDirector director;

	public bool playing { get { return director.state == PlayState.Playing; } }

    // private void Awake()
    // {
    //     if (instance != null)
    //         Debug.LogError("Found more than one Audio Manager in the scene.");

    //     instance = this;

    //     Cursor.visible = false; //this should be somewhere else lol
    // }

    public void PlayTimeline(TimelineAsset timelineToPlay)
    {
        // foreach (TimelineAsset timeline in timelines)
        // {
        //     if (timeline == timelineToPlay)
        //     {
        //         director.playableAsset = timeline;
        //         director.Play();
        //         return;
        //     }
        // }

        director.playableAsset = timelineToPlay;
        director.Play();

        // Debug.Log("Could not find timeline: " + timelineToPlay.name);
    }
}
