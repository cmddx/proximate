using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSlider : MonoBehaviour
{
    public Slider slider;
    public DefaultPrefs defaultPrefs;
    public string prefName;

    void Start()
    {
        float defaultVolume = 1;

        if (prefName == "sfxVolume")
        {
            defaultVolume = defaultPrefs.sfxVolume;
        }
        else if (prefName == "voiceVolume")
        {
            defaultVolume = defaultPrefs.voiceVolume;
        }

        slider.value = PlayerPrefs.GetFloat(prefName, defaultVolume);
    }

    public void OnChangeSlider(float Value)
    {
        PlayerPrefs.SetFloat(prefName, Value);
        PlayerPrefs.Save();

        LoadPreferences.Instance.ActionSoundPrefs();
    }
}
