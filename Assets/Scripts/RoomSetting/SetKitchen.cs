using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetKitchen : SettableRoom
{
    [SerializeField] GameObject thingBreathing;

    public override void SetToDefault()
    {
        SetTerminalsConnected(false);

        thingBreathing.SetActive(true);
    }

    public override void SetToComplete()
    {
        SetTerminalsConnected(true);

        thingBreathing.SetActive(false);
    }
}
