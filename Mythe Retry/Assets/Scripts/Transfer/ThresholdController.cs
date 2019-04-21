using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ThresholdController : MonoBehaviour {
	// This script manages the thresholds.

	// This array holds all thresholds in the correct order.
	// Index 0 must be the threshold from map 0 to map 1 etc.
	[Tooltip("Drag all thresholds here in correct order!")]
	public GameObject[] thresholds;

	// Array to reference all thresholds scripts.
	private Threshold[] _th;

	// Action that yells where we want to go.
	public Action<int> TravelTowards;

	private void Start() {
		// Initialize _th array.
		_th = new Threshold[thresholds.Length];

		for (int i = 0; i < _th.Length; i++) {
			// Get the threshold component from every threshold.
			_th[i] = thresholds[i].GetComponent<Threshold>();
			// Subscribe to all threshold actions.
			_th[i].ThresholdEntered += PrepareToTransfer;
		}
	}

	// Example:
	// Threshold = 1. (threshold on map 1)
	// map == thresholds[0]? No. Nothing happens.
	// map == thresholds[1]? Yes. Yell TravelTowards(1).
	// TransferController is the only listener.
	private void PrepareToTransfer(GameObject map) {
		// Start index on zero.
		int index = 0;

		// Loop every threshold.
		for (int i = 0; i < thresholds.Length; i++) {
			if (map == thresholds[i]) {
				// If map equals threshold, update index.
				index = i;
				// Check if we have listeners.
				if (TravelTowards != null) {
					// Yell index.
					TravelTowards(index);
				}
			}
		}
	}
}
