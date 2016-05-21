using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

	public float speed;

	private Animator animator;
	private Rigidbody2D playerRigidbody;
	private bool isTalking;

	// Use this for initialization
	void Start ()
	{
		playerRigidbody = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		Vector2 movement = new Vector2 (moveHorizontal, 0.0f);
		animator.SetFloat ("speed", Mathf.Abs (moveHorizontal * speed));
		playerRigidbody.velocity = movement * speed;
	}
		
	public void StartTalk() {
		isTalking = true;
		speed = 0;
	}

	public void EndTalk() {
		isTalking = false;
		speed = 8;
	}

	public bool IsTalking {
		get{ return isTalking; }
	}

}
