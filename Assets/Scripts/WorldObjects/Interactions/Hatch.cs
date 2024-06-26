using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Door))]
public class Hatch : MonoBehaviour
{
    public ThingKnocking thingKnocking;

    public void StopEmitter()
    {
        thingKnocking.StopKnocking();
    }
}
