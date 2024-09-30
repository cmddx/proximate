using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class SaveObject
{
    public ConditionList conditions;
    public DocumentList documents;

    public string DataToString()
    {
        SaveStructure saveData = new SaveStructure
        {
            conditionData = conditions.items,
            documentData = documents.items,
        };

        string saveJson = JsonUtility.ToJson(saveData);

        return saveJson;
    }

    public void LoadDataFromString(string saveString)
    {
        SaveStructure saveData = JsonUtility.FromJson<SaveStructure>
            (saveString);

        for (int i = 0; i < conditions.items.Count; i++)
        {
            conditions.items[i].value = saveData.conditionData[i].value;
        }

        for (int i = 0; i < documents.items.Count; i++)
        {
            documents.items[i].unlocked = saveData.documentData[i].unlocked;
            documents.items[i].uploaded = saveData.documentData[i].uploaded;
            documents.items[i].read = saveData.documentData[i].read;

        }
    }
}

[System.Serializable]
public class SaveStructure
{
    public List<ConditionData> conditionData;
    public List<DocumentData> documentData;
}