using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TransferController : MonoBehaviour {
	// This script will transfer the player from position A to B.
	// This script works, because arrival index is always threshold index +1.
	// Make sure the player has the tag "Player".

	// The player gameobject.
	private GameObject player;

	// Array filled with arrival locations (empty gameobjects).
	// !!! This array starts from map 1 arrival !!! (second map/level)
	[Tooltip("Drag arrival locations here!")]
	public GameObject[] arrival;

	// Action that yells that player arrived on a map.
	public Action<int> PlayerArrived;

	// Reference to ThresholdController.
	private ThresholdController _thc;

	private void Start()
	{
		// Set player equal to the gameobject this script is attached to.
		player = gameObject;

		// Subscribe to ThresholdController's action.
		_thc = FindObjectOfType<ThresholdController>();
		_thc.TravelTowards += TransferToMap;
	}

	// This function transfers the player to the correct map.
	private void TransferToMap(int index)
	{
		for (int i = 0; i < arrival.Length; i++) {
			if (i == index) {
				// Loop through arrival array.
				// If index equals arrival[i], transfer to that location.
				player.transform.position = arrival[i].transform.position;
				// Yell the player arrived on index map.
				PlayerArrived(index);
				// Return to exit loop.
				return;
			}
		}
	}
}
