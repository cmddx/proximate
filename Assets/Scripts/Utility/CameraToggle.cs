using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraToggle : MonoBehaviour
{
    public Camera gameCam;
    public bool debugOn;

    // Update is called once per frame
    void Update()
    {
        if (!debugOn) return;

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            gameCam.gameObject.SetActive(!gameCam.gameObject.activeInHierarchy);
        }
    }
}
