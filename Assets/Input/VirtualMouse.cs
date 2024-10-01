using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;
using UnityEngine.InputSystem.LowLevel;

public class VirtualMouse : VirtualMouseInput
{
    new void OnEnable()
    {
		base.OnEnable();

        // centers the cursor
        Cursor.lockState = CursorLockMode.None;

		Set(cursorTransform.anchoredPosition/2); 
	}

	void Update()
	{
		Set(ProxInput.point.ReadValue<Vector2>());
	}

	void Set(Vector2 position)
	{
		cursorTransform.anchoredPosition = (Vector3)position;
		InputState.Change(virtualMouse.position, position);

	}
}