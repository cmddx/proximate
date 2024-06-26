using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.UI;
using UnityEngine;

public class AlertIcon : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Transform thing;
    [SerializeField] Transform falseThreatBedroomNorth;
    [SerializeField] Transform falseThreatBedroomSouth;
    [SerializeField] RectTransform icon;
    [SerializeField] Sprite exclamation;
    [SerializeField] Sprite question;
    [SerializeField] int maxIconDistance;
    [SerializeField] int minIconDistance;
    [SerializeField] AlertSound alertSound;

    float time;
    bool threatIsFalse;

    public void DisableAlertSound()
    {
        alertSound.enabled = false;
    }

    public void EnableAlertSound()
    {
        alertSound.enabled = true;
    }

    void Start()
    {
        icon.GetComponent<Image>().sprite = exclamation;
    }

    // Update is called once per frame
    void Update()
    {
        Transform threat;

        if (thing.gameObject.activeInHierarchy)
        {
            threat = thing;
            threatIsFalse = false;

            if (icon.GetComponent<Image>().sprite == question)
                icon.GetComponent<Image>().sprite = exclamation;
        }
        else if (falseThreatBedroomSouth.gameObject.activeInHierarchy)
        {
            threat = falseThreatBedroomSouth;
            threatIsFalse = true;
        }
        else if (falseThreatBedroomNorth.gameObject.activeInHierarchy)
        {
            threat = falseThreatBedroomNorth;
            threatIsFalse = true;
        }
        else
        {
            icon.gameObject.SetActive(false);
            alertSound.enabled = false;
            return;
        }


        time += Time.deltaTime;

        Vector3 distanceVector = player.position - threat.position;

        if (time > 0.2f * distanceVector.magnitude &&
            icon.gameObject.activeInHierarchy)
        {
            time = 0;
            alertSound.ChangeMagnitude(distanceVector.magnitude);

            if (GetComponent<CanvasGroup>().alpha == 1)
            {
                GetComponent<CanvasGroup>().alpha = 0;
            }
            else
            {
                GetComponent<CanvasGroup>().alpha = 1;

                if (threatIsFalse)
                {
                    if (icon.GetComponent<Image>().sprite == exclamation)
                        icon.GetComponent<Image>().sprite = question;
                    else icon.GetComponent<Image>().sprite = exclamation;
                }
            }
        }

        float dx = distanceVector.x;
        float dy = distanceVector.y;

        float angle = Mathf.Atan2(dy, dx) * Mathf.Rad2Deg - 90;

        angle += -player.eulerAngles.z;

        float maxCompassDistance = 6f;
        if (threatIsFalse) maxCompassDistance = 2f;
        float minCompassDistance = 0.02f;

        if (distanceVector.magnitude >= maxCompassDistance)
        {
            icon.gameObject.SetActive(false);
            alertSound.enabled = false;
        }
        else if (distanceVector.magnitude <= minCompassDistance)
        {
            icon.localPosition = new Vector3(icon.localPosition.x,
            maxIconDistance, icon.localPosition.z);
        }
        else
        {
            if (!icon.gameObject.activeInHierarchy)
            {
                icon.gameObject.SetActive(true);
                alertSound.enabled = true;
            }

            float distanceRatio = Mathf.InverseLerp(maxCompassDistance,
                minCompassDistance, distanceVector.magnitude);
            float iconPositionY = Mathf.Lerp(maxIconDistance, minIconDistance,
                distanceRatio);

            icon.localPosition = new Vector3(icon.localPosition.x,
            iconPositionY, icon.localPosition.z);
        }

        transform.eulerAngles = new Vector3(0, 0, angle);
        icon.localEulerAngles = new Vector3(0, 0, -angle);
    }
}
