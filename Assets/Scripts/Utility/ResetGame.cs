using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGame : MonoBehaviour
{
    [SerializeField] SaveController saveController;
    [SerializeField] ConditionList gameConditions;
    [SerializeField] DocumentList gameDocuments;

    public void Reset()
    {
        saveController.DeleteSave();

        SceneManager.LoadScene("MainScene");

        gameConditions.Reset();
        gameDocuments.Reset();
    }
}
