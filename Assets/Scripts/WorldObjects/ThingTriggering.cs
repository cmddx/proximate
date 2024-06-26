using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using UnityEngine;
using UnityEngine.Timeline;

public class ThingTriggering : MonoBehaviour
{
    [SerializeField] float toleranceTime;
    [SerializeField] Material glitchMat;
    [SerializeField] FMODUnity.EventReference glitchSound;
    [SerializeField] TimelineManager defaultTimeline;
    [SerializeField] TimelineAsset thingTriggered;
    float seenTime;
    float glitchTime;
    EventInstance glitchSoundInstance;

    // Start is called before the first frame update
    void OnEnable()
    {
        seenTime = 0;
        glitchTime = 0;

        glitchSoundInstance = AudioManager.instance.CreateInstance(glitchSound);
        glitchSoundInstance.start();

        GetComponent<ThingSounds>().StartScreaming();
        GetComponent<ThingMovement>().enabled = false;
    }

    void OnDisable()
    {
        glitchMat.SetFloat("_Strength", 0);

        glitchSoundInstance.stop(STOP_MODE.IMMEDIATE);

        if (GetComponent<ThingSounds>().enabled)
            GetComponent<ThingSounds>().StartBreathing();

        GetComponent<ThingMovement>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        seenTime += Time.deltaTime;
        glitchTime += Time.deltaTime;

        if (glitchTime <= 0.1)
        {
            float newStrength = Random.Range(0, 101);
            newStrength = newStrength / 100;

            newStrength = newStrength * (seenTime * 2) / 20;

            glitchMat.SetFloat("_Strength", newStrength);

            glitchTime = 0;
        }

        if (seenTime >= toleranceTime)
        {
            GetComponent<ThingSounds>().Quieten();
            GetComponent<ThingSounds>().enabled = false;

            this.gameObject.SetActive(false);

            defaultTimeline.PlayTimeline(thingTriggered);
        }
    }

}
