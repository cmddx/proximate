using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneCall : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float minimumPos;
    [SerializeField] float maximumPos;

    [SerializeField] RectTransform slideTransform;
    [SerializeField] FMODUnity.EventReference pickupSound;
    [SerializeField] PhoneScript phoneScript;

    float slidePos;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float slideChange = Input.GetAxis("Mouse X");

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
            AudioManager.instance.PlayOneShot(pickupSound, Vector3.zero);
            AudioManager.instance.PlayOneShot(phoneScript.callSound, Vector3.zero);
            TimelineManager.instance.PlayTimeline(phoneScript.timelineToTrigger);

            GetComponent<FMODUnity.StudioEventEmitter>().enabled = false;
            this.enabled = false;
        }
    }
}
