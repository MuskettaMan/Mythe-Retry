using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraSwitcher : MonoBehaviour {
	// This script goes on the world player.

	// GameObject array filled with cameras.
	// Index 0 must be world camera.
	// Index 1 must be combat camera.
	[Tooltip("Put world camera first, then combat camera!")]
	public GameObject[] cameras;

	// Actions.
	// PlayerController must subscribe to these actions to switch movement on/off using a boolean.
	public Action SwitchToCombat;
	public Action SwitchToWorld;

	private void OnTriggerEnter(Collider other) {
		if (other.tag == "Enemy") {
			SwitchToCombatCamera();
		}
	}

	private void SwitchToCombatCamera() {
		cameras[0].SetActive(false);
		cameras[1].SetActive(true);

		// Yell action.
		if (SwitchToCombat != null) {
			SwitchToCombat();
		}
	}

	public void SwitchToWorldCamera() {
		cameras[0].SetActive(true);
		cameras[1].SetActive(false);

		// Yell action.
		if (SwitchToWorld != null) {
			SwitchToWorld();
		}
	}
}
