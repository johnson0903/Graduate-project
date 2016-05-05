using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private Animator animator;
	private Rigidbody2D rigid;
	public float speed;

	// Use this for initialization
	void Start () {
		rigid = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
	}

	void FixedUpdate(){

		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		Vector2 movement = new Vector2(moveHorizontal, moveVertical);
		rigid.velocity = movement * speed;
	}
	
	// Update is called once per frame
	void Update () {
//		animator.SetFloat ();
	}
}
