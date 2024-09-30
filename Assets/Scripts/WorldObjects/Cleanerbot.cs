using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Cleanerbot : MonoBehaviour
{
    public Vector3 targetDestination;
    [SerializeField] FMODUnity.StudioEventEmitter emitter;
    [SerializeField] Door lobbyNorthDoor;

    void Start()
    {
        // Activate();
    }

    public void Activate()
    {
        emitter.Play();
        lobbyNorthDoor.progressIndexRequirement = 3;
        StartCoroutine(MoveLeft());
    }

    IEnumerator MoveLeft()
    {
        GetComponent<BoxCollider2D>().enabled = false;

        while (Vector3.Distance(transform.localPosition, targetDestination) > 0.01f)
        {
            float step = 2 * Time.deltaTime;
            transform.localPosition = Vector3.MoveTowards(transform.localPosition,
                targetDestination, step);

            yield return null;
        }

        GetComponent<BoxCollider2D>().enabled = true;

        yield break;
    }
}
