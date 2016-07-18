﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

	public float speed;

	private Animator animator;
	private Rigidbody2D playerRigidbody;
	private bool isTalking;
	private float tempSpeed;

	// Use this for initialization
	void Start ()
	{
		playerRigidbody = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
		tempSpeed = speed;
	}

	// Update is called once per frame
	void Update ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		Vector2 movement = new Vector2 (moveHorizontal, 0.0f);
		if (movement.x != 0)
			playerRigidbody.velocity = movement * speed;
		animator.SetFloat ("speed", Mathf.Abs (playerRigidbody.velocity.x));
	}
		
	public void StartTalk() {
		isTalking = true;
		tempSpeed = speed;
		speed = 0;
	}

	public void EndTalk() {
		isTalking = false;
		speed = tempSpeed;
	}

	public bool IsTalking {
		get{ return isTalking; }
	}

}
