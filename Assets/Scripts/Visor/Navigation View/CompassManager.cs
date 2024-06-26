using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompassManager : MonoBehaviour
{
    [SerializeField] Compass compass;
    [SerializeField] HomeIcon homeIcon;
    [SerializeField] AlertIcon alertIcon;
    [SerializeField] GoalIcon goalIcon;
    [SerializeField] GameObject disablingImage;

    public void DisableCompass()
    {
        compass.enabled = false;
        homeIcon.enabled = false;
        goalIcon.enabled = false;

        alertIcon.enabled = false;
        alertIcon.DisableAlertSound();

        disablingImage.SetActive(true);
    }

    public void EnableCompass()
    {
        compass.enabled = true;
        homeIcon.enabled = true;
        goalIcon.enabled = true;

        alertIcon.enabled = true;
        alertIcon.EnableAlertSound();

        disablingImage.SetActive(false);
    }
}
