using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller;
	public Animator animator;

	public float runSpeed = 30f;

	float horizontalMove = 0f;
	bool jump = false;

	// Update is called once per frame
	void Update () {

		if (animator.GetBool("Dead"))
		{
			runSpeed = 0;
		}

		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		animator.SetFloat("MoveSpeed", Mathf.Abs(horizontalMove));

		if (Input.GetButtonDown("Jump"))
		{
			jump = true;
			animator.SetBool("Airborne", true);
		}

	}

	public void OnLanding ()
	{
		animator.SetBool("Airborne", false);
	}

	void FixedUpdate ()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
		jump = false;
	}
}
