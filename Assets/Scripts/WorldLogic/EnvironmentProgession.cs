using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentProgession : MonoBehaviour
{
    // progress index 2 (bedrooms unlocked)
    [SerializeField] List<SettableRoom> roomSettings;
    [SerializeField] ConditionList conditions;
    ConditionData progressIndex;

    
    public void SetEnvironment()
    {
        foreach (ConditionData condition in conditions.items)
        {
            if (condition.conditionName == "progressIndex")
            {
                progressIndex = condition;
            }
        }

        if(progressIndex.value == 0) return;

        foreach (SettableRoom room in roomSettings)
        {
            room.SetToDefault();
        }

        for (int i = 0; i < progressIndex.value; i++)
        {
            roomSettings[i].SetToComplete();
        }
    }

    public void UpdateEnvironment()
    {
        if(progressIndex.value == 0) return;
        
        roomSettings[progressIndex.value - 1].SetToComplete();
    }
}