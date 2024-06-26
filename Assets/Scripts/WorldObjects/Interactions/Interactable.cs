using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public string interactionName;
    // somewhere here 'll have a list
    // of stat requirements that must be met
    // or else there'll be a different
    // interaction name, like "locked"

    public abstract void Interact();
    public virtual string Blocker()
    {
        return "";
    }
}
