using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private Animator animator;
	private Rigidbody2D rigid;
	public float speed;
	public bool isTalking = false;

	// Use this for initialization
	void Start () {
		rigid = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		Vector2 movement = new Vector2(moveHorizontal, 0.0f);
		animator.SetFloat ("speed", Mathf.Abs(moveHorizontal*speed));
		rigid.velocity = movement * speed;

		if (isTalking) {
			speed = 0;
		} else {
			speed = 8;
		}
	}

	public void Talking() {
		isTalking = true;
	}

	public void TalkingOver() {
		isTalking = false;
	}
}
