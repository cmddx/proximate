using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static InputActions;
using TMPro;
using System;

public class ProxInput : MonoBehaviour
{
	public InputActions controls;

	private static InputAction move;
	private static InputAction look;
	private static InputAction interact;
	private static InputAction map;
	private static InputAction pause;
	public static InputAction point;
	public static InputAction scroll;

	public static Vector2 Move { get { return move.ReadValue<Vector2>(); } }
	public static Vector2 Look { get { return look.ReadValue<Vector2>(); } }
	public static bool Interact { get { return interact.WasPressedThisFrame(); } }
	public static bool Map { get { return map.IsPressed(); } }
	public static bool Pause { get { return pause.WasPressedThisFrame(); } }
	public static Vector2 Point { get { return point.ReadValue<Vector2>(); } }
	public static Vector2 Scroll { get { return scroll.ReadValue<Vector2>(); } }


	// Start is called before the first frame update
	void Start()
	{
		if (controls == null)
		{
			controls = new InputActions();
		}

		controls.Inputs.Enable();
		move = controls.FindAction("Move");
		look = controls.FindAction("Look");
		interact = controls.FindAction("Interact");
		map = controls.FindAction("Map");
		pause = controls.FindAction("Pause");
		point = controls.FindAction("Point");
		scroll = controls.FindAction("Scroll");
	}

	public void OnEnable()
	{
		Start();
	}

	public void OnDisable()
	{
		controls.Inputs.Disable();
	}
}


