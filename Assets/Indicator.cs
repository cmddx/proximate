using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicator : MonoBehaviour
{
    public RectTransform leftDot;
    public RectTransform rightDot;
    public DynamicFloat targetDistance;

    public void UpdateIndicator()
    {
        float lerpPoint = Mathf.InverseLerp(5, 0, targetDistance.Value);

        // Ease out -- more sensitive to long distances
        // lerpPoint = Mathf.Sin(lerpPoint* Mathf.PI * 0.5f);

        // Ease in -- more sensitive to close distances;
        lerpPoint = lerpPoint * lerpPoint;

        float anchorLeft = Mathf.Lerp(0.1f, 0.46f, lerpPoint);
        float anchorRight = Mathf.Lerp(0.92f, 0.56f, lerpPoint);

        Vector2 anchorLeftVector = new Vector2(anchorLeft, 0.5f);
        leftDot.anchorMin = anchorLeftVector;
        leftDot.anchorMax = anchorLeftVector;

        Vector2 anchorRightVector = new Vector2(anchorRight, 0.5f);
        rightDot.anchorMin = anchorRightVector;
        rightDot.anchorMax = anchorRightVector;
    }
}
