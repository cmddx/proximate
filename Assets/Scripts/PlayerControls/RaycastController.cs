using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastController : MonoBehaviour
{
    public Transform playerAvatar;
    public LineRenderer lineRenderer;
    public DynamicString targetName;
    public DynamicString targetInteraction;
    public DynamicString objectInfo;
    public DynamicFloat targetDistance;
    public DynamicFloat targetConfidence;
    public DynamicInt thingBeingSeen;
    RaycastHit2D hit;
    int layerMask;
    WorldObject currentSeenObject;

    // Start is called before the first frame update
    void Start()
    {
        // Bit shift the index of the layer (8) to get a bit mask
        layerMask = 1 << 8;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;
    }

    // Update is called once per frame
    void Update()
    {
        hit = Physics2D.Raycast(playerAvatar.position, playerAvatar.up, 100, layerMask);
        
        if (hit.collider != null)
        {
            Vector3 playerPoint = new Vector3(playerAvatar.position.x,
                playerAvatar.position.y, -5);
            Vector3 hitPoint = new Vector3(hit.point.x, hit.point.y, -5);

            // This is just to help see where the player
            // is pointing during debug
            lineRenderer.SetPosition(0, playerPoint);
            lineRenderer.SetPosition(1, hitPoint);

            SetCurrentObject();
            string interaction = CheckForInteractions(hit.distance - 0.1f);

            // Update all the data that's used to
            // create the visor interface
            targetName.Value = currentSeenObject.visorName;
            targetInteraction.Value = interaction;
            targetDistance.Value = Mathf.Max(hit.distance - 0.1f, 0f);
            targetConfidence.Value = currentSeenObject.GetConfidence(targetDistance.Value);

            ObjectInfo objInfoComponent = currentSeenObject.
                GetComponent<ObjectInfo>();

            if (objInfoComponent != null)
            {
                objectInfo.Value = objInfoComponent.info;
            } else objectInfo.Value = "";

            if (currentSeenObject.gameObject.name == "Thing" &&
                thingBeingSeen.Value == 0)
            {
                thingBeingSeen.Value = 1;
            }

            if (currentSeenObject.gameObject.name != "Thing" &&
                thingBeingSeen.Value == 1)
            {
                thingBeingSeen.Value = 0;
            }
        }
    }

    void SetCurrentObject()
    {
        if (currentSeenObject == null)
            currentSeenObject = hit.transform.GetComponent<WorldObject>();

        if (currentSeenObject != hit.transform.GetComponent<WorldObject>())
        {
            currentSeenObject.BeingSeen = false;
            currentSeenObject = hit.transform.GetComponent<WorldObject>();
            currentSeenObject.BeingSeen = true;
        }
    }

    string CheckForInteractions(float distanceFrom)
    {
        string potentialInteraction = "";
        bool interactionPossible = false;

        Interactable interactable = currentSeenObject.GetComponent<Interactable>();

        if (interactable == null) return potentialInteraction;

        if (distanceFrom > 0.4)
        {
            potentialInteraction = "error:out of range";
        }
        else if (interactable.Blocker() != "")
        {
            potentialInteraction = interactable.Blocker();
        }
        else
        {
            potentialInteraction = interactable.interactionName;
            interactionPossible = true;
        }

        if (ProxInput.Interact && interactionPossible)
        {
            interactable.Interact();
        }

        return potentialInteraction;
    }
}
