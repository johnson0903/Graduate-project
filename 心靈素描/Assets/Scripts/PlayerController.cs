using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private Animator animator;
	private Rigidbody2D playerRigidbody;
	private PlayerInventory playerInventory;
	public float speed;
	public bool isTalking = false;

	// Use this for initialization
	void Start () {
		playerRigidbody = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
		playerInventory = GetComponent<PlayerInventory> ();
	}

	// Update is called once per frame
	void Update() {
		
		float moveHorizontal = Input.GetAxis ("Horizontal");
		Vector2 movement = new Vector2(moveHorizontal, 0.0f);
		animator.SetFloat ("speed", Mathf.Abs(moveHorizontal*speed));
		playerRigidbody.velocity = movement * speed;

		if (isTalking) {
			speed = 0;
		} else {
			speed = 8;
		}
	}

	void OnTriggerStay2D(Collider2D other){
		if (other.CompareTag ("Item") || other.CompareTag ("NPC")) {
			isTalking = true;
			if (other.CompareTag ("Item") && !isTalking) {
				playerInventory.PickUpItem (other.gameObject);
			}
		}
	}

	public void EndTalk() {
		if (isTalking) {
			isTalking = false;
		}
	}


}
