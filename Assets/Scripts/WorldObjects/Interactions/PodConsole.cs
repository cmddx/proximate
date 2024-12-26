using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.Timeline;

[RequireComponent(typeof(WorldObject))]
public class PodConsole : Interactable
{
    [SerializeField] TimelineManager subtitlesTimeline;
    [SerializeField] TimelineAsset depthReadings;
    [SerializeField] Door door;
    [SerializeField] FMODUnity.StudioEventEmitter podLaunchSound;
    [SerializeField] FMODUnity.StudioEventEmitter rotorSound;
    [SerializeField] FMODUnity.StudioEventEmitter rotorBubbles;
    [SerializeField] CanvasGroup playerMapMarkerCG;
    [SerializeField] CompassManager compassManager;
    [SerializeField] string endingType;

    // Exclusive to Hole Ending
    [SerializeField] FMODUnity.EventReference endOfTheWorld;

    // Exclusive to Surface ending
    [SerializeField] GameObject thing;

    bool alreadyConnected;
    string blockerName;

    public override void Interact()
    {
        alreadyConnected = true;

        StartCoroutine(EndingSequence());
    }

    public override string Blocker()
    {
        if (alreadyConnected) return "error:" + blockerName;
        return "";
    }

    IEnumerator EndingSequence()
    {
        door.progressIndexRequirement = 99;
        Destroy(door.GetComponent<ObjectInfo>());

        blockerName = "launching";

        yield return new WaitForSeconds(0.2f);

        podLaunchSound.Play();

        yield return new WaitForSeconds(6.8f);

        blockerName = "launched";
        rotorSound.Play();

        yield return new WaitForSeconds(1f);

        AudioManager.instance.CleanUp();
        rotorBubbles.Play();
        playerMapMarkerCG.alpha = 0;

        yield return new WaitForSeconds(6);

        compassManager.DisableCompass();

        yield return new WaitForSeconds(16);

        subtitlesTimeline.PlayTimeline(depthReadings);

        if (endingType == "hole")
        {
            yield return new WaitForSeconds(41);
            AudioManager.instance.PlayOneShot(endOfTheWorld);

            yield return new WaitForSeconds(51);
            GetComponent<SceneTransition>().ChangeScene();
        }

        if (endingType == "surface")
        {
            yield return new WaitForSeconds(75f);

            FMOD.Studio.Bus bus = FMODUnity.RuntimeManager.GetBus("bus:/Pod");

            float elapsedTime = 0;

            while (elapsedTime < 1f)
            {
                float newVol = Mathf.Lerp(1f, 0f, elapsedTime / 1);

                bus.setVolume(newVol);

                elapsedTime += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
            
            yield return new WaitForSeconds(4f);

            thing.SetActive(true);
        }

        yield return null;
    }
}
