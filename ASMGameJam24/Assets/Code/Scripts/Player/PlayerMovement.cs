using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[Header("Movement")]
	public float moveSpeed;

	public float groundDrag;

	[Header("Ground Check")]
	public float playerHeight;
	public LayerMask whatIsGround;
	bool grounded;

	public AudioSource stepAudioSource;  // Reference to the AudioSource component
	public AudioClip[] stepSounds;       // Array to hold different step sounds
	public float stepInterval = 0.5f;    // Time interval between steps

	private CharacterController characterController;
	private float stepTimer;


	public Transform orientation;

	float horizontalInput;
	float verticalInput;

	Vector3 moveDirection;

	Rigidbody rb;

	private void Start()
	{
		stepTimer = stepInterval;
		rb = GetComponent<Rigidbody>();
		rb.freezeRotation = true;
	}

	private void Update()
	{
		//ground check
		grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);
		
		MyInput();
		SpeedControl();

		// handle drag
		if (grounded)
			rb.drag = groundDrag;
		else
		{
			rb.drag = 0;
		}

		if (IsArrowOrWASDKeyPressed())
		{
			stepTimer -= Time.deltaTime;
			if (stepTimer <= 0f)
			{
				PlayStepSound();
				stepTimer = stepInterval;
			}
		}
	}

	bool IsArrowOrWASDKeyPressed()
	{
		// Check for arrow keys
		if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) ||
			Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
		{
			return true;
		}

		// Check for WASD keys
		if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) ||
			Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
		{
			return true;
		}

		return false;
	}



	private void FixedUpdate()
	{
		MovePlayer();
	}

	private void MyInput()
	{
		horizontalInput = Input.GetAxisRaw("Horizontal");
		verticalInput = Input.GetAxisRaw("Vertical");
	}

	private void MovePlayer()
	{
		//calculate movement direction
		moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

		if (horizontalInput != 0 || verticalInput != 0)
		{
			rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
		}
		else
		{
			// Stop the player when there is no input
			rb.velocity = new Vector3(0, rb.velocity.y, 0);
		}

	}


	void PlayStepSound()
	{
		if (stepSounds.Length > 0)
		{
			int index = Random.Range(0, stepSounds.Length);
			stepAudioSource.clip = stepSounds[index];
			stepAudioSource.Play();
		}
	}

	private void SpeedControl()
	{
		Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
		
		//limit velocity if needed
		if(flatVel.magnitude > moveSpeed) //if you go faster than your movement speed....
		{
			Vector3 limitedVel = flatVel.normalized * moveSpeed; // ...you calculate what your max velocity would be
			rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z); //...and then apply it
		}
	}
}
