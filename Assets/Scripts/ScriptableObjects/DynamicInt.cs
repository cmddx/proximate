using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Dynamic Int")]
public class DynamicInt : ScriptableObject
{
    private int val;
    public int Value
    {
        get { return val; }
        set
        {
            // this exists for safety. bounds should be controlled
            // in game logic
            if (value < min || value > max)
            {
                Debug.Log("this really should not have happened");
            }

            int oldValue = val;
            val = value;

            if (oldValue > val)
            {
                lowered.Raise();
            }
            else if (oldValue < val)
            {
                raised.Raise();
            }
            else if (oldValue == val)
            {
                // this can be useful in some situations
                // e.g. sometimes the player might try to lower or raise a value
                // that's already at the bounds, and you might want a UI element
                // to flash to indicate that
                pinged.Raise();
            }
        }
    }

    public int min;
    public int max;
    public GameEvent lowered;
    public GameEvent raised;
    public GameEvent pinged;

    // this is a little naughty
    // used for initializing the value because you don't want
    // sounds and effects firing off on game start
    public void SetWithoutEvents(int newVal)
    {
        if (newVal < min || newVal > max)
        {
            Debug.Log("what are you doing");
            return;
        }

        val = newVal;
    }
}
