using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using UnityEngine.Timeline;
using Unity.VisualScripting;

[RequireComponent(typeof(WorldObject))]
public class Vent : Interactable
{
    [SerializeField] FMODUnity.EventReference entrySound;
    [SerializeField] Transform player;
    [SerializeField] Vector3 newPlayerPosition;
    [SerializeField] float yieldTime1;
    [SerializeField] float yieldTime2;
    [SerializeField] CompassManager compassManager;
    [SerializeField] bool disableCompass;

    private bool opening;

    public override void Interact()
    {
        StartCoroutine(OpenVent());
    }

    public IEnumerator OpenVent()
    {
        opening = true;

        AudioManager.instance.PlayOneShot(entrySound);

        player.gameObject.GetComponent<PlayerMovement>().enabled = false;
        player.gameObject.GetComponent<PlayerRotation>().enabled = false;

        yield return new WaitForSeconds(yieldTime1);

        if(disableCompass){
            compassManager.DisableCompass();
        } else compassManager.EnableCompass();

        player.localPosition = newPlayerPosition;

        yield return new WaitForSeconds(yieldTime2);

        player.gameObject.GetComponent<PlayerMovement>().enabled = true;
        player.gameObject.GetComponent<PlayerRotation>().enabled = true;

        opening = false;
    }

    public override string Blocker()
    {
        if (opening)
        {
            return "error:" + "opening";
        }

        return "";
    }
}
