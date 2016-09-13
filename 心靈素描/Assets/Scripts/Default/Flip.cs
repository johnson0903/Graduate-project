using UnityEngine;
using System.Collections;

public class Flip : MonoBehaviour {

	private bool isFacingLeft;
	private bool isFacingRight;

	void Start () {
		FlipRight ();
	}

	// Update is called once per frame
	void Update () {
		if (this.GetComponent<PlayerController> ().Speed != 0) {
			if (this.GetComponent<Rigidbody2D> ().velocity.x < 0 && isFacingRight)
				FlipLeft ();
			else if (this.GetComponent<Rigidbody2D> ().velocity.x > 0 && isFacingLeft)
				FlipRight ();
		}
	}
		
	public void FlipLeft(){
		isFacingLeft = true;
		isFacingRight = false;
		Vector3 theScale = transform.localScale;
		theScale.x = -1;
		transform.localScale = theScale;
	}

	public void FlipRight(){
		isFacingLeft = false;
		isFacingRight = true;	
		Vector3 theScale = transform.localScale;
		theScale.x = 1;
		transform.localScale = theScale;
	}

}
