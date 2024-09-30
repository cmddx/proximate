using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetFreezer : SettableRoom
{

    public override void SetToDefault()
    {
        SetTerminalsConnected(false);

    }

    public override void SetToComplete()
    {
        SetTerminalsConnected(true);
    }
}