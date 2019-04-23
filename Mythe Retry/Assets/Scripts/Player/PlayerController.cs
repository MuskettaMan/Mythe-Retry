using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
	// Movement.
	public float moveSpeed;
	//private float moveSpeed;
	private float horizontalMove, verticalMove;
	private bool diagonal;
	private Vector3 movement;

	// Components.
	private Rigidbody rb;
	private AudioController ac;

	// Animations.
	private bool isIdle;

	// Interaction.
	public GameObject target;
	public Action Interacting;

	void Start() // Assign starting values.
	{
		// Components.
		rb = GetComponent<Rigidbody>();
		ac = FindObjectOfType<AudioController>();
	
    }

	void Update()
	{
		PlayerMovement();
	}

	private void PlayerMovement() // Handles movement controls.
	{
		MovingDiagonal();

		if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
		{
			horizontalMove = Input.GetAxisRaw("Horizontal") * moveSpeed;
			verticalMove = Input.GetAxisRaw("Vertical") * moveSpeed;
			movement = new Vector3(horizontalMove, rb.velocity.y, verticalMove);
			rb.velocity = Vector3.Lerp(rb.velocity, movement, 15 * Time.deltaTime);
		}

		if (Input.GetAxis("Horizontal") == 0 && (Input.GetAxis("Vertical") == 0))
		{
			Vector3 standStill = new Vector3(0, rb.velocity.y, 0);
			rb.velocity = Vector3.Lerp(rb.velocity, standStill, 30 * Time.deltaTime);
		}
	}

	private void MovingDiagonal() // Checks if player is walking on both the X and Z axis. If so, slows movement.
	{
		diagonal = horizontalMove != 0 && verticalMove != 0;
		moveSpeed = !diagonal ? 5f : 3.5f;
	}

}
