using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGame : MonoBehaviour
{
    [SerializeField] SaveController saveController;

    public void Reset()
    {
        saveController.DeleteSave();

        SceneManager.LoadScene("MainScene");
    }
}
