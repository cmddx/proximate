using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationView : MonoBehaviour
{
    [SerializeField] ScriptableBool canOpenMap;

    void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Locked;
        canOpenMap.value = true;
    }

    void OnDisable()
    {
        canOpenMap.value = false;
    }
}
