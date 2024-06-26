using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    [SerializeField] float minX;
    [SerializeField] float maxX;
    [SerializeField] float minY;
    [SerializeField] float maxY;
    [SerializeField] Canvas canvas;

    void OnEnable()
    {
        // centers the cursor
        Cursor.lockState = CursorLockMode.None;
    }

    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(
            Input.mousePosition);
        transform.position = mousePosition;

        float cursorX = Mathf.Max(minX, transform.localPosition.x);
        cursorX = Mathf.Min(maxX, cursorX);
        float cursorY = Mathf.Max(minY, transform.localPosition.y);
        cursorY = Mathf.Min(maxY, cursorY);

        transform.localPosition = new Vector3(cursorX, cursorY, 0);
    }
}
