using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveController : MonoBehaviour
{
    public static string savePath = Application.dataPath + "/Saves";
    [SerializeField] ConditionList gameConditions;
    [SerializeField] DocumentList gameDocuments;
    [SerializeField] Transform playerTransform;
    [SerializeField] EnvironmentProgession envProg;
    [SerializeField] Instructions instructions;
    [SerializeField] GameObject visorDisplay;

    string saveFileName = "save.txt";
    float timeSinceSave;

    void Awake()
    {
        if (SaveFileExists())
        {
            LoadGame();

            instructions.DisableFromLoad();
            visorDisplay.SetActive(true);
        }

        envProg.SetEnvironment();
    }

    void Update()
    {
        timeSinceSave += Time.deltaTime;
    }

    public void SaveGame()
    {
        SaveObject newSave = new SaveObject
        {
            conditions = gameConditions,
            documents = gameDocuments,
        };

        string saveJson = newSave.DataToString();

        if (!Directory.Exists(savePath))
        {
            Directory.CreateDirectory(savePath);
        }

        File.WriteAllText(savePath + "/" + saveFileName, saveJson);

        timeSinceSave = 0;
    }

    public void LoadGame()
    {
        string fileContents = "";

        DirectoryInfo directoryInfo = new DirectoryInfo(savePath);
        FileInfo[] saveFiles = directoryInfo.GetFiles();
        foreach (FileInfo fileInfo in saveFiles)
        {
            if (fileInfo.Extension.Contains("meta")) continue;
            if (fileInfo.Name.Contains(saveFileName))
            {
                fileContents = File.ReadAllText(fileInfo.FullName);
            }
        }

        SaveObject loadedSave = new()
        {
            conditions = gameConditions,
            documents = gameDocuments
        };

        loadedSave.LoadDataFromString(fileContents);

        playerTransform.localPosition = new Vector3(-0.5f, -3f, 0);
        playerTransform.localEulerAngles = new Vector3(0, 0, -180f);
    }

    public bool SaveFileExists()
    {
        return File.Exists(savePath + "/" + saveFileName);
    }

    public int MinutesSinceLastSave()
    {
        return (int)Mathf.Floor(timeSinceSave / 60f);
    }

    public void DeleteSave()
    {
        File.Delete(savePath + "/" + saveFileName);
    }
}
