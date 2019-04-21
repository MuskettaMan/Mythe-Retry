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

	// Data.
	//private DataManager _dataManager;

	void Start() // Assign starting values.
	{
		// Components.
		rb = GetComponent<Rigidbody>();
		ac = FindObjectOfType<AudioController>();
		//_dataManager = FindObjectOfType<DataManager>();

		// Stats.
		//var player = _dataManager.GetData<PlayerStats>("player");

        //transform.position = new Vector3(player.pos.x, player.pos.y, player.pos.z);
    }

	void Update()
	{
		PlayerMovement();

		if (Input.GetKeyDown(KeyCode.E))
		{
			if (PickupInteraction.canInteract) Interact(target);
		}
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

	private void Interact(GameObject target)
	{
		// MORE ACTIONS HERE.
		// MORE ACTIONS HERE.
		// MORE ACTIONS HERE.
		if (Interacting != null) Interacting();
		PickupInteraction.isInteracting = true;
		//Destroy(target);
	}

    private void OnDisable()
    {
        //var _player = _dataManager.GetData<PlayerStats>("player");

        //_player.pos.x = transform.position.x;
        //_player.pos.y = transform.position.y;
        //_player.pos.z = transform.position.z;

        //_dataManager.SaveAll();
    }
}
