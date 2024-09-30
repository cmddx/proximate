using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBathroomCoworking : SettableRoom
{
    [SerializeField] Door leftDoor;
    [SerializeField] Door rightDoor;
    [SerializeField] GameObject roomEnter;
    [SerializeField] GameObject cleanerbot;
    [SerializeField] Door lobbyNorthDoor;

    public override void SetToDefault()
    {
        SetTerminalsConnected(false);

        roomEnter.SetActive(true);
    }

    public override void SetToComplete()
    {
        SetTerminalsConnected(true);

        leftDoor.blockerName = "emergency lock - flooding detected";
        leftDoor.progressIndexRequirement = 100;
        rightDoor.blockerName = "emergency lock - flooding detected";

        roomEnter.SetActive(false);
        cleanerbot.transform.localPosition = cleanerbot.GetComponent
            <Cleanerbot>().targetDestination;
        lobbyNorthDoor.progressIndexRequirement = 3;
    }
}
