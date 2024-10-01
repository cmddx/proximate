using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class FollowMouse : MonoBehaviour
{
    [SerializeField] float minX;
    [SerializeField] float maxX;
    [SerializeField] float minY;
    [SerializeField] float maxY;
    [SerializeField] Canvas canvas;

	private float CursorSpeed = 0.1f;

    void OnEnable()
    {
        // centers the cursor
        Cursor.lockState = CursorLockMode.None;

		ProxInput.mouse.performed += MovePointerWithMouse;
	}

	void OnDisable()
	{
		ProxInput.mouse.performed -= MovePointerWithMouse;
	}

	void Update()
	{
		// MovePointerWithCursor(ProxInput.cursor.ReadValue<Vector2>());
	}

    void MovePointerWithMouse(InputAction.CallbackContext context)
    {    
		// Vector3 mousePosition = Camera.main.ScreenToWorldPoint(
        //     context.ReadValue<Vector2>());
		
		// Set(mousePosition);
    }

	void MovePointerWithCursor(Vector3 delta)
    {    
		// if (delta == Vector3.zero) return;

		// Set(transform.position + delta * CursorSpeed);
    }

	void Set(Vector2 delta)
	{
        float cursorX = Mathf.Max(minX, delta.x);
        cursorX = Mathf.Min(maxX, cursorX);
        float cursorY = Mathf.Max(minY, delta.y);
        cursorY = Mathf.Min(maxY, cursorY);

        transform.position = new Vector3(cursorX, cursorY, 0);
	}
}
