using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public GameLogic control;

	CharacterController controller;
	bool isGrounded = false;
	public float PlayerSpeed = 6.0f;
	public float PlayerJumpSpeed = 8.0f;
	public float gravity = 20.0f;
	private Vector3 PlayerMoveDirection = Vector3.zero;

	void Start()
	{
		controller = GetComponent<CharacterController>();
	}
	void Update()
	{
		if (controller.isGrounded)
		{
			PlayerMoveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
			PlayerMoveDirection = transform.TransformDirection(PlayerMoveDirection);
			PlayerMoveDirection *= PlayerSpeed;

			if (Input.GetButton("Jump"))
			{
				PlayerMoveDirection.y = PlayerJumpSpeed;
			}
			if (controller.isGrounded)
				isGrounded = true;
		}

		PlayerMoveDirection.y -= gravity * Time.deltaTime;
		controller.Move(PlayerMoveDirection * Time.deltaTime);
	}


	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "Items(Clone)")
		{
			//Items
			control.GetItems();
		}
		else if (other.gameObject.name == "Monster(Clone)")
		{
			//Monster
			control.CrashMonster();
		}
		Destroy(other.gameObject);

	}
}
