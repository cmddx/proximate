using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;

public class Airlock : MonoBehaviour
{
    public Door bottomDoor;
    public Door topDoor;
    bool deActivated;
    public ConditionList conditions;
    [SerializeField] DocumentList documents;
    public FMODUnity.StudioEventEmitter ventBeepsEmitter;
    public FMODUnity.StudioEventEmitter hissEmitter;
    public FMODUnity.StudioEventEmitter unlockBottomEmitter;
    public FMODUnity.StudioEventEmitter unlockTopEmitter;


    public void CycleAirlock()
    {
        if (deActivated) return;

        ventBeepsEmitter.Play();
        StartCoroutine(PlayHiss());

        if (bottomDoor.Open)
        {
            // Player has entered from the bottom
            StartCoroutine(UnlockTopDoor());

            bottomDoor.CloseDoor();

            ConditionData condition = conditions.
                Get("bottomAirlockUnlocked");
            condition.value = 0;

            deActivated = true;
        }

        if (topDoor.Open)
        {
            // Player has entered from the top

            topDoor.CloseDoor();

            ConditionData condition = conditions.
                Get("topAirlockUnlocked");
            condition.value = 0;

            deActivated = true;

            if (CheckForMalfunction())
            {
                GetComponent<AirlockMalfunction>().StartMalfunction();
                return;
            }

            StartCoroutine(UnlockBottomDoor());
        }
    }

    IEnumerator UnlockTopDoor()
    {
        yield return new WaitForSeconds(5.5f);
        unlockTopEmitter.Play();

        ConditionData condition = conditions.
                Get("topAirlockUnlocked");
        condition.value = 1;
    }
    IEnumerator UnlockBottomDoor()
    {
        yield return new WaitForSeconds(5.5f);
        unlockBottomEmitter.Play();

        ConditionData condition = conditions.
                Get("bottomAirlockUnlocked");
        condition.value = 1;
    }

    public void ForceUnlock()
    {
        unlockTopEmitter.Play();
        ConditionData condition = conditions.
                Get("topAirlockUnlocked");
        condition.value = 1;

        unlockBottomEmitter.Play();
        condition = conditions.
                Get("bottomAirlockUnlocked");
        condition.value = 1;
    }

    IEnumerator PlayHiss()
    {
        yield return new WaitForSeconds(3.5f);
        hissEmitter.Play();
    }

    public void Reactivate()
    {
        deActivated = false;
    }

    bool CheckForMalfunction()
    {
        bool malfunction = false;

        // if both terminals in Recreation have been accessed
        if (documents.items[26].unlocked && documents.items[31].unlocked)
            malfunction = true;

        return malfunction;
    }
}
