using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetLobby1 : SettableRoom
{
    [SerializeField] GameObject thingBreathing;

    public override void SetToDefault()
    {
        SetTerminalsConnected(false);
    }

    public override void SetToComplete()
    {
        SetTerminalsConnected(true);

        thingBreathing.SetActive(true);
    }
}
