using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SettableRoom : MonoBehaviour
{
    public List<Terminal> terminals;

    public abstract void SetToDefault();
    public abstract void SetToComplete();

    protected void SetTerminalsConnected(bool isConnected)
    {
        foreach (Terminal terminal in terminals)
        {
            terminal.alreadyConnected = isConnected;
        }
    }
}
