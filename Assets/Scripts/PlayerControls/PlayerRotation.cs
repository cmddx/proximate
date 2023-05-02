using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    public float speed;
    public DynamicFloat playerRotation;
    float aim;

    // Update is called once per frame
    void Update()
    {
        aim += Input.GetAxis("Mouse X");

        transform.localRotation = Quaternion.Euler(0, 0, -aim * speed);
        playerRotation.Value = -aim * speed;
    }
}
