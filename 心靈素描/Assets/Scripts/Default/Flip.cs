﻿using UnityEngine;
using System.Collections;

public class Flip : MonoBehaviour {

	private bool isFacingRight = true;
	
	// Update is called once per frame
	void Update () {
		if (this.GetComponent<Rigidbody2D>().velocity.x < 0 && isFacingRight)
			FlipPlayer ();
		else if (this.GetComponent<Rigidbody2D>().velocity.x > 0 && !isFacingRight)
			FlipPlayer ();
	}
		

	void FlipPlayer(){
		if (this.GetComponent<PlayerController> ().Speed != 0) {
			isFacingRight = !isFacingRight; 	
			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;
		}
	}
}
