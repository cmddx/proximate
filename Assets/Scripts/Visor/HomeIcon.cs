using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeIcon : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Transform console;
    [SerializeField] RectTransform icon;
    [SerializeField] int maxIconDistance;
    [SerializeField] int minIconDistance;

    // Update is called once per frame
    void Update()
    {
        Vector3 distanceVector = player.position - console.position;

        float dx = distanceVector.x;
        float dy = distanceVector.y;

        float angle = Mathf.Atan2(dy, dx) * Mathf.Rad2Deg - 90;

        angle += -player.eulerAngles.z;

        float maxCompassDistance = 1.3f;
        float minCompassDistance = 0.03f;

        if (distanceVector.magnitude >= maxCompassDistance)
        {
            icon.localPosition = new Vector3(icon.localPosition.x,
            maxIconDistance, icon.localPosition.z);
        }
        else if (distanceVector.magnitude <= minCompassDistance)
        {
            icon.localPosition = new Vector3(icon.localPosition.x,
            maxIconDistance, icon.localPosition.z);
        }
        else
        {
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
