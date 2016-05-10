using UnityEngine;
using System.Collections;

public class UnknownObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
		this.GetComponent<SpriteRenderer> ().color = new Color(0, 0, 0, 1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay2D(Collider2D other){
		if (other.gameObject.name == "Player") {
			this.GetComponent<SpriteRenderer> ().color = new Color(255, 255, 255, 1);
		}
	}
}
