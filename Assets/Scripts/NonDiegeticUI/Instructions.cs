using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class Instructions : MonoBehaviour
{
    [SerializeField] TimelineManager timeliner;
    [SerializeField] TimelineAsset startGame;
    [SerializeField] PlayerMovement playerMov;
    [SerializeField] PlayerRotation playerRot;
    [SerializeField] RaycastController rayCont;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Input.anyKey && !timeliner.playing)
        {
            timeliner.PlayTimeline(startGame);
        }
    }

    void Start()
    {
        playerMov.enabled = false;
        playerRot.enabled = false;
        rayCont.enabled = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
