using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class CombatTimer : MonoBehaviour {
	// Timers.
	private float baseTime = 10; // Amount of time for the player to pick runes.
	private float currentTime;
	private float stoppedTime;

	// Actions.
	public Action TimerStarted, TimerEnded;

	// Booleans.
	private bool countingDown = false;

	// UI Element.
	[Tooltip("Drag UI text component here!")]
	public TextMeshProUGUI countText; // Drag text element from canvas here to display the timer on-screen.

	void Start () {
		// Timers.
		currentTime = baseTime;
        
        SlotMaster.SlotsFilled += StopTimer;
    }
	
	void Update () {
		if (countingDown) {
			Countdown();
		}

		if (currentTime <= 0 && countingDown) {
			StopTimer();
		}
	}

    public void ResetTimer() {
        currentTime = baseTime;
        TimerStarted?.Invoke();

        countingDown = true;
    }

	public void StartTimer() // Accessable from outside this script.
	{
		if (TimerStarted != null)
            TimerStarted();

		countingDown = true;
	}

	private void Countdown() // Yells TimerStarted() and counts down.
	{
		currentTime -= Time.deltaTime;
		countText.text = Mathf.RoundToInt(currentTime).ToString(); // Converts the timer to show as text for the UI element.
	}

	private void StopTimer() // Yells TimerEnded().
	{
		countingDown = false;
		stoppedTime = currentTime;
		currentTime = stoppedTime;
		if (TimerEnded != null)
			TimerEnded();
	}
}
