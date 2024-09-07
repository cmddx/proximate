using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetLobby1 : SettableRoom
{
    public override void SetToDefault()
    {
        terminal.alreadyConnected = false;
    }

    public override void SetToComplete()
    {
        terminal.alreadyConnected = true;
    }
}
