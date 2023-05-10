using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Dynamic Float")]
public class DynamicFloat : ScriptableObject
{
    private float val;
    public float Value
    {
        get { return val; }
        set
        {
            // this exists for safety. bounds should be controlled
            // in game logic
            if (val != value)
            {
                val = value;
                if (changed != null)
                {
                    Debug.Log("raising event");
                    changed.Raise();
                }
            }
        }
    }

    public GameEvent changed;

    // // this is a little naughty
    // // used for initializing the value because you don't want
    // // sounds and effects firing off on game start
    // public void SetWithoutEvents(int newVal)
    // {
    //     if (newVal < min || newVal > max)
    //     {
    //         Debug.Log("what are you doing");
    //         return;
    //     }

    //     val = newVal;
    // }
}
