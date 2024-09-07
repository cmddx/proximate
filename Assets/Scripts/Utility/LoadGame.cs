using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadGame : MonoBehaviour
{
    [SerializeField] ConditionList conditions;
    [SerializeField] List<SettableRoom> roomSettings;
    int progressIndex;
    int mapDownloaded;


    void Awake()
    {
        // TO-DO: Read from a save file to set the Progress Index

    }

    void SetGame()
    {
        SetConditions();
    }

    void SetConditions()
    {
        conditions.Get("mapDownloaded").value = mapDownloaded;
        conditions.Get("topAirlockUnlocked").value = 0;

        // Hasn't properly left Submarine
        if (progressIndex >= 0)
        {
            conditions.Get("callIndex").value = 1;
            conditions.Get("bottomAirlockUnlocked").value = 0;
        }

        // Just uploaded Reception
        if (progressIndex >= 1)
        {
            conditions.Get("callIndex").value = 2;
            conditions.Get("bottomAirlockUnlocked").value = 1;
        }
    }
}
