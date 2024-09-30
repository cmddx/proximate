using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetLobby2 : SettableRoom
{
    [SerializeField] TerminalWithBlocker riotsLaptop;
    public override void SetToDefault()
    {
        riotsLaptop.alreadyConnected = false;
    }

    public override void SetToComplete()
    {
        riotsLaptop.alreadyConnected = true;
    }
}
