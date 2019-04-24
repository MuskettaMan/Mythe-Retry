using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Threshold : MonoBehaviour {
	// This script must be on every threshold gameobject.
	// This threshold gameobject must have a trigger collider.

	// This gameobject.
	private GameObject threshold;

	// Action that yells this gameobject when entered.
	public Action<GameObject> ThresholdEntered;

	private void Start() {
		// Set threshold equal to this gameobject.
		threshold = gameObject;
	}

	private void OnTriggerEnter(Collider other)	{
		if (other.tag == "WorldPlayer") {
			// If action has listeners.
			if (ThresholdEntered != null) {
				// Yell ThresholdEntered with this gameobject attached.
				// ThresholdController is the only listener.
				ThresholdEntered(threshold);
			}
		}
	}
}
