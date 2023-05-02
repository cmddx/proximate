using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Dynamic String")]
public class DynamicString : ScriptableObject
{
    private string val;
    public string Value
    {
        get { return val; }
        set
        {
            if (val != value)
            {
                val = value;
                changed.Raise();
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
