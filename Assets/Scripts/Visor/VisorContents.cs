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
    float cooldown;

    void Update()
    {
        cooldown -= Time.deltaTime;

        if (cooldown > 0) return;

        if (ProxInput.Map && canOpenMap.value && !mapUp)
        {
            defaultTimeline.PlayTimeline(navToMap);
            mapUp = true;

            cooldown = 0.5f;
        }
        else if (ProxInput.Map && mapUp)
        {
            defaultTimeline.PlayTimeline(mapToNav);
            mapUp = false;

            cooldown = 0.5f;
        }
    }
}
