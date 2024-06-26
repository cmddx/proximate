using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ToggleFullscreen : MonoBehaviour
{
    public Toggle toggleButton;
    public DefaultPrefs defaultPrefs;

    void Start()
    {
        int fullscreenEnabled = PlayerPrefs.GetInt("fullscreen", defaultPrefs.fullscreen);

        if (fullscreenEnabled == 1) toggleButton.isOn = true;
        else toggleButton.isOn = false;
    }

    public void OnToggle(bool Value)
    {
        if (Value == true) PlayerPrefs.SetInt("fullscreen", 1);
        else PlayerPrefs.SetInt("fullscreen", 0);
        PlayerPrefs.Save();

        LoadPreferences.Instance.ActionScreenPrefs();
    }
}
