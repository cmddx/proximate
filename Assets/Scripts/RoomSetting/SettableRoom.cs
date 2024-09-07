using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SettableRoom : MonoBehaviour
{
    public Terminal terminal;
    
    public abstract void SetToDefault();
    public abstract void SetToComplete();
}
