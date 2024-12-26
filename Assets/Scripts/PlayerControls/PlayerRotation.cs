using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    public float speed;
    public DynamicFloat playerRotation;
    float aimChange;

    float defaultSensitivity = 1;

    // Update is called once per frame
    void Update()
    {
        float sensitivity = PlayerPrefs.GetFloat("controlSensitivity", 
            defaultSensitivity);

        aimChange = ProxInput.Look.x * sensitivity;

        if (aimChange > 2) aimChange = 2f;
        if (aimChange < -2) aimChange = -2f;

        transform.localEulerAngles += new Vector3(0, 0, -aimChange * speed);
        playerRotation.Value = transform.localEulerAngles.z;
    }
}
