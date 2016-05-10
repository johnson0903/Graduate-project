using UnityEngine;
using System.Collections;

public class Flip : MonoBehaviour {

	private bool isFacingRight = true;
	
	// Update is called once per frame
	void Update () {
		if ((Input.GetKeyDown (KeyCode.LeftArrow) || Input.GetKeyDown (KeyCode.A)) && isFacingRight)
			FlipPlayer ();
		if ((Input.GetKeyDown (KeyCode.RightArrow) || Input.GetKeyDown (KeyCode.D)) && !isFacingRight)
			FlipPlayer ();
	}
		

	void FlipPlayer(){
		isFacingRight = !isFacingRight; 	
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
