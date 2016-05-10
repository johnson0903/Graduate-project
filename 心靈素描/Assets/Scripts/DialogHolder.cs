using UnityEngine;
using System.Collections;

public class DialogHolder : MonoBehaviour {

	public string dialog;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay2D(Collider2D other){
		if (other.gameObject.name == "Player") {
			if(Input.GetMouseButtonUp(0)){
			}
		}
	}
}
