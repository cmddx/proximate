using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// public class EnvironmentProgession : MonoBehaviour
// {
//     // progress index 2 (bedrooms unlocked)
//     [SerializeField] List<SettableRoom> roomSettings;
//     [SerializeField] ConditionList conditions;
//     ConditionData progressIndex;

//     void Start()
//     {
//         foreach (ConditionData condition in conditions.items)
//         {
//             if (condition.conditionName == "progressIndex")
//             {
//                 progressIndex = condition;
//             }
//         }

//         UpdateEnvironment();
//     }

//     public void UpdateEnvironment()
//     {
//         if(progressIndex.value == 0) return;
        
//         roomSettings[progressIndex.value - 1].SetToComplete();
//     }
// }

public class EnvironmentProgession : MonoBehaviour
{
    // progress index 2 (bedrooms unlocked)
    [SerializeField] List<GameObject> kitchenSituationals;
    [SerializeField] ConditionList conditions;
    ConditionData progressIndex;

    void Start()
    {
        foreach (ConditionData condition in conditions.items)
        {
            if (condition.conditionName == "progressIndex")
            {
                progressIndex = condition;
            }
        }

        UpdateEnvironment();
    }

    public void UpdateEnvironment()
    {
        if (progressIndex.value == 1)
        {
            SetKitchenStageSituationals(true);
        }

        else if (progressIndex.value == 2)
        {
            SetKitchenStageSituationals(false);
        }
    }

    void SetKitchenStageSituationals(bool valueToSet)
    {
        foreach (GameObject situational in kitchenSituationals)
        {
            situational.SetActive(valueToSet);
        }
    }
}