using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertSound : MonoBehaviour
{
    [SerializeField] FMODUnity.EventReference alertSound;
    float time;
    float magnitude;

    void OnEnable()
    {
        magnitude = 0;
    }

    void Update()
    {
        if (magnitude == 0) return;

        time += Time.deltaTime;

        if (time > 0.2f * magnitude)
        {
            time = 0;
            AudioManager.instance.PlayOneShot(alertSound);
        }
    }

    public void ChangeMagnitude(float newMagnitude)
    {
        magnitude = newMagnitude;
    }
}
