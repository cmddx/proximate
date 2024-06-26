using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class VisorContents : MonoBehaviour
{
    [SerializeField] TimelineManager defaultTimeline;
    [SerializeField] TimelineAsset navToMap;
    [SerializeField] TimelineAsset mapToNav;
    [SerializeField] ScriptableBool canOpenMap;
    bool mapUp;

    void Update()
    {
        if (Input.GetMouseButtonDown(1) && canOpenMap.value)
        {
            defaultTimeline.PlayTimeline(navToMap);
            mapUp = true;
        }
        else if (Input.GetMouseButtonUp(1) && mapUp)
        {
            defaultTimeline.PlayTimeline(mapToNav);
            mapUp = false;
        }
    }
}
