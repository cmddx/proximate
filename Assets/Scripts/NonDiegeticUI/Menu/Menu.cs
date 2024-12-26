using System.Collections;
using System.Collections.Generic;
using FMODUnity;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject visorDisplay;
    [SerializeField] GameObject menuContents;
    [SerializeField] GameObject menuSettings;
    [SerializeField] GameObject menuInstructions;
    [SerializeField] GameObject menuQuit;
    [SerializeField] GameObject cursor;
    [SerializeField] GameObject cursorIngame;
    [SerializeField] Material glitchMat;
    [SerializeField] GameObject instructions;
    [SerializeField] SaveController saveController;
    [SerializeField] TextMeshProUGUI lastSavedText;
    bool menuOpen;
    bool cursorWasLocked;
    bool playerHadControl;
    bool techCursorWasEnabled;

    float lastEscPress;
    float glitchMatValue;

    // Start is called before the first frame update
    void Start()
    {
        menuOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (instructions.activeInHierarchy) return;

        if (ProxInput.Pause &&
            (Time.unscaledTime - lastEscPress > 0.1f))
        {
            lastEscPress = Time.unscaledTime;

            if (menuOpen) CloseMenu();
            else OpenMenu();
        }
    }

    void OpenMenu()
    {
        menuOpen = true;

        Time.timeScale = 0;

        if (Cursor.lockState == CursorLockMode.Locked)
        {
            cursorWasLocked = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else cursorWasLocked = false;

        Cursor.visible = false;

        if(cursorIngame.activeInHierarchy){
            techCursorWasEnabled = true;
            cursorIngame.SetActive(false);
        } else techCursorWasEnabled = false;

        cursor.SetActive(true);

        AudioManager.instance.PauseAudio();

        if (player.GetComponent<PlayerMovement>().enabled)
        {
            playerHadControl = true;
            player.GetComponent<PlayerMovement>().enabled = false;
            player.GetComponent<PlayerRotation>().enabled = false;
            player.GetComponent<RaycastController>().enabled = false;
        }
        else playerHadControl = false;

        glitchMatValue = glitchMat.GetFloat("_Strength");
        glitchMat.SetFloat("_Strength", 0);

        visorDisplay.SetActive(false);
        GetComponent<UnityEngine.UI.Image>().enabled = true;

        lastSavedText.text = "last saved " + saveController.MinutesSinceLastSave()
            + " minutes ago";

        menuContents.SetActive(true);
    }

    public void CloseMenu()
    {
        menuOpen = false;

        menuContents.SetActive(false);
        menuSettings.SetActive(false);
        menuInstructions.SetActive(false);
        menuQuit.SetActive(false);

        GetComponent<UnityEngine.UI.Image>().enabled = false;
        visorDisplay.SetActive(true);

        cursor.SetActive(false);

        if(techCursorWasEnabled){
            cursorIngame.SetActive(true);
        }

        if (cursorWasLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        if (playerHadControl)
        {
            player.GetComponent<PlayerMovement>().enabled = true;
            player.GetComponent<PlayerRotation>().enabled = true;
            player.GetComponent<RaycastController>().enabled = true;
        }

        AudioManager.instance.UnpauseAudio();

        Time.timeScale = 1;
    }

    public void CloseMenuToResetGame()
    {
        AudioManager.instance.UnpauseAudio();

        Time.timeScale = 1;
    }
}
