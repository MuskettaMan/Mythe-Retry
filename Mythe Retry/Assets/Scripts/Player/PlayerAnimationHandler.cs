using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationHandler : MonoBehaviour {
    #region Public Fields
    public enum AnimationState {
        Idle,
        Run,
        Punch
    }

	// Particles (Punch)
	public ParticleSystem ps_punch;
	private ParticleSystem.EmissionModule punchEmission;
    #endregion

    #region Private Fields
    private Rigidbody rigidBody;
    private Animator animator;
	private bool isPunching = false;

    #endregion

    #region Unity Methods
    private void Awake() {
        rigidBody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Start() {
		punchEmission = ps_punch.emission;
	}

    void Update() {
        // Set the animation to the correct state based on the movement of the player;
		if (!isPunching)
		{
			if (rigidBody.velocity.x != 0 || rigidBody.velocity.z != 0)
			{
				animator.SetInteger("AnimState", (int)AnimationState.Run);
			}
			else
			{
				animator.SetInteger("AnimState", (int)AnimationState.Idle);
			}
		}

        // Get reference to the scale
        var scale = transform.localScale;

        // Invert the scale if the velocity is to the left
        if(rigidBody.velocity.x > 0) {
            scale.x = Mathf.Abs(transform.localScale.x);
        } else if(rigidBody.velocity.x < 0) {
            scale.x = -Mathf.Abs(transform.localScale.x);
        }

        // Apply the new scale to the player
        transform.localScale = scale;
    }
    #endregion

    #region Public Methods
    #endregion

    #region Private Methods
	private void Punch()
	{
		isPunching = true;
		punchEmission.rateOverDistance = 100f;
		animator.SetTrigger("Punch");
	}

	private void DonePunching()
	{
		isPunching = false;
		punchEmission.rateOverDistance = 0f;
	}
    #endregion
}
