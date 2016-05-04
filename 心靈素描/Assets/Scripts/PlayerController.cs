using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private Animator animator;
	private Rigidbody2D rigid;
	public float speed;

	// Use this for initialization
	void Start () {
		rigid = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate(){

		float moveHorizontal = Input.GetAxis ("Horizontal");
		Vector2 movement = new Vector2(moveHorizontal, 0.0f);
		rigid.velocity = movement * speed;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
