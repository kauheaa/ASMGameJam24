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


	public Transform orientation;

	float horizontalInput;
	float verticalInput;

	Vector3 moveDirection;

	Rigidbody rb;

	private void Start()
	{
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
