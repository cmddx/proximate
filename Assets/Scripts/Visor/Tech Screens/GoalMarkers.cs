using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalMarkers : MonoBehaviour
{
    [SerializeField] List<GameObject> markerGroups;
    
    public void UnlockNextMarkers(int progressIndex)
    {
        markerGroups[progressIndex].SetActive(true);

        if (progressIndex > 0)
        {
            RemoveCurrentMarker(progressIndex - 1);
        }
    }

    public void RemoveCurrentMarker(int progressIndex)
    {
        markerGroups[progressIndex].SetActive(false);
    }
}
