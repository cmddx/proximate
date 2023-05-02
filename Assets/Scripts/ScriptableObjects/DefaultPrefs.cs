using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Default Preferences")]
public class DefaultPrefs : ScriptableObject
{
    public float musicVolume;
    public float sfxVolume;
    public int fullscreen;
    public int moraleBar;
}
