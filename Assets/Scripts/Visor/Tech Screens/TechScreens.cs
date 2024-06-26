using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class TechScreens : MonoBehaviour
{
    public GameObject cursor;
    [SerializeField] FMODUnity.EventReference knockSound;
    [SerializeField] FMODUnity.EventReference errorSound;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        cursor.SetActive(true);
    }

    void OnEnable()
    {
        cursor.SetActive(true);
    }

    void OnDisable()
    {
        cursor.SetActive(false);
    }

    public void PlayKnock()
    {
        AudioManager.instance.PlayOneShot(knockSound);
    }

    public void PlayError()
    {
        AudioManager.instance.PlayOneShot(errorSound);
    }
}
