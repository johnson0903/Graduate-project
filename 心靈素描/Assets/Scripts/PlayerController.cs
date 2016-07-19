using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

	public float speed;
	public Vector2 movement;
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
	    movement = new Vector2 (moveHorizontal, 0.0f);
		animator.SetFloat ("speed", Mathf.Abs (moveHorizontal * speed));
		playerRigidbody.velocity = movement * speed;
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
