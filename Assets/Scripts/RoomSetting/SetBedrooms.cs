using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBedrooms : SettableRoom
{
    [SerializeField] GameObject falseThreatNorth;

    public override void SetToDefault()
    {
        SetTerminalsConnected(false);

        falseThreatNorth.SetActive(true);
    }

    public override void SetToComplete()
    {
        SetTerminalsConnected(true);

        falseThreatNorth.SetActive(false);
    }
}
