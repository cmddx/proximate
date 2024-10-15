using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    public float speed;
    public DynamicFloat playerRotation;
    float aimChange;

    // Update is called once per frame
    void Update()
    {
        aimChange = ProxInput.Look.x;

        if (aimChange > 0.35) aimChange = 0.35f;
        if (aimChange < -0.35) aimChange = -0.35f;

        transform.localEulerAngles += new Vector3(0, 0, -aimChange * speed);
        playerRotation.Value = transform.localEulerAngles.z;
    }
}
