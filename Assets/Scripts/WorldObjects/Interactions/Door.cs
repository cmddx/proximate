using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;

[RequireComponent(typeof(WorldObject))]
public class Door : Interactable
{
    public int progressIndexRequirement;
    public string optionalConditionRequirement;
    public ConditionList conditionList;
    public string blockerName;
    public SpriteRenderer spriteRenderer;
    public FMODUnity.StudioEventEmitter openEmitter;
    public FMODUnity.StudioEventEmitter closeEmitter;

    private bool doorOpen;
    private bool opening;
    public bool Open
    {
        get { return doorOpen; }
    }

    void Start()
    {
    }

    public override void Interact()
    {
        StartCoroutine(OpenDoor());
    }

    public IEnumerator OpenDoor()
    {
        if (doorOpen) yield break;

        opening = true;

        openEmitter.Play();

        if (GetComponent<DoorControlsEmitter>() != null)
        {
            foreach (var dce in GetComponents<DoorControlsEmitter>())
            {
                dce.PlayIfRoomEnter();
            }
        }

        yield return new WaitForSeconds(1.5f);
        opening = false;

        GetComponent<BoxCollider2D>().enabled = false;
        spriteRenderer.enabled = false;
        doorOpen = true;

        // used in one specific instance in the Freezer room
        if (GetComponent<Hatch>() != null)
        {
            GetComponent<Hatch>().StopEmitter();
        }
    }

    public void CloseDoor()
    {
        if (!doorOpen) return;

        closeEmitter.Play();

        GetComponent<BoxCollider2D>().enabled = true;
        spriteRenderer.enabled = true;
        doorOpen = false;

        if (GetComponent<DoorControlsEmitter>() != null)
        {
            foreach (var dce in GetComponents<DoorControlsEmitter>())
            {
                dce.StopIfRoomExit();
            }
        }
    }

    public override string Blocker()
    {
        if (opening)
        {
            return "error:" + "opening";
        }

        ConditionData condition = conditionList.
            Get("progressIndex");

        ConditionData optionalCondition = conditionList.
            Get(optionalConditionRequirement);

        if (condition.value < progressIndexRequirement ||
            (optionalCondition != null && optionalCondition.value == 0))
        {
            return "error:" + blockerName;
        }

        return "";
    }
}
