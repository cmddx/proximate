using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Condition List")]
public class ConditionList : ItemList<ConditionData>
{
    public new ConditionData Get(string referenceName)
    {
        foreach (ConditionData conditionData in items)
        {
            if (referenceName.ToLower() == conditionData.conditionName.ToLower())
                return conditionData;
        }

        Debug.Log("Failed to find item: " + referenceName);
        return default;
    }

    public void Reset(){
        foreach (ConditionData conditionData in items)
        {
            conditionData.value = 0;
        }
    }
}

[System.Serializable]
public class ConditionData
{
    public string conditionName;
    public int value;
}