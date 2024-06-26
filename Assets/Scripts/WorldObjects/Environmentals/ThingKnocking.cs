using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThingKnocking : MonoBehaviour
{
    public FMODUnity.StudioEventEmitter knockingEmitter;

    public void StartKnocking()
    {
        knockingEmitter.Play();
    }

    public void StopKnocking()
    {
        knockingEmitter.Stop();
    }
}
