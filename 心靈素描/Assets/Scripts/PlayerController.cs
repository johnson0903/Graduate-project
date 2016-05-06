using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private Animator animator;
	private Rigidbody2D rigid;
	private PlayerInventory playerInventory;
	public float speed;
	public bool isTalking = false;

	// Use this for initialization
	void Start () {
		rigid = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
		playerInventory = GetComponent<PlayerInventory> ();
	}

	// Update is called once per frame
	void Update () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		Vector2 movement = new Vector2(moveHorizontal, 0.0f);
		animator.SetFloat ("speed", Mathf.Abs(moveHorizontal*speed));
		rigid.velocity = movement * speed;

		if (isTalking) {
			speed = 0;
		} else {
			speed = 8;
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("Item")) {
			isTalking = true;
			playerInventory.PickUpItem (other.gameObject);
		}
	}

	public void TalkingOver() {
		isTalking = false;
	}


}
