using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldObject : MonoBehaviour
{
    public string visorName;
    public float minConfidence;
    public float maxConfidence;
    private bool beingSeen;
    public bool BeingSeen
    {
        get { return beingSeen; }
        set { beingSeen = value; }
    }

    public float GetConfidence(float distance){
        // confidence is a function of distance
        // the ideal distance for SONA is 1 meter. Anything
        // closer or further than this will skew confidence
        // towards the minimum.

        float practicalDistance = Mathf.Abs(distance - 1f);

        float lerpPoint = Mathf.InverseLerp(4, 0, practicalDistance);

        float confidence = Mathf.Lerp(minConfidence, maxConfidence, lerpPoint);

        return confidence;
    }
}
