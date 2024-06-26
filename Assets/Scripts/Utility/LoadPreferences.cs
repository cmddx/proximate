using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class LoadPreferences : MonoBehaviour
{
    public static LoadPreferences Instance { get; private set; }
    public DefaultPrefs defaultPrefs;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // PlayerPrefs.DeleteAll();
        ActionAllPreferences();
    }

    public void ActionAllPreferences()
    {
        ActionSoundPrefs();
        ActionScreenPrefs();
    }

    public void ActionSoundPrefs()
    {
        float vol = PlayerPrefs.GetFloat("sfxVolume", defaultPrefs.sfxVolume);
        // float logVol = Mathf.Pow(10.0f, vol / 20f);
        FMOD.Studio.Bus bus = FMODUnity.RuntimeManager.GetBus("bus:/SFX");
        bus.setVolume(vol);

        vol = PlayerPrefs.GetFloat("voiceVolume", defaultPrefs.voiceVolume);
        // logVol = Mathf.Pow(10.0f, vol / 20f);
        bus = FMODUnity.RuntimeManager.GetBus("bus:/Voice");
        bus.setVolume(vol);
    }

    public void ActionScreenPrefs()
    {
        int fullscreen = PlayerPrefs.GetInt("fullscreen", defaultPrefs.fullscreen);

        if (fullscreen == 1) Screen.fullScreenMode =
            FullScreenMode.ExclusiveFullScreen;
        else Screen.fullScreenMode = FullScreenMode.Windowed;
    }
}
