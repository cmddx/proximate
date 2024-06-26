using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UI;
using TMPro;
using FMOD.Studio;

public class UpdateManager : MonoBehaviour
{
    [SerializeField] TimelineManager defaultTimeline;
    [SerializeField] TimelineAsset updateToNav;
    [SerializeField] Slider downloadBar;
    [SerializeField] TextMeshProUGUI documentText;
    [SerializeField] FMODUnity.EventReference downloadSound;
    [SerializeField] FMODUnity.EventReference finishedSound;
    [SerializeField] ThingKnocking knocking;
    [SerializeField] ScriptableBool dogMode;

    void Start()
    {
        GetComponent<CanvasGroup>().alpha = 1;
        StartCoroutine(DownloadBar());
        dogMode.value = true;
    }

    IEnumerator DownloadBar()
    {
        List<string> uploadTexts = new List<string>(){
            "patch1837.ptcl",
            "patch1838.ptcl",
            "patch1839.ptcl",
            "dog_test_DO_NOT_SHIP.ptcl",
        };

        int numUpdates = uploadTexts.Count;

        float t = 0.0f;
        float intervalLength = 2.6f;

        float intervalTicker = intervalLength;
        int intervalCount = 0;

        while (t <= numUpdates * intervalLength)
        {
            t += Time.deltaTime;
            intervalTicker += Time.deltaTime;

            downloadBar.value = Mathf.Lerp(0, 1, t / (numUpdates * intervalLength));

            if (intervalTicker >= intervalLength)
            {
                documentText.text = uploadTexts[intervalCount];

                AudioManager.instance.PlayOneShot(downloadSound);

                intervalTicker = 0f;

                // if(intervalCount == 2) knocking.StartKnocking();
                intervalCount++;
            }

            yield return null;
        }

        defaultTimeline.PlayTimeline(updateToNav);

        AudioManager.instance.PlayOneShot(finishedSound);
    }
}
