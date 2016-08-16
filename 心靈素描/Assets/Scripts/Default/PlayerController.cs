using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

	public float speed;

	private Animator animator;
	private Rigidbody2D playerRigidbody;
	private float walkSpeed;

	private static float originPositionX;

	// Use this for initialization
	void Start()
	{
		playerRigidbody = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		walkSpeed = speed;
	}

	// Update is called once per frame
	void Update()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		Vector2 movement = new Vector2(moveHorizontal, 0.0f);
		playerRigidbody.velocity = movement * walkSpeed;
		animator.SetFloat("speed", Mathf.Abs(moveHorizontal * walkSpeed));
	}

	public void DontMove()
	{
		walkSpeed = 0;
	}

	public void YouCanMove()
	{
		walkSpeed = speed;
	}

	public void LogOriginPositionX()
	{
		originPositionX = this.transform.position.x;
	}

	public void MoveToOriginPositionX()
	{
		this.transform.position = new Vector3 (originPositionX, this.transform.position.y, this.transform.position.z);
	}

	public static float OriginPositionX {
		get{ return originPositionX; }
	}
		
}
