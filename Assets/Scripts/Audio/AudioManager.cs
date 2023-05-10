using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance { get; private set; }
    List<EventInstance> eventInstances;
    EventInstance ambienceEventInstance;
    [SerializeField] FMODUnity.EventReference ambienceSound; // this needs to be expanded into a whole thing

    private void Awake()
    {
        if (instance != null)
            Debug.LogError("Found more than one Audio Manager in the scene.");

        instance = this;

        eventInstances = new List<EventInstance>();
    }

    void Start()
    {
        InitializeAmbience(ambienceSound);
    }

    public void PlayOneShot(EventReference sound, Vector3 worldPos)
    {
        RuntimeManager.PlayOneShot(sound, worldPos);
    }

    public EventInstance CreateInstance(EventReference eventRef)
    {
        EventInstance eventInstance = RuntimeManager.CreateInstance(eventRef);
        eventInstances.Add(eventInstance);

        return eventInstance;
    }

    void InitializeAmbience(EventReference ambienceRef)
    {
        ambienceEventInstance = CreateInstance(ambienceRef);
        ambienceEventInstance.start();
    }

    void CleanUp()
    {
        foreach (EventInstance eventInstance in eventInstances)
        {
            eventInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            eventInstance.release();
        }
    }
}
