using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using FMOD.Studio;
using UnityEngine;
using UnityEngine.Timeline;

public class ThingTriggeringEnding : MonoBehaviour
{
    [SerializeField] float toleranceTime;
    [SerializeField] Material glitchMat;
    [SerializeField] FMODUnity.EventReference glitchSound;
    [SerializeField] TimelineManager defaultTimeline;
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
    }

    void OnDisable()
    {
        glitchMat.SetFloat("_Strength", 0);

        glitchSoundInstance.stop(STOP_MODE.IMMEDIATE);
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

        if (seenTime > 1)
        {
            glitchSoundInstance.stop(STOP_MODE.IMMEDIATE);

            Bus bus = FMODUnity.RuntimeManager.GetBus("bus:/Pod");
            bus.setMute(true);
            SceneManager.LoadScene("Credits", LoadSceneMode.Single);
        }
    }
}