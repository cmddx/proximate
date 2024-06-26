using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThingBreathing : MonoBehaviour
{
    public FMODUnity.StudioEventEmitter thingBreathing;
    public FMODUnity.StudioEventEmitter bangSound;
    bool countRunning;

    public void StartCount()
    {
        countRunning = true;
        StartCoroutine(CountDown());
    }

    public void EndCount()
    {
        countRunning = false;
    }

    IEnumerator CountDown()
    {
        float t = 0;

        while (t < 8)
        {
            t += Time.deltaTime;

            if (countRunning == false)
                yield break;

            yield return null;
        }

        // finished countdown actions
        thingBreathing.Stop();
        bangSound.Play();
        Destroy(gameObject, 8); // destroy this after the bang sound is done
    }

    void OnDisable()
    {
        Destroy(gameObject);
    }
}
