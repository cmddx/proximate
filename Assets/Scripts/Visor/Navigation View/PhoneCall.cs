using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class PhoneCall : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float minimumPos;
    [SerializeField] float maximumPos;
    [SerializeField] TimelineManager defaultTimeline;
    [SerializeField] TimelineManager subtitleTimeline;
    [SerializeField] TimelineAsset callToNav;
    [SerializeField] RectTransform slideTransform;
    [SerializeField] FMODUnity.EventReference pickupSound;
    [SerializeField] List<PhoneScript> phoneScripts;
    [SerializeField] ConditionList conditions;


    // kinda hacky: since calls progress linearly, we decide
    // which call to play next by just updaitng this index
    ConditionData currentCallIndex;

    float slidePos;
    bool inCall;

    void OnEnable()
    {
        // disgusting method for resetting the call screen after
        // it's already been animated before.
        // i could have done this a better way, but my sins are now
        // too vile to ever be atoned for

        RectTransform rectT = GetComponent<RectTransform>();
        rectT.localPosition = new Vector3(0.33f, 1, 0);

        GetComponent<UnityEngine.UI.Image>().color = new
            Color(255, 255, 225, 100);

        UnityEngine.UI.Image[] images =
            GetComponentsInChildren<UnityEngine.UI.Image>();
        foreach (UnityEngine.UI.Image image in images)
        {
            image.color = new
            Color(255, 255, 225, 100);
        }

        CanvasGroup[] canvasGroups = GetComponentsInChildren<CanvasGroup>();
        foreach (CanvasGroup canvasGroup in canvasGroups)
        {
            canvasGroup.alpha = 1;
        }

        slidePos = 0;
        slideTransform.localPosition = new Vector3(0.31f,
            slideTransform.localPosition.y, slideTransform.localPosition.z);

        RectTransform portrait = transform.Find("Portrait") as RectTransform;
        portrait.localPosition = new Vector3(-137, 84, 0);
        portrait.sizeDelta = new Vector2(150, 150);

        inCall = false;
    }

    void Start()
    {
        foreach (ConditionData condition in conditions.items)
        {
            if (condition.conditionName == "callIndex")
            {
                currentCallIndex = condition;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (inCall) return;

        float slideChange = ProxInput.Look.x;

        if (slidePos >= minimumPos && slideChange < 0
            || slideChange > minimumPos)
        {
            slidePos += slideChange * speed;
        }

        if (slidePos < minimumPos) slidePos = minimumPos;

        if (slidePos >= maximumPos)
        {
            slidePos = maximumPos;
        }

        slideTransform.localPosition = new Vector3(slidePos,
            slideTransform.localPosition.y, slideTransform.localPosition.z);

        if (slidePos >= maximumPos)
        {
            // there's a bug where if the index is out of range, a
            // really loud noise plays. it keeps scaring me during testing
            // so i added this
            if (currentCallIndex.value >= phoneScripts.Count) return;

            AudioManager.instance.PlayOneShot(pickupSound, Vector3.zero);

            defaultTimeline.PlayTimeline(callToNav);
            subtitleTimeline.PlayTimeline(
                phoneScripts[currentCallIndex.value].timelineToTrigger);

            currentCallIndex.value++;

            inCall = true;
        }
    }
}
