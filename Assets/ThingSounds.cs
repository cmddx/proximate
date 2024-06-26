using System.Collections;
using System.Collections.Generic;
using FMODUnity;
using UnityEngine;

public class ThingSounds : MonoBehaviour
{
    [SerializeField] FMODUnity.StudioEventEmitter breathingEmitter;
    [SerializeField] FMODUnity.StudioEventEmitter screamingEmitter;
    // Start is called before the first frame update
    void Start()
    {
        StartBreathing();
    }

    public void StartBreathing()
    {
        screamingEmitter.Stop();
        breathingEmitter.Play();
    }

    public void StartScreaming()
    {
        breathingEmitter.Stop();
        screamingEmitter.Play();
    }

    public void Quieten()
    {
        breathingEmitter.Stop();
        screamingEmitter.Stop();
    }

    void OnDisable()
    {
        Quieten();
    }
}
