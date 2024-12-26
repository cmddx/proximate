using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;
using UnityEngine.InputSystem.LowLevel;

public class VirtualMouse : VirtualMouseInput
{
	[SerializeField] float minX;
	[SerializeField] float maxX;
	[SerializeField] float minY;
	[SerializeField] float maxY;

	float defaultSensitivity = 1;

	new void OnEnable()
	{
		base.OnEnable();

		// centers the cursor
		Cursor.lockState = CursorLockMode.None;

		Set(new Vector2(960, 540));
	}

	void Update()
	{
		Set(ProxInput.point.ReadValue<Vector2>());
	}

	void Set(Vector2 position)
	{
		float cursorX = Mathf.Max(minX, position.x);
		cursorX = Mathf.Min(maxX, cursorX);
		float cursorY = Mathf.Max(minY, position.y);
		cursorY = Mathf.Min(maxY, cursorY);

		Vector2 mousePosition = new Vector2(cursorX, cursorY);

		cursorTransform.anchoredPosition = mousePosition;
		InputState.Change(virtualMouse.position, mousePosition);
	}
}