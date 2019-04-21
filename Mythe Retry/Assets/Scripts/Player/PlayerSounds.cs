using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerSounds : MonoBehaviour
{
	// Sounds.
	public Action Walking;
	public Action Punching;

	public void WalkSound()
	{
		if (Walking != null) Walking();
	}

	public void PunchSound()
	{
		if (Punching != null) Punching();
	}
}
