using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Default Preferences")]
public class DefaultPrefs : ScriptableObject
{
    public float sfxVolume;
    public float voiceVolume;
    public float mouseSensitivity;
    public int fullscreen;
}
