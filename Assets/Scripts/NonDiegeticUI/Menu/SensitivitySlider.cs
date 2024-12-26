using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SensitivitySlider : MonoBehaviour
{
    public Slider slider;
    public DefaultPrefs defaultPrefs;
    void Start()
    {
        float defaultSensitivity = defaultPrefs.mouseSensitivity;

        slider.value = PlayerPrefs.GetFloat("controlSensitivity", defaultSensitivity);
    }

    public void OnChangeSlider(float Value)
    {
        PlayerPrefs.SetFloat("controlSensitivity", Value);
        PlayerPrefs.Save();
    }
}
