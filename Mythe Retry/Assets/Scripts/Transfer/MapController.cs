using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour {
	// This script will handle all the maps being viewed and what should be disabled.

	// GameObject array holding all the maps.
	[Tooltip("Drag each map PARENT in this array!")]
	public GameObject[] maps;

	// Timers.
	private float startTimer = 0;
	private float disableTimer = 2;
	private bool runTimer = false;

	// Reference to ThresholdController.
	private TransferController _tc;

	private void Start() {
		// Subscribe to TransferController action.
		_tc = FindObjectOfType<TransferController>();
		_tc.PlayerArrived += ShowCorrectMap;

		// Disable next maps on start-up.
		// Has to be -1, the way the function and arrays are setup.
		ShowCorrectMap(-1);
	}

	private void Update()
	{
		if (runTimer) {
			startTimer += Time.deltaTime;
		}
	}

	// Disables all maps, except the one the player is currently on.
	private void ShowCorrectMap(int map)
	{
		Debug.Log("CorrectMapSetup called, map = " + map);
		for (int i = 0; i < maps.Length; i++) {
			// Sets all maps to false.
			maps[i].SetActive(false);

			// "map" + 1, because the first map is array index 0, and arrival index starts at 1.
			if (i == map + 1) {
				maps[i].SetActive(true);
			}
		}
	}
}
