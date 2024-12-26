using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DoorControlsEmitter : MonoBehaviour
{
    [SerializeField] Transform emitterTransform;
    [SerializeField] Transform playerTransform;
    [SerializeField] FMODUnity.StudioEventEmitter emitter;
    [SerializeField] Terminal control;

    public void PlayIfRoomEnter()
    {
        if (control != null && control.alreadyConnected) return;
        if(!emitterTransform.gameObject.activeInHierarchy) return;

        float distanceDoorToEmitter = Vector3.Distance(
            emitterTransform.position, transform.position);
        float distancePlayerToEmitter = Vector3.Distance(
            emitterTransform.position, playerTransform.position);

        if (distancePlayerToEmitter > distanceDoorToEmitter)
        {
            emitter.Play();
        }
    }

    public void StopIfRoomExit()
    {
        if (control != null && control.alreadyConnected) return;
        if(!emitterTransform.gameObject.activeInHierarchy) return;

        float distanceDoorToEmitter = Vector3.Distance(
            emitterTransform.position, transform.position);
        float distancePlayerToEmitter = Vector3.Distance(
            emitterTransform.position, playerTransform.position);

        if (distancePlayerToEmitter > distanceDoorToEmitter)
        {
            emitter.Stop();
        }
    }
}
